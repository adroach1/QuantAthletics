using QA.Core.ModelServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QA.Core.Model.Users
{

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastModified { get; set; }
        public string TempSessionId { get; set; }
        public Collection<AthleteAccount> AthleteAccounts { get; set; }
    }
}
