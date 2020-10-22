using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Models;

namespace WeddingWebsite.ViewModels
{
    public class GuestConfirmationViewModel
    {
        public List<RSVP> RSVPs { get; set; }

        public IEnumerable<string> GuestTags { get; set; }

        public string GuestTag { get; set; }
    }
}
