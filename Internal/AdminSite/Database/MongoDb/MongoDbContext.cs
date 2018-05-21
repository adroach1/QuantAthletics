using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using QA.Core.Model.Users;
using System;

namespace AdminSite.Database.MongoDb
{
    public class MongoDbContext
    {
            public IMongoDatabase Database { get; private set; }
            public MongoDbContext(string connectionString = null, string databaseName = null)
            {
                var client = new MongoClient(connectionString);
                Database = client.GetDatabase(databaseName);
                AddMappings();
            }



        private void AddMappings()
        {
            BsonClassMap.RegisterClassMap<User>(u =>
            {
                u.AutoMap();
                u.MapIdMember(m => m.Username);
            });

            //BsonClassMap.RegisterClassMap<AthleteProfile>(ap =>
            //{
            //    ap.AutoMap();
            //    ap.MapIdMember(m => m.Guid);
            //});
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            var typeName = typeof(T).Name;
            return Database.GetCollection<T>(typeName);
        }
        public IMongoCollection<User> Users { get { return Database.GetCollection<User>("Users"); } }
        public IMongoCollection<AthleteAccount> AthleteProfile { get { return Database.GetCollection<AthleteAccount>("AthleteProfile"); } }
    }
}


//Add Mapping Samples
//DateTimeSerializationOptions.Defaults = DateTimeSerializationOptions.LocalInstance;
//BsonClassMap.RegisterClassMap<RaceFestival>(cm =>
//{
//    cm.AutoMap();
//    cm.MapIdMember(rf => rf.Id).SetRepresentation(BsonType.ObjectId);
//    cm.MapMember(rf => rf.EventStartDate).SetSerializer(new DateTimeSerializer(DateTimeSerializationOptions.LocalInstance));
//});


//BsonClassMap.RegisterClassMap<RaceLink>(cm =>
//{
//    cm.AutoMap();
//    cm.SetDiscriminatorIsRequired(true);
//});
//BsonClassMap.RegisterClassMap<ActiveRaceLink>();
//BsonClassMap.RegisterClassMap<OrganizerRaceLink>();
//BsonClassMap.RegisterClassMap<RegistrationRaceLink>();
//BsonClassMap.RegisterClassMap<RaceLocationLink>();

//BsonClassMap.RegisterClassMap<Location>(cm =>
//{
//    cm.AutoMap();
//    cm.MapProperty(l => l.Geo);
//    cm.MapProperty(l => l.GeoArray);
//});

//[Test()]
//public void LoadToMongoFromSourceSqlTest()
//{
//    var bsonDirectory = @"c:\data\races\bson";
//    var repoBson = new BsonLoadRaceFestivalsRepository(bsonDirectory);
//    var brfs = repoBson.GetAllRaceFestivals(new RaceFestivalSearch()).ToList();
//    var db = new RunningMongoContext();
//    db.RaceFestivals.Drop();
//    var repoMongo = new MongoRaceFestivalRepository(db);
//    brfs.ToList().ForEach(rf => rf.Id = ObjectId.GenerateNewId());
//    repoMongo.SaveRaceFestivals(brfs);
//    var mrf = repoMongo.GetAllRaceFestivals(new RaceFestivalSearch());
//    Assert.AreEqual(mrf.Count(), brfs.Count());
//}