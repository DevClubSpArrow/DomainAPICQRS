
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

    public class GenerateUserCommand : IRequest<HindalcoBackend.Business.UserModel>
    {
        public string? UserName { get; set; }
        public int Uid { get; set; }
        public string? Password { get; set; } = null;
    }
    public class GenerateUserCommandHandler : IRequestHandler<GenerateUserCommand,HindalcoBackend.Business.UserModel>
    {       
        private readonly IBusiness<HindalcoBackend.Business.UserModel> _business;
        public GenerateUserCommandHandler(IBusiness<HindalcoBackend.Business.UserModel> userModel)
        {
            _business = userModel;
        }
        public async Task<HindalcoBackend.Business.UserModel> Handle(GenerateUserCommand request, CancellationToken cancellationToken)
        {
            var item = new HindalcoBackend.Business.UserModel { UserName = request.UserName,Uid=request.Uid,Password=request.Password };
            return await _business.AddAsync(item);
        }
    }
}

