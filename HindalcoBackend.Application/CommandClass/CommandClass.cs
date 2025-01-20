using Azure.Core;
using HindalcoBackend.Business;
using HindalcoBackend.Domain.DomainModels.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HindalcoBackend.Application.CommandClass
{
    public  class CommandClass
    {
        public class SaveAudit : IRequest<int> {
        
        public AuditCalendar? auditCalendar { get; set; }
         public string? Token { get; }
        }
        public class CommandHandler : IRequestHandler<SaveAudit,int>
        {
            private readonly appDBontext _dbContext;
            public CommandHandler(appDBontext dbContext)
            {
                _dbContext = dbContext;
            }
            private readonly HindalcoBackend.Domain.Interface.IAuditMapper _auditService;
            public async Task<int> Handle(SaveAudit command, CancellationToken cancellationToken)
            {

                if (command.auditCalendar == null)
                {
                    throw new InvalidOperationException("Empty data is posted, cannot validate.");
                }

                if (command.Token == null)
                {
                    throw new InvalidOperationException("Requested Token is null, cannot validate request.");
                }
                var auditcal = new AuditCalendar
                {
                   AuditStart=command.auditCalendar.AuditStart,
                   AuditCategory=command.auditCalendar.AuditCategory,
                   AuditName=command.auditCalendar.AuditName,
                   AuditType=command.auditCalendar.AuditType,
                   ExpectedDate=command.auditCalendar.ExpectedDate,
                   AreaCode=command.auditCalendar.AreaCode,
                   DeptId=command.auditCalendar.DeptId,
                   DocumentDate=command.auditCalendar.DocumentDate,
                   DocumentedBy=command.auditCalendar.DocumentedBy,

                };
                return await _auditService.SaveAudit(auditcal,command.Token);
            }
        }
    }
}
