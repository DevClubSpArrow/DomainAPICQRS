using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HindalcoBackend.Application.DataModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using HindalcoBackend.Business.AppModels.DataModels;
using System.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace HindalcoBackend.Business.Service
{
    public  class AuditManager: ITokenGenerator//,IAuditMapper
    {
        private readonly appDBontext _appDBontext;
        private HelperClass.HelperAction _helper = new HelperClass.HelperAction();
        public AuditManager(appDBontext appDBontext)
        {
            _appDBontext = appDBontext;
        }
        async Task<HindalcoBackend.Business.ResponseToken> ITokenGenerator.Generatetoken(HindalcoBackend.Business.UserModel umodel)
        {
            ResponseToken? rspToken = null;
            try
            {
                if (umodel != null)
                {
                    var result = await _appDBontext.tbl_usermodel.Where(u => u.Uid == umodel.Uid && u.Password == umodel.Password).FirstOrDefaultAsync(); //&& u.Password == umodel.Password).FirstOrDefaultAsync();
                    if (result != null)
                    {
                        _helper.AppConfiguration();
                        var audience = AppBuilder.Audiences; // builder.Configuration["JwtBearer:Audiences"];
                        var keyValue = AppBuilder.Key;   //builder.Configuration.GetSection("JwtBearer:Key").Value;
                        if (keyValue == null)
                        {
                          throw new InvalidOperationException("JwtBearer:Key is missing in the configuration.");
                        }
                        var Key = Encoding.ASCII.GetBytes(keyValue);
                        AuthRefreshToken? authRToken = null;
                        authRToken = await _helper.GenerateRefreshToken(_appDBontext, Convert.ToInt32(umodel.Uid));
                        var tokendescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new[]
                            {
                                new Claim("Uid",umodel.Uid.ToString()),
                                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,umodel.UserName.ToString()),
                                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,umodel.UserName.ToString()),
                                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                            }),
                            Expires = DateTime.UtcNow.AddSeconds(1200),
                            Issuer = AppBuilder.Issuer,
                            Audience = audience,
                            SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature),
                        };
                        var tokenhandler = new JwtSecurityTokenHandler();
                        var token = tokenhandler.CreateJwtSecurityToken(tokendescriptor);
                        var jwttoken = tokenhandler.WriteToken(token);
                        var stringtoken = tokenhandler.WriteToken(token);
                        rspToken = new ResponseToken
                        {
                            JwtToken = jwttoken,
                            RefreshToken = authRToken.RefreshToken
                        };
                        return rspToken;
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine( ex.Message);
            }
            return rspToken ?? throw new FormatException("Unable to generate Token!");
        }
        async Task<HindalcoBackend.Business.ResponseToken> ITokenGenerator.GetRenewedToken(AuthRefreshToken refToken)
        {
            ResponseToken vpn = await _helper.ActionDecider(refToken,_appDBontext);
            var responseObj = new ResponseToken
            {
                JwtToken = vpn.JwtToken,
                RefreshToken = vpn.RefreshToken
            };
            return responseObj;
        }
        async Task<int> ITokenGenerator.ValidateJwttoken(string token)
        {
            int inpRet = 0;
            return inpRet =await _helper.ValidateInputtoken(token, _appDBontext);
        }
    }
}
