using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public DateTime BookingDate { get; set; }
    }
}