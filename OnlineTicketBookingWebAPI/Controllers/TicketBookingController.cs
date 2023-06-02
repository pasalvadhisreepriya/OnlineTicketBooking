﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingDataAccess.Data;
using OnlineTicketBookingDataAccess.Migrations;
using OnlineTicketBookingDataAccess.Models;
using OnlineTicketBookingDataAccess.Repository;
using OnlineTicketBookingDataAccess.Repository.IRepository;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TicketBookingController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ITicketBookingRepository _ticketBookingRepository;
        private readonly IEventRepository _eventRepository;
        protected ApiResponse _response;

        public TicketBookingController(DatabaseContext databaseContext, ITicketBookingRepository ticketBookingRepository,IEventRepository eventRepository)
        {
            _databaseContext=databaseContext;
            _ticketBookingRepository=ticketBookingRepository;
            _eventRepository=eventRepository;
            this._response = new ApiResponse();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _ticketBookingRepository.Get();
          result=  result.Where(x => x.ApprovedStatus=="Pending");
            _response.Result=result;
            return Ok(_response);

        }

        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
            var data = _databaseContext.TicketBookings.Find(id);
            _response.Result=data;
            return Ok(_response);
        }


        [HttpPost]
        public IActionResult Create(TicketBooking ticketBooking)
        {
            ticketBooking.ApprovedStatus="Pending";
            _ticketBookingRepository.Create(ticketBooking);
            _ticketBookingRepository.Save();
            var eventdata = _databaseContext.Events.Find(ticketBooking.EventId);
            eventdata.AvailableSeats=eventdata.AvailableSeats-ticketBooking.NumberOfTickets;
            _eventRepository.Update(eventdata);
            _eventRepository.Save();
            return Ok();
        }
        [HttpPut]
    
        public IActionResult Update(TicketBooking ticketBooking)
        {
            _ticketBookingRepository.Update(ticketBooking);
            _ticketBookingRepository.Save();
            return Ok();
        }

        [HttpPut("Approve/{id:int}")]
        public IActionResult Updatebyid(int id)
        {
            var data = _databaseContext.TicketBookings.Find(id);
           
            data.ApprovedStatus="Approved";
            _ticketBookingRepository.Update(data);
            _ticketBookingRepository.Save();
            return Ok();
           

        }

        [HttpPut("Reject/{id:int}")]
        public IActionResult UpdatebyidReject(int id)
        {
            var data = _databaseContext.TicketBookings.Find(id);
            var eventdata = _databaseContext.Events.Find(data.EventId);
            eventdata.AvailableSeats=eventdata.AvailableSeats+data.NumberOfTickets;
            _eventRepository.Update(eventdata);
            _eventRepository.Save();
            data.ApprovedStatus="Rejected";
            _ticketBookingRepository.Update(data);
            _ticketBookingRepository.Save();
            return Ok();


        }



        [HttpDelete("{id:int}")]
      
        public IActionResult Delete(int id)
        {
            _ticketBookingRepository.Delete(id);
            _ticketBookingRepository.Save();
            return Ok();
        }
    }
}
