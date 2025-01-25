using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HindalcoBackend.Business.AppModels.DataModels;
using HindalcoBackend.Domain;
using HindalcoBackend.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HindalcoBackend.Business.Repositories
{
    public  class BaseRepository : ITokenGenerator
        {
        private readonly appDBontext _appDBontext;
        private HelperClass.HelperAction _helper;
        private readonly ILogger<BaseRepository> _logger;
        public BaseRepository(appDBontext appDBontext, HelperClass.HelperAction helper)
        {
            _appDBontext = appDBontext;
            _helper = helper;
        }
       public async Task<HindalcoBackend.Business.ResponseToken> Generatetoken(HindalcoBackend.Business.UserModel umodel)
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
                        rspToken = new  ResponseToken
                        {
                            JwtToken = jwttoken,
                            RefreshToken = authRToken.RefreshToken
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            return rspToken ?? throw new FormatException("Unable to generate Token!");
        }
    }
}
