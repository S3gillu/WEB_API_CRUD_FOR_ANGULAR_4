using Listing1.SERVICES.Abstract.Customer;
using Listing1.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Listing1.WEB.Controllers.Customer
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    /// <summary>
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _iCustomerService;

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomersController" /> class.
        /// </summary>
        /// <param name="iAddCustomerService"></param>

        public CustomerController(ICustomerService iAddCustomerService)
        {
            _iCustomerService = iAddCustomerService;
        }




        /// <summary>
        /// Get all the customer data from databse
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllCustomer")]
        public HttpResponseMessage GetAllCustomer()
        {
            var resultData = _iCustomerService.GetAllCustomerWithoutParam();

            return Request.CreateResponse(HttpStatusCode.OK, resultData);
        }




        /// <summary>
        /// Get the particular customer data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public HttpResponseMessage GetCustomerById(long id)
        {
            var resultData = _iCustomerService.GetCustomerById(id);
            return Request.CreateResponse(HttpStatusCode.OK, resultData);
        }



        /// <summary>
        /// Save the customer data into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        //[Authorize]
        // POST: api/Home
        [Route("AddCustomer")]
        [HttpPost]
        public int AddCustomer([FromBody] CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            else
            {
                return _iCustomerService.AddCustomer(model);
            }

        }



        /// <summary>
        /// update the customer data and save it into database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [Route("UpdateCustomer/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateCustomer(long id, [FromBody] CustomerViewModel model)
        {
            try
            {
                var response = new ResponseViewModel();

                if (!ModelState.IsValid)
                {

                    response.IsSuccess = false;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
                else
                {
                    response.IsSuccess = true;
                    var returnData = _iCustomerService.UpdateCustomer(id, model);

                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }

            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Delete the Customer by Identifier
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("DeleteCustomerById/{id}")]
        public HttpResponseMessage DeleteCustomerById(long Id)
        {
            var response = new ResponseViewModel();

            var returnData = _iCustomerService.DeleteCustomer(Id);

            switch (returnData)
            {
                case 0:
                    response.IsSuccess = false;
                    break;
                case 1:
                    response.IsSuccess = true;
                    break;
                default:
                    response.IsSuccess = false;
                    response.Message = "Please try again..";
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}