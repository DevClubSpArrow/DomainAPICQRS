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
        Task<HindalcoBackend.Domain.DomainModels.AuthModels.AuthRefreshToken> Generatetoken(UserModel umodel);
        Task<HindalcoBackend.Domain.DomainModels.AuthModels.AuthRefreshToken> GetRenewedToken(AuthRefreshToken refToken);
        Task<HttpResponseMessage> ValidateJwttoken(string token);
    }
    public  interface IAuditMapper
    {
        Task<int> SaveAudit(AuditCalendar auditCal, string token);
        Task<IList<HindalcoBackend.Domain.DomainModels.DataModels.AuditCalendar>> GetAllAuditCalendar(string token);
        Task<HindalcoBackend.Domain.DomainModels.DataModels.AuditCalendar> GetAuditById(int id, string token);
        Task<bool> UpdateAuditCalendar(int AuditCalendarId, AuditCalendar auditCal, string token);
    }
}
