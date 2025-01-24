using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Application.Queries
{
    public class TokenQuery
    {
        public record GenerateTokenQuery(): IRequest<Business.ResponseToken>;
    }
}
