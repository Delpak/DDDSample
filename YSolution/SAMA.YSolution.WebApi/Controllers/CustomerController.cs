using System;
using System.Web.Http;
using SAMA.YSolution.ApplicationService;

namespace SAMA.YSolution.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public Response<CustomerDto> Add([FromUri] CustomerDto customer)
        {
            var response = new Response<CustomerDto>();
            try
            {
                response.Object = _customerService.Add(customer);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpGet]
        public Response<bool> IsEmailAvailable(string email)
        {
            var response = new Response<bool>();
            try
            {
                response.Object = _customerService.IsEmailAvailable(email);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpGet]
        public Response<CustomerDto> GetById(Guid id)
        {
            var response = new Response<CustomerDto>();
            try
            {
                response.Object = _customerService.Get(id);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpGet]
        public Response RemoveById(Guid id)
        {
            var response = new Response();
            try
            {
                _customerService.Remove(id);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        [HttpGet]
        public Response Update([FromUri] CustomerDto customer)
        {
            var response = new Response();
            try
            {
                _customerService.Update(customer);
            }
            catch (Exception ex)
            {
                //log error
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}