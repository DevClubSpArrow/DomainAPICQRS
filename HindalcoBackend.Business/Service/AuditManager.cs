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
using HindalcoBackend.Domain.Interface;
using System.ComponentModel.Design.Serialization;
using Microsoft.Identity.Client;
using System.Transactions;

namespace HindalcoBackend.Business.Service
{
    public  class AuditManager: ITokenGenerator,IAuditMapper
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAuditMapper _auditMapper;
        private readonly appDBontext _appDBontext;
        private HelperClass.HelperAction _helper;
        private readonly ILogger<AuditManager> _logger;
        private int responseRet { get; set; }= 0;
        public AuditManager(appDBontext appDBontext, HelperClass.HelperAction helperAction)
        {
            _appDBontext = appDBontext;
            _helper=helperAction;
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
               _logger.LogError(ex.Message);
            }
            return rspToken ?? throw new FormatException("Unable to generate Token!");
        }
        async Task<HindalcoBackend.Business.ResponseToken> ITokenGenerator.GetRenewedToken(AuthRefreshToken refToken)
        {
            ResponseToken? responseObj=null;
            try
            {
                ResponseToken vpn = await _helper.ActionDecider(refToken, _appDBontext);
                responseObj = new ResponseToken
                {
                    JwtToken = vpn.JwtToken,
                    RefreshToken = vpn.RefreshToken
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return responseObj ?? throw new InvalidOperationException("The renewed token could not be generated.");
        }
        async Task<int> ITokenGenerator.ValidateJwttoken(string token)
        {
            int inpRet = 0;
            return inpRet =await _helper.ValidateInputtoken(token, _appDBontext);
        }
        async Task<int> IAuditMapper.SaveAudit(HindalcoBackend.Business.AuditCalendar auditCal, string token)
        {       
            responseRet =await _tokenGenerator.ValidateJwttoken(token);
            if (responseRet == 0)
            {
               throw new InvalidOperationException("Unable to validate the Token");
            }
            else
            {
                _appDBontext.tbl_auditcalendar.Add(auditCal);
                 responseRet=  await _appDBontext.SaveChangesAsync();
                return responseRet;
            }
        }
        async Task<IList<AuditCalendar>> IAuditMapper.GetAllAuditCalendar(string token)
        {
            List<AuditCalendar> auCal = new List<AuditCalendar>();
            try
            {
                responseRet = await _auditMapper.ValidateInputtoken(token);
                if (responseRet != 0)
                {
                    auCal = await _appDBontext.tbl_auditcalendar.OrderByDescending(a => a.AuditCalendarId).ToListAsync();
                }
                else
                {
                    throw new UnauthorizedAccessException("The provided Token could not be validated!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return auCal;
        }
        async Task<AuditCalendar> IAuditMapper.GetAuditById(int id, string token)
        {
            try
            {
                // Validate the token
                responseRet = await _auditMapper.ValidateInputtoken(token);
                if (responseRet == 0)
                {
                    _logger.LogWarning("Token validation failed for token: {Token}", token);
                    throw new UnauthorizedAccessException("The provided token could not be validated.");
                }

                // Fetch the audit calendar by ID
                var audCal = await _appDBontext.tbl_auditcalendar
                    .Where(a => a.AuditCalendarId == id)
                    .OrderByDescending(a => a.AuditCalendarId)
                    .FirstOrDefaultAsync();

                if (audCal == null)
                {
                    _logger.LogInformation("No audit calendar found for ID: {Id}", id);
                    throw new KeyNotFoundException($"No audit calendar found with ID: {id}");
                }
                return audCal;
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log authorization failures separately for easier debugging
                _logger.LogError(ex, "Authorization failed for token: {Token}", token);
                throw;
            }
            catch (Exception ex)
            {
                // General exception handling
                _logger.LogError(ex, "An error occurred while retrieving the audit calendar with ID: {Id}", id);
                throw new InvalidOperationException("An error occurred while retrieving the audit calendar. Please try again later.", ex);
            }
        }
        async Task<bool> IAuditMapper.UpdateAuditCalendar(int AuditCalendarId, AuditCalendar auditCal, string token)
        {
            try
            {
                responseRet =await _auditMapper.ValidateInputtoken(token);
                if (responseRet != 0)
                {
                    var auditcal = await _appDBontext.tbl_auditcalendar.Where(a => a.AuditCalendarId == AuditCalendarId).ToListAsync();
                    if (auditcal is null) throw new KeyNotFoundException("The provided AuditCalendarId"+ " "+auditCal.AuditCalendarId +"could not be found");
                    auditcal[0].AuditName = auditCal.AuditName;
                    auditcal[0].AuditType = auditCal.AuditType;
                    auditcal[0].AuditStart = auditCal.AuditStart;
                    auditcal[0].AuditCategory = auditCal.AuditCategory;
                    auditcal[0].AreaCode = auditCal.AreaCode;
                    auditcal[0].DeptId = auditCal.DeptId;
                    auditcal[0].DocumentDate = auditCal.DocumentDate;
                    auditcal[0].DocumentedBy = auditCal.DocumentedBy;
                    auditcal[0].ExpectedDate = auditCal.ExpectedDate;
                    auditcal[0].AuditCalendarId = auditCal.AuditCalendarId;
                    await _appDBontext.SaveChangesAsync();
                }
                else
                {
                    throw new UnauthorizedAccessException("The provided token could not be validated.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log authorization failures separately for easier debugging
                _logger.LogError(ex, "Authorization failed for token: {Token}", token);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the audit calendar with ID: {Id}", auditCal.AuditCalendarId);
                throw new InvalidOperationException("An error occurred while retrieving the audit calendar. Please try again later.", ex);
            }
            return true;
        }
        async Task<int> IAuditMapper.ValidateInputtoken(string inputToken)
        {
            int ReturnValKey = 0;
            string uexist = string.Empty;
            try
            {
                ReturnValKey =await _appDBontext.tbl_RefreshTokens.Where(a => a.RefreshToken == inputToken && a.RefreshTokenExpireDate > DateTime.UtcNow).CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating the input token: {Token}", inputToken);
                // Rethrow the exception if needed
                throw new InvalidOperationException("An error occurred while validating the input token.", ex);
            }
            return ReturnValKey;
        }
    }
}
