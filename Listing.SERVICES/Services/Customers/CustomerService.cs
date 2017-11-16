using Listing1.SERVICES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listing1.VIEWMODEL;
using AutoMapper;
using Listing1.ENTITIES.Model;
using Listing1.DATA.Repositories;
using Listing1.DATA.Infrastructure;
using System.Web.Http.Cors;
using Listing1.SERVICES.Abstract.Customer;

namespace Listing1.SERVICES.Services.Customers
{

    /// <summary>
    /// AddStudent Service
    /// </summary>
    /// <seealso cref="IAddStudentService" />

    
    public class CustomerService : ICustomerService
    {
        private readonly IEntityBaseRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="CustomerRepository"></param>
        /// <param name="unitOfWork"></param>

        public CustomerService(
          IEntityBaseRepository<Customer> customerRepository,
          IUnitOfWork unitOfWork
          )
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }



        /// <summary>
        ///  Adds the class
        /// </summary>
        /// <param name="CustomerModel"></param>
        /// <returns></returns>

        public int AddCustomer(CustomerViewModel addCustomerModel)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, Customer>();
            });
            var customerData = Mapper.Map<CustomerViewModel, Customer>(addCustomerModel);

            _customerRepository.Add(customerData);
            _unitOfWork.Commit();

            return 1;
        }



        /// <summary>
        /// Get all s
        /// </summary>
        /// <returns></returns>

        public List<CustomerViewModel> GetAllCustomerWithoutParam()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, Customer>();
            });

            try
            {
                var customerdata = _customerRepository.GetAll().ToList();
                var customerModelData = Mapper.Map<List<Customer>, List<CustomerViewModel>>(customerdata);
                return customerModelData;
            }
            catch (Exception e)
            {
                throw e;
            }


        }



        /// <summary>
        /// Gets the Customer by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public CustomerViewModel GetCustomerById(long id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, Customer>();
            });
            try
            {
                var customerByIdData = _customerRepository.GetSingle(id);
                var customerModelData = Mapper.Map<Customer, CustomerViewModel>(customerByIdData);
                return customerModelData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Shubham..
        //Latest added
        /// <summary>
        /// Update the customer by Identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCustomerModel"></param>
        /// <returns></returns>

        public int UpdateCustomer(long id, CustomerViewModel updateCustomerModel)
        {
            try
            {

                var user = _customerRepository.GetAll().SingleOrDefault(c => c.Id == id);

                if (user == null)
                {
                    return 0;
                }
                else
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<Customer, CustomerViewModel>();
                        cfg.CreateMap<CustomerViewModel, Customer>();
                    });
                    var Data = Mapper.Map<CustomerViewModel, Customer>(updateCustomerModel);
                    Data.IsDeleted = false;
                    Data.Id = user.Id;

                    _customerRepository.Edit(user, Data); ;

                    _unitOfWork.Commit();
                    return 1;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// Delete the customer by Identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int DeleteCustomer(long id)
        {
            //try
            //{
                var customerDetails = _customerRepository.FindBy(m => m.Id == id && m.IsDeleted == false).FirstOrDefault();
                if (customerDetails != null)
                    customerDetails.IsDeleted = true;
                _unitOfWork.Commit();
                return 1;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
    }
}
