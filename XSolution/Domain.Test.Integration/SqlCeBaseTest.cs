using System;
using NUnit.Framework;
using AppContext = SAMA.XSolution.Repository.EF.AppContext;

namespace SAMA.XSolution.Domain.Integration.Test
{
    public abstract class SqlCeBaseTest
    {
        string DatabaseConnection { get; set; }

        protected void Repository(Action<Repository.EF.Repository> action )
        {
            using (var context = new AppContext(DatabaseConnection))
            using (var repository = new Repository.EF.Repository(context))
                action(repository);
        }

        [SetUp]
        public void BaseSetup()
        {
            DatabaseConnection = string.Format("Data Source=domain_{0}.sdf;Persist Security Info=False;", Guid.NewGuid());
            
            
        }

        [TearDown]
        public void BaseTearDown()
        {
            using (var context = new AppContext(DatabaseConnection))
                context.Database.Delete();
        }
    }
}