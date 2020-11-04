using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Models;

namespace WeddingWebsite.ViewModels
{
    public class InvitationViewModel
    {
        public RSVP RSVP { get; set; }
        
        public List<SpecialtyDrinkModel> DrinkItems { get; set; }
    }
}
