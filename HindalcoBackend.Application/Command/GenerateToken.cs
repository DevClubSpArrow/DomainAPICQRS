using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Application.Command
{
    public record GetToken(HindalcoBackend.Domain.DomainModels.DataModels.UserModel umodel) :IRequest<HindalcoBackend.Domain.ResponseToken>;
}
