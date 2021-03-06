﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class SongRequest
    {
        public int Id { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        public string SongTitle { get; set; }

        public string SongArtist { get; set; }

        public int RSVPId { get; set; }
    }
}
