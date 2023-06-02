using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingWeb.Service.IService;

namespace OnlineTicketBookingWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService=customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
