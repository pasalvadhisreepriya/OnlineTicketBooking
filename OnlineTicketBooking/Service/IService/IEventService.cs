

using OnlineTicketBookingWeb.Models;

namespace OnlineTicketBookingWeb.Service.IService
{
    public interface IEventService
    {
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(EventViewModel eventViewModel);
        Task<T> UpdateAsync<T>(EventViewModel eventViewModel);
        Task<T> Getbyid<T>(int id);   
        Task<T> DeleteAsync<T>(int id);
    }
}
