﻿namespace API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ReviewerId { get; set; }
        public int Rating { get; set; } // سيتم تطبيق القيد في DbContext
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Booking Booking { get; set; }
        public virtual User Reviewer { get; set; }
    }
}
