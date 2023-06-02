namespace OnlineTicketBookingDataAccess.Models
{
    public class LoginResponse
    {
        public Customer Customer { get; set; }
       
        public string Token { get; set; } 
    }
}
