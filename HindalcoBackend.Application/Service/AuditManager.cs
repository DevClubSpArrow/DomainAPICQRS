using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HindalcoBackend.Application.DataModels;
using HindalcoBackend.Business.AppModels.DataModels;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HindalcoBackend.Domain.Interface;
using System.ComponentModel.Design.Serialization;
using System.Transactions;
using HindalcoBackend.Application.Interface;
using MediatR;
using HindalcoBackend.Business;
using static HindalcoBackend.Application.Queries.TokenQuery;
using HindalcoBackend.Application.Command;


namespace HindalcoBackend.Application.Service
{
    public  class AuditManager: IBusiness
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuditManager> _logger;
        private int responseRet { get; set; }= 0;
        public AuditManager(IMediator mediator,ILogger<AuditManager> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        async Task<HindalcoBackend.Domain.ResponseToken> IBusiness.Generatetoken(HindalcoBackend.Domain.DomainModels.DataModels.UserModel umodel)
        {
           return await _mediator.Send(new GetToken(umodel));
        }
    }
}
