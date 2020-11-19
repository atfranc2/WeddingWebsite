using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Models;

namespace WeddingWebsite.Dtos
{
    public class RSVPDto
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

        public string DayOfArrival { get; set; }

        public string TimeOfArrival { get; set; }

        public string MarriageAdvice { get; set; }

        public IEnumerable<SongRequest> SongRequests { get; set; }

        public IEnumerable<DrinkRequest> DrinkRequests { get; set; }
    }
}
