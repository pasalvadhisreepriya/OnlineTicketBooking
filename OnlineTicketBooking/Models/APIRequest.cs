﻿using System.Security.AccessControl;

namespace OnlineTicketBookingWeb.Models
{
    public class APIRequest
    {
        
            public string ApiType { get; set; } = "GET";
            public string Url { get; set; }
            public object Data { get; set; }
       
    }
}
