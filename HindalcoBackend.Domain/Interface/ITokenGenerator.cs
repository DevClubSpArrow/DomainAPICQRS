using HindalcoBackend.Domain;
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
       Task<HindalcoBackend.Business.ResponseToken> Generatetoken(HindalcoBackend.Business.UserModel umodel);
    //   public Task<HindalcoBackend.Business.ResponseToken> GetRenewedToken(AuthRefreshToken refToken);
    //   public Task<int> ValidateJwttoken(string token);
    }
    public  interface IAuditMapper
    {
       public Task<int> SaveAudit(HindalcoBackend.Domain.AuditCalendar auditCal, string token);
       public  Task<IList<HindalcoBackend.Domain.AuditCalendar>> GetAllAuditCalendar(string token);
       public Task<HindalcoBackend.Domain.AuditCalendar> GetAuditById(int id, string token);
       public Task<bool> UpdateAuditCalendar(int AuditCalendarId, HindalcoBackend.Domain.AuditCalendar auditCal, string token);
       public Task<int> ValidateInputtoken(string inputToken);

    }
}
