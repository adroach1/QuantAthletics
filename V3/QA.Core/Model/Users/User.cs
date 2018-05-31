using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QA.Core.Model.Users
{
    public class User
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public string EmailAddress { get; set; }
        public Collection<AthleteProfile> AthleteProfiles { get; set; }
    }
}
