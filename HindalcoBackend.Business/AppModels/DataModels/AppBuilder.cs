using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Business.AppModels.DataModels
{
    public static  class AppBuilder
    {
        public static string? Issuer { get; set; }
        public static string? Audiences { get; set; }
        public static string? Key { get; set; } 
        public static int RefreshTokenValidity { get; set; }
        public static string? KeyText { get; set; }
        public static string? appBaseURL { get; set; }
    }
}
