using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Service.IService
{
    public interface ICustomerService
    {
       // Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel);

        Task<T> RegisterAsync<T>(CustomerViewModel customerViewModel);
        Task<T> Getbyid<T>(string Email);

    }
}
