using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
    public class Guest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }
    }
}
