using HindalcoBackend.Business;
using HindalcoBackend.Domain.DomainModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Domain.Interface
{
    public interface ITokenGenerator
    {
       public Task<HindalcoBackend.Business.ResponseToken> Generatetoken(HindalcoBackend.Business.UserModel umodel);
       public Task<HindalcoBackend.Business.ResponseToken> GetRenewedToken(AuthRefreshToken refToken);
       public Task<int> ValidateJwttoken(string token);
    }
    public  interface IAuditMapper
    {
       public Task<int> SaveAudit(HindalcoBackend.Business. AuditCalendar auditCal, string token);
       public  Task<IList<HindalcoBackend.Business.AuditCalendar>> GetAllAuditCalendar(string token);
       public Task<HindalcoBackend.Business.AuditCalendar> GetAuditById(int id, string token);
       public Task<bool> UpdateAuditCalendar(int AuditCalendarId, HindalcoBackend.Business.AuditCalendar auditCal, string token);
       public Task<int> ValidateInputtoken(string inputToken);

    }
}
