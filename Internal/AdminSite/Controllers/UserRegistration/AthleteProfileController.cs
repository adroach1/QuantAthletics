using MongoDB.Driver;
using QA.Core.Model.Users;
using System.Linq;
using System.Web.Http;

namespace AdminSite.Controllers
{

    public class AthleteAccountController: ApiController
    {
        private IMongoCollection<AthleteAccount> _apCollection;
        public AthleteAccountController (IMongoCollection<AthleteAccount> athleteProfileCollection)
        {
            _apCollection = athleteProfileCollection;
        }
        public AthleteAccount CreateAthleteProfile(AthleteAccount athleteProfile)
        {
            _apCollection.InsertOne(athleteProfile);
            return athleteProfile;
        }

        public AthleteAccount GetAthleteProfile(object guid)
        {
            var fdb = new FilterDefinitionBuilder<AthleteAccount>();
            var fd = fdb.Where(ap => ap.Id == 1);
            var athleteProfile =_apCollection.Find(fd).SingleOrDefault();
            return athleteProfile ?? AthleteAccount.GetNew();
        }

    }
}
