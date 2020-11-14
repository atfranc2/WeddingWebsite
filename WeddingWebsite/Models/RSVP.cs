using Microsoft.AspNetCore.Mvc.Rendering;
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

        public string GuestOneName { get; set; }

        public int GuestOneId { get; set; }

        public string GuestTwoName { get; set; }

        public int GuestTwoId { get; set; }

        public string GuestTag { get; set; }

        public string ContactEmail { get; set; }

        public bool GuestOneAccepts { get; set; }

        public bool GuestTwoAccepts { get; set; }

        public DateTime DayOfArrival { get; set; }

        public DateTime TimeOfArrival { get; set; }
                
        public string MarriageAdvice { get; set; }

        public IEnumerable<SongRequest> SongRequests { get; set; }

        public IEnumerable<DrinkRequest> DrinkRequests { get; set; }
    }
}
