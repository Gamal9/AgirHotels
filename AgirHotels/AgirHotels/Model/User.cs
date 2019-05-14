using System;
using System.Collections.Generic;
using System.Text;

namespace AgirHotels.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string email_verified_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
