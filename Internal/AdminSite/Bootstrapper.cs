using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.Practices.Unity;
using AdminSite.Database.MongoDb;
using MongoDB.Driver;
using QA.Core.Model.Users;
using AdminSite.Database.Sql;
using System.Data.Entity.Infrastructure;
using AdminSite.Settings;

namespace AdminSite
{
    public class Bootstrapper
    {
        public IUnityContainer BuildContainer()
        {
            _container = new UnityContainer();
            _container.RegisterInstance(typeof(IExceptionHandler),new ExceptionHandler());
            InitializeSettings();
            InitializeMongo();
            InitializeEf();
            return _container;
        }
        private IUnityContainer _container;

        private void InitializeSettings()
        {
            var siteSettingsRepository = new AdminSiteSettingsRepository(@"C:\QAConfig\AdminSiteSettings.json");
            siteSettingsRepository.Load();
            _container.RegisterInstance(siteSettingsRepository);
        }

        private void InitializeEf()
        {
            
        }
        public void InitializeMongo()
        {
            var connectionString = "mongodb://localhost";
            var databaseName = "qa";
            var client = new MongoClient(connectionString);
            var mongoDbContext = new MongoDbContext(connectionString, databaseName);
            _container.RegisterInstance(mongoDbContext);
            _container.RegisterType<QaDbContext, QaDbContext>();
            _container.RegisterType(typeof(IMongoCollection<User>), new InjectionFactory(ioc => mongoDbContext.Users));
            _container.RegisterType(typeof(IMongoCollection<AthleteAccount>), new InjectionFactory(ioc => mongoDbContext.AthleteProfile));

            //_container.RegisterType(typeof(IMongoCollection<>), new InjectionFactory((ioc) => mongoDbContext.GetCollection<>()));
        }

    }

    public class ExceptionHandler : IExceptionHandler
    {
        public async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            throw context.Exception;

        }
    }
}