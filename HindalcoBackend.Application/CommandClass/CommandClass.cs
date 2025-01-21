using Azure.Core;
using HindalcoBackend.Business;
using HindalcoBackend.Domain.DomainModels.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HindalcoBackend.Application.CommandClass
{
    public  class CommandClass
    {
        #region "API Request with payload, props"
        public class SaveAudit : IRequest<int>
        {
            public AuditCalendar? auditCalendar { get; set; }
            public string? Token { get; }
        }

        public class UpdateAudit: IRequest<bool>
        {
            public int  AuditCalendarId { get; }
            [Required]
            public AuditCalendar? auditCal { get; }
            [Required]
            public string? token { get; } 
        }

        #endregion "API Request with payload, props"

        #region "command handler and Dbcontext"
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

            public async Task<bool> Handle(UpdateAudit requestBody, CancellationToken cancellationToken)
            {
                // Fetch the existing product
                var _existAudit = await _auditService.GetAuditById(requestBody.AuditCalendarId,requestBody.token);
                if (_existAudit == null)
                {
                    return false; // Product not found
                }

                // Update the fields only if they have values
                // Update fields dynamically
                UpdateIfNotNull(requestBody.auditCal.AreaCode, value => _existAudit.AreaCode = value);
                UpdateIfNotNull(requestBody.auditCal.AuditType, value => _existAudit.AuditType = value);
                UpdateIfNotNull(requestBody.auditCal.AuditCategory, value => _existAudit.AuditCategory = value);
                UpdateIfNotNull(requestBody.auditCal.DocumentedBy, value => _existAudit.DocumentedBy = value);
                UpdateIfNotNull(requestBody.auditCal.AuditName, value => _existAudit.AuditName = value);

                // update changes
                return await _auditService.UpdateAuditCalendar(requestBody.AuditCalendarId, _existAudit,requestBody.token);
            }

            #endregion "command handler and Dbcontext"

            #region "update handdler function"
            private void UpdateIfNotNull<T>(T? value, Action<T> updateAction) where T : class
            {
                if (value != null)
                {
                    updateAction(value);
                }
            }

            // Overload for value types
            private void UpdateIfNotNull<T>(T? value, Action<T> updateAction) where T : struct
            {
                if (value.HasValue)
                {
                    updateAction(value.Value);
                }
            }

            #endregion "update handdler function"
        }
    }
}
