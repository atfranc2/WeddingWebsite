using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Models;

namespace WeddingWebsite.ViewModels
{
    public class EditRSVPViewModel
    {
        public RSVP RSVP { get; set; }

        public IEnumerable<int> SelectedDrinkRequests { get; set; }
        public IEnumerable<SpecialtyDrinkModel> DrinkRequests { get; set; }

        public IEnumerable<SongRequest> SongRequests { get; set; }
    }
}
