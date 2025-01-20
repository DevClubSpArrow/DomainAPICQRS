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
    }
}
