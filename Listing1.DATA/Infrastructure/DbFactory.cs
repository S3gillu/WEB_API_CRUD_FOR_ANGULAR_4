using Listing1.DATA;
using Listing1.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1.DATA.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CustomerContext customerContext;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public CustomerContext Init()
        {
            return customerContext ?? (customerContext = new CustomerContext());
        }

        protected override void DisposeCore()
        {
            customerContext?.Dispose();
        }
    }
}
