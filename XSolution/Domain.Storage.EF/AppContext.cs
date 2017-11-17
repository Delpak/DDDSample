using System.Data.Entity;
using System.Diagnostics;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Repository.EF
{
    public class AppContext : DbContext, IAppContext
    {

        public AppContext()
        {
            
        }

        public AppContext(string connectionString) : base(connectionString)
        {
            if (Debugger.IsAttached)
            {
                Database.Log = log => Debug.WriteLine(log);
            }
        }

        public IDbSet<OrderState> Orders { get; set; }
        public IDbSet<CustomerState> Customers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.ComplexType<CustomerId>()
        //        .Property(p => p.Id)
        //        .HasColumnName("CustomerId");
                
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
