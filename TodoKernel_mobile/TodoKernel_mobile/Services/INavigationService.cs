using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoKernel_mobile.Services
{
    interface INavigationService
    {
        Task ToMainpage();
        Task ToAuthentication();
    }
}
