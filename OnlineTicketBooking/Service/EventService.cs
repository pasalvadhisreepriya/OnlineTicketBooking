using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using OnlineTicketBookingWeb.Models;
using OnlineTicketBookingWeb.Service.IService;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace OnlineTicketBookingWeb.Service
{
    public class EventService : BaseService,IEventService
    {
        private readonly IHttpClientFactory _clientFactory;

        private string TicketBookingUrl;
        public EventService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            TicketBookingUrl = configuration.GetValue<string>("ServiceUrls:BookTicket");

        }

        public Task<T> CreateAsync<T>(EventViewModel eventViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                Data=eventViewModel,
                Url = TicketBookingUrl + "/api/Event",

                ApiType = "Post",

            });
           // return Task.FromResult(data);
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                 
                Url = TicketBookingUrl + "/api/Event/"+id,

                ApiType = "Delete",


            });
          //  return data;
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
          
                Url = TicketBookingUrl + "/api/Event",

               ApiType = "GET",
               

            });
         // List<EventViewModel> list= JsonConvert.DeserializeObject<List<EventViewModel>>(Convert.ToString(data));
           // return data;
        }

        public Task<T> Getbyid<T>(int id)
        {

            return SendAsync<T>(new APIRequest()
            {
                Url = TicketBookingUrl + "/api/Event/"+id,
                ApiType = "GET",


            });
        }

        public Task<T> UpdateAsync<T>(EventViewModel eventViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                Data=eventViewModel,
                Url = TicketBookingUrl + "/api/Event",

                ApiType = "Put",


            });
          //  return Task.FromResult(data);
        }
    }
}
