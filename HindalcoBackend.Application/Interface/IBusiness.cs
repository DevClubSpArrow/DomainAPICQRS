using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoBackend.Application.Interface
{
    public  interface IBusiness
    {
        Task<HindalcoBackend.Business.ResponseToken> Generatetoken(HindalcoBackend.Business.UserModel umodel);
    }
}
