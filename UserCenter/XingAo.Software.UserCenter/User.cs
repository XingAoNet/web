using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XingAo.Software.UserCenter
{
    public class User
    {
        public string Id { get; set; }
        
        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime RegDate { get; set; }

        public string RegIP { get; set; }

        public DateTime LastLoginDate { get; set; }

        public string LastLoginIP { get; set; }
    }
}
