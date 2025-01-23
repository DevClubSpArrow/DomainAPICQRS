using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using HindalcoBackend.Business;
using HindalcoBackend.Business.AppDbContext;
using HindalcoBackend.Domain.Interface;
using HindalcoBackend.Application.DataModels;
using ITokenGenerator = HindalcoBackend.Domain.Interface.ITokenGenerator;

namespace HindalcoBackend.Application.Models
{
    public class TokenGenerator
    {
        public class Query : IRequest<HindalcoBackend.Domain.DomainModels.AuthModels.AuthRefreshToken> { }
        public class AuthQuery : IRequest<HindalcoBackend.Domain.DomainModels.AuthModels.AuthRefreshToken> { }
        public class ValidateJwtQuery : IRequest<HttpResponseMessage>
        {
            public string? Token { get; set; }
        }
        public class GetAuditCalendar : IRequest<HindalcoBackend.Domain.DomainModels.DataModels.AuditCalendar> {
            public int Id { get; set; }
            public string? token { get; set; }
        }

        public class GetAllAuditCalendar : IRequest<IList<HindalcoBackend.Domain.DomainModels.DataModels.AuditCalendar>>
        {
            public string? Token { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, HindalcoBackend.Domain.DomainModels.AuthModels.AuthRefreshToken>
        {
            private readonly HindalcoBackend.Domain.Interface.ITokenGenerator _tokenService;
            private readonly HindalcoBackend.Domain.Interface.IAuditMapper _auditService;

            private HindalcoBackend.Business.UserModel umodel { get; }
            private HindalcoBackend.Business.AuthRefreshToken _authToken { get; }
            public QueryHandler(ITokenGenerator tokenGenerator)
            {
                _tokenService = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator), "Token generator cannot be null.");
            }
            public async Task<HindalcoBackend.Business.ResponseToken> Handle(Query request,CancellationToken cancellationToken)
            {
                return umodel == null
                ? throw new InvalidOperationException("User model is null, cannot generate token.")
                : await _tokenService.Generatetoken(umodel);
            }
            public async Task<HindalcoBackend.Business.ResponseToken> Handle(AuthQuery request, CancellationToken cancellationToken)
            {
                return _authToken == null
                ? throw new InvalidOperationException("Auth Token is null, cannot renew token.")
                : await _tokenService.GetRenewedToken(_authToken);
            }
            public async Task<int> Handle(ValidateJwtQuery request, CancellationToken cancellationToken)
            {
                return request.Token == null
                ? throw new InvalidOperationException("Requested Token is null, cannot validate token.")
                : await _tokenService.ValidateJwttoken(request.Token);
            }

            public async Task<HindalcoBackend.Business.AuditCalendar> Handle(GetAuditCalendar request, CancellationToken cancellationToken)
            {
                if (request.Id == null)
                {
                    throw new InvalidOperationException("Requested Id is null, cannot validate token.");
                }

                if (request.token == null)
                {
                    throw new InvalidOperationException("Requested Token is null, cannot validate request.");
                }

                return await _auditService.GetAuditById(request.Id, request.token);
            }

            public async Task<IList<HindalcoBackend.Business.AuditCalendar>> Handle(GetAllAuditCalendar request, CancellationToken cancellationToken)
            {
               if (request.Token == null)
                {
                    throw new InvalidOperationException("Requested Token is null, cannot validate request.");
                }

                return await _auditService.GetAllAuditCalendar(request.Token);
            }

            Task<Domain.DomainModels.AuthModels.AuthRefreshToken> IRequestHandler<Query, Domain.DomainModels.AuthModels.AuthRefreshToken>.Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
