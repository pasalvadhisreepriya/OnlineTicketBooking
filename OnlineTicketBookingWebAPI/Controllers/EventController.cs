using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingDataAccess.Data;
using OnlineTicketBookingDataAccess.Models;
using OnlineTicketBookingDataAccess.Repository;
using OnlineTicketBookingDataAccess.Repository.IRepository;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EventController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IEventRepository _eventRepository;
        protected ApiResponse _response;

        public EventController(DatabaseContext databaseContext, IEventRepository eventRepository)
        {
            _databaseContext=databaseContext;
            _eventRepository=eventRepository;
            this._response = new ApiResponse();
        }
        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
         var data=   _databaseContext.Events.Find(id);
            _response.Result=data;
            return Ok(_response);
        }
        [HttpGet]
    
        public IActionResult Get() {
            var result = _eventRepository.Get();
            _response.Result=result;
            return Ok(_response);
        }
        [HttpPost]
    
        public IActionResult Create(Event Event)
        {
           
            _eventRepository.Create(Event);
            _eventRepository.Save();
            return Ok();
        }
        [HttpPut]

        public IActionResult Update(Event Event)
        {
            _eventRepository.Update(Event);
            _eventRepository.Save();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        
       
        public IActionResult Delete(int id)
        {
            _eventRepository.Delete(id);
            _eventRepository.Save();
            return Ok();
        }
    }
}
