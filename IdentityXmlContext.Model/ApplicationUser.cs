using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityXmlContext.Model
{
    public class ApplicationUser
    {
      
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
