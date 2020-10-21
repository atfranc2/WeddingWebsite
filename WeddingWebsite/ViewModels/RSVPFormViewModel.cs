using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.ViewModels
{
    public class RSVPFormViewModel
    {
        public int GuestOneId { get; set; }

        public string GuestOneName { get; set; }
        
        public int? GuestTwoId { get; set; }

        public string GuestTwoName { get; set; }

        public string CoupleTag { get; set; }
    }
}
