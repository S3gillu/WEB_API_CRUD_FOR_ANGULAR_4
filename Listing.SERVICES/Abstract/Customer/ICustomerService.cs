using Listing1.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1.SERVICES.Abstract.Customer
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets the Customer by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerViewModel GetCustomerById(long id);


        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        List<CustomerViewModel> GetAllCustomerWithoutParam();


        /// <summary>
        ///  Adds the Customer
        /// </summary>
        /// <param name="addCustomerModel"></param>
        /// <returns></returns>
        int AddCustomer(CustomerViewModel addCustomerModel);


        /// <summary>
        /// Update the Customer details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCustomerModel"></param>
        /// <returns></returns>
        int UpdateCustomer(long id, CustomerViewModel updateCustomerModel);


        /// <summary>
        /// Delete the Customer by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteCustomer(long id);
    }
}
