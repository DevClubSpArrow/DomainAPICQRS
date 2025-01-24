using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using HindalcoBackend.Domain;
using HindalcoBackend.Business.AppDbContext;
using HindalcoBackend.Domain.Interface;
using HindalcoBackend.Application.DataModels;
using ITokenGenerator = HindalcoBackend.Domain.Interface.ITokenGenerator;
using HindalcoBackend.Application.Interface;
using HindalcoBackend.Application.Queries;
using static HindalcoBackend.Application.Queries.TokenQuery;

namespace HindalcoBackend.Application
{
     //   public class GenerateToken : IRequest<HindalcoBackend.Business.ResponseToken> { }
        public class TokenGenerator : IRequestHandler<GenerateTokenQuery, HindalcoBackend.Business.ResponseToken>
        {
            private readonly HindalcoBackend.Domain.Interface.ITokenGenerator _tokenService;
         //   private readonly HindalcoBackend.Domain.Interface.IAuditMapper _auditService;
            private HindalcoBackend.Business.UserModel umodel { get; }
            private HindalcoBackend.Domain.AuthRefreshToken _authToken { get; }
            public TokenGenerator(ITokenGenerator tokenGenerator)
            {
                _tokenService = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator), "Token generator cannot be null.");
            }
            public async Task<Business.ResponseToken> Handle(GenerateTokenQuery request,CancellationToken cancellationToken)
            {
                return umodel == null
                ? throw new InvalidOperationException("User model is null, cannot generate token.")
                :  await _tokenService.Generatetoken(umodel);
            }
        }
    }
