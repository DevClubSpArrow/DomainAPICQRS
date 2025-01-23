using AuditManagementDAL.DTOObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using HindalcoBackend.Business.AppModels.DataModels;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
namespace HindalcoBackend.Business.HelperClass
{
    public class HelperAction
    {
        public string _connectionString = string.Empty;
        private readonly IConfiguration _Configuration;
        public static HttpClient httpClient = new HttpClient();
        public void AppConfiguration()
        {
           // AppBuilder = _appBuilder ?? throw new ArgumentNullException(nameof(_appBuilder));
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The configuration file 'appsettings.json' was not found.", path);
            }
            configurationBuilder.AddJsonFile(path, optional: false, reloadOnChange: true);
            var root = configurationBuilder.Build();
            // Populate _appBuilder properties
            AppBuilder.Issuer = root.GetSection("JwtBearer")?.GetSection("Issuer")?.Value;
            AppBuilder.Audiences = root.GetSection("JwtBearer")?.GetSection("Audiences")?.Value;
            AppBuilder.Key = root.GetSection("JwtBearer")?.GetSection("Key")?.Value;
            AppBuilder.RefreshTokenValidity = int.TryParse(root.GetSection("JwtBearer")?.GetSection("RefreshTokenValidity")?.Value,
                                              out int validity) ? validity : 0;
            AppBuilder.KeyText = root.GetSection("JwtBearer")?.GetSection("KeyText")?.Value;
            AppBuilder.appBaseURL = root.GetSection("ApplicationSettings")?.GetSection("AppBaseURL")?.Value;
           
        }
        public string ConnectionString
        {
            get => _connectionString;
        }
        public async Task<AuthRefreshToken> GenerateRefreshToken(appDBontext _appDBontext, int uid)
        {
            byte[] dataBytes = new byte[32];
            AuthRefreshToken? athRToken = null;
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(dataBytes);
                athRToken = new AuthRefreshToken
                {
                    RefreshToken = Convert.ToBase64String(dataBytes),
                    RefreshTokenExpireDate = DateTime.UtcNow.AddDays(7),
                    TokenCreationDate = DateTime.UtcNow,
                    Uid = uid,
                    Id = Guid.NewGuid()
                };
                _appDBontext.tbl_RefreshTokens.Add(athRToken);
                await _appDBontext.SaveChangesAsync();
                return athRToken;
            }
        }

        /// <summary>
        /// The code below is used to recursively make a function call with a string paramater
        /// </summary>
        /// <param name="authRefresh"></param>
        /// <param name="db"></param>
        public async Task<ResponseToken> ActionDecider(AuthRefreshToken authRefresh, appDBontext db)
        {
            ResponseToken tpn = new ResponseToken();
            try
            {
                var existingToken = db.tbl_RefreshTokens.Where(a => a.Uid == authRefresh.Uid && a.RefreshToken == authRefresh.RefreshToken && a.RefreshTokenExpireDate < DateTime.UtcNow).FirstOrDefault();
                if (existingToken != null)
                {
                    //return Results.BadRequest();
                }
                if (existingToken == null)
                {
                    db.tbl_RefreshTokens.Remove(existingToken ?? throw new ArgumentException("Passed Token could not be found."));
                    await db.SaveChangesAsync();
                }
                tpn = await GetToken(authRefresh, db);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tpn;
        }
        public async Task<ResponseToken> GetToken(AuthRefreshToken authToken, appDBontext db)
        {
            ResponseToken token = new ResponseToken();
            UserModel? userModel = null;
            var respstr = string.Empty;
            try
            {
                userModel = db.tbl_usermodel.Where(a => a.Uid == authToken.Uid).FirstOrDefault();
                if (userModel == null)
                {
                    // return ("No such user Found!");
                }
                var myContent = JsonConvert.SerializeObject(userModel);
                var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(string.Concat(_Configuration.GetSection("BaseServerURL").GetSection("AppUrl").Value, @"GenerateToken"), requestContent);
                respstr = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<ResponseToken>(respstr.ToString()) ?? throw new InvalidOperationException("The response string is null or empty!");
                if (token == null)
                {
                    throw new InvalidOperationException("Deserialization failed. The response string might be invalid.");
                }
                // token = JsonConvert.DeserializeObject<ResponseToken>(respstr.ToString());
                StaticAuthToken.JwtToken = token.JwtToken;
                StaticAuthToken.RefreshToken = token.RefreshToken;
            }
            catch (Exception ex)
            {
            }
            var responseObj = new ResponseToken
            {
                JwtToken = StaticAuthToken.JwtToken,
                RefreshToken = StaticAuthToken.RefreshToken
            };
            return responseObj;
        }
        public async Task<int> ValidateInputtoken(string inputtoken, appDBontext db)
        {
            if (string.IsNullOrWhiteSpace(inputtoken))
            {
                throw new ArgumentException("Token cannot be null or empty", nameof(inputtoken));
            }
            try
            {
                // Check if a valid refresh token exists in the database
                bool tokenExists = await db.tbl_RefreshTokens
                    .AnyAsync(a => a.RefreshToken == inputtoken && a.RefreshTokenExpireDate > DateTime.UtcNow);

                return tokenExists ? 1 : 0; // 1 if valid, 0 if not valid
            }
            catch (Exception ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.WriteLine($"Error validating token: {ex.Message}");
                // Optionally, propagate the exception or handle it as needed
                throw;
            }
        }
    }
}