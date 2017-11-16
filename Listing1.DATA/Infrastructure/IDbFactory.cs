using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Listing1.DATA.Infrastructure
{
    public interface IDbFactory : IDisposable
    {

        CustomerContext Init();
    }
}