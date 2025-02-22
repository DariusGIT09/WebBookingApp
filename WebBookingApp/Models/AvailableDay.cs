using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookingApp.Models
{
    public class AvailableDay
    {
        public int Id { get; set; }      // Primary Key

        public int RoomId { get; set; }  // Relație cu Room

        [ForeignKey("RoomId")]
        public Room Room { get; set; }   // Obiectul Room asociat

        public DateTime Date { get; set; }  // Data disponibilă
    }
}