using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingWebsite.Models;

namespace WeddingWebsite.Dtos
{
    public class CoupleDto
    {
        public int Id { get; set; }

        public GuestDto GuestOne { get; set; }

        public int GuestOneId { get; set; }

        public GuestDto GuestTwo { get; set; }

        public int GuestTwoId { get; set; }
    }
}
