using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class RSVP
    {
        public int Id { get; set; }

        public Guest GuestOne { get; set; }

        public Guest GuestTwo { get; set; }

        public bool GuestOneAccepts { get; set; }

        public bool GuestTwoAccepts { get; set; }

        public DateTime TimeOfArrival { get; set; }

        public IEnumerable<SongRequest> SongRequests { get; set; }

        public string MarriageAdvice { get; set; }
    }
}
