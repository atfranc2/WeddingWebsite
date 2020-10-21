using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class RSVP
    {
        public int Id { get; set; }

        [Required]
        public Guest GuestOne { get; set; }

        public int GuestOneId { get; set; }

        public Guest GuestTwo { get; set; }

        public int GuestTwoId { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public bool GuestOneAccepts { get; set; }

        public bool GuestTwoAccepts { get; set; }

        [Required]
        public DateTime TimeOfArrival { get; set; }

        public IEnumerable<SongRequest> SongRequests { get; set; }

        public string MarriageAdvice { get; set; }
    }
}
