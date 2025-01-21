using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using HindalcoBackend.Business;

namespace HindalcoBackend.Business
{
    public class appDBontext : DbContext
    {
        public appDBontext(DbContextOptions<appDBontext> options)
      : base(options) { }
     //   public DbSet<AuditArea> tbl_auditarea => Set<AuditArea>();
        public DbSet<HindalcoBackend.Business.AuthRefreshToken> tbl_RefreshTokens => Set<HindalcoBackend.Business.AuthRefreshToken>();
        public DbSet<HindalcoBackend.Business.UserModel> tbl_usermodel => Set<HindalcoBackend.Business.UserModel>();
        public DbSet<HindalcoBackend.Business.AuditCalendar> tbl_auditcalendar => Set<HindalcoBackend.Business.AuditCalendar>();
        public DbSet<AuditAssigned> tbl_auditassigned => Set<AuditAssigned>();
        public DbSet<AuditAssignee> tbl_auditassignee => Set<AuditAssignee>();
        public DbSet<AuditeeCAPA> tbl_auditcapa => Set<AuditeeCAPA>();
        public DbSet<AuditorFindings> tbl_auditorfindings => Set<AuditorFindings>();
        public DbSet<AuditCategory> tbl_auditcategory => Set<AuditCategory>();
        public DbSet<AuditPlan> tbl_auditplan => Set<AuditPlan>();
        public DbSet<AuditCommitee> tbl_auditcommittee => Set<AuditCommitee>();
        public DbSet<AuditArea> tbl_auditarea => Set<AuditArea>();
        public DbSet<AuditExecutionPlan> tbl_auditexecutionplan => Set<AuditExecutionPlan>();
        public DbSet<DepartmentMaster> tbl_department_master => Set<DepartmentMaster>();
        public DbSet<AuditMaster> tbl_auditmaster => Set<AuditMaster>();
        public DbSet<OperationUnit> tbl_operationunit => Set<OperationUnit>();
        public DbSet<AuditManagement> tbl_auditmanagement => Set<AuditManagement>();
        public DbSet<AuditManagementDetails> tbl_auditmanagementdetails => Set<AuditManagementDetails>();
        public DbSet<AuditCalendarHistory> tbl_auditcalendarhistory => Set<AuditCalendarHistory>();
        public DbSet<AuditCalendarL2History> tbl_auditcalendarl2history => Set<AuditCalendarL2History>();
        public DbSet<AuditManagementHistory> tbl_auditmangementhistory => Set<AuditManagementHistory>();
        public DbSet<AuditPlanHistory> tbl_auditplanhistory => Set<AuditPlanHistory>();
    }
}
