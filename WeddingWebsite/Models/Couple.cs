using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class Couple
    {
        public int Id { get; set; }

        public Guest GuestOne { get; set; }

        public int GuestOneId { get; set; }

        public Guest GuestTwo { get; set; }

        public int GuestTwoId { get; set; }

        public string CoupleTag
        {
            get { return CoupleTag; }
            set { CoupleTag = GuestOne.FirstName + " " + GuestOne.LastName + " & " + GuestTwo.FirstName + " " + GuestTwo.LastName; }
        }
    }
}
