using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class DrinkRequest
    {
        public int Id { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        public int SpecialtyDrinkModelId { get; set; }

        public SpecialtyDrinkModel SpecialtyDrinkModel { get; set; }
    }
}
