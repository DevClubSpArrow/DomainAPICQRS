
using HindalcoBackend.Application.Command;
using HindalcoBackend.Application.Interface;
using HindalcoBackend.Business;
using HindalcoBackend.Domain;
using HindalcoBackend.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditCalendar = HindalcoBackend.Domain;

namespace HindalcoBackend.Application.CommandClass
{

    public class GetUser : IRequest<IEnumerable<HindalcoBackend.Business.UserModel>>
    {
        public class GetUserHandler : IRequestHandler<GetUser, IEnumerable<HindalcoBackend.Business.UserModel>>
        {

            #region "API Request with payload, props"
            private readonly IBusiness<HindalcoBackend.Business.UserModel> _business;

            public GetUserHandler(IBusiness<HindalcoBackend.Business.UserModel> business)
            {
                _business = business;
            }
            public async Task<IEnumerable<HindalcoBackend.Business.UserModel>> Handle(GetUser getToken,CancellationToken cancellationToken)
            {
                return await _business.GetallUserAsync();
            }
        }
    }
}
#endregion