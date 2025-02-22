using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebBookingApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}