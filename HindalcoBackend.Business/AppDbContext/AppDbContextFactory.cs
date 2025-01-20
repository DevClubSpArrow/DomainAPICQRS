using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Business.AppDbContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<appDBontext>
    {
        public appDBontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<appDBontext>();
            var connectionString = "Server=mysql.db.sparrowios.com;Database=testDB;User=arvind;Password=gdhrufhs%$2&!!;Persist Security Info=False;Connect Timeout=300;";
            optionsBuilder.UseMySql(connectionString.ToString(), ServerVersion.AutoDetect(connectionString));
            return new appDBontext(optionsBuilder.Options);
        }
    }
}
