using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Service.IService
{
    public interface IBaseService
    {
          APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
