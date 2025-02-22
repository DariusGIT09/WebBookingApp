using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebBookingApp.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}