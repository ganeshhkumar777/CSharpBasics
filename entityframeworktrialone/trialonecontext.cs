using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
public class trialonecontext: DbContext {
DbSet<customer> customers {get;set;}
DbSet<customerdetails> customerdetails {get; set;}
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
     optionsBuilder.UseSqlServer(new SqlConnection("Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=eftestone;Integrated Security=true"));
    }

protected override void OnModelCreating(ModelBuilder modelBuilder){
// builder.Entity<customer>(x=>{
//     x.HasKey(y=>y.customerid)
//     .HasName("customer_customerid");
// });
modelBuilder.Entity<customer>(entity =>
            {
                entity.Property(e => e.id)
                    .IsRequired();
                entity.HasKey(x=>x.id);
                entity.HasOne(x=>x.customerdetails)
                      .WithOne(x=>x.customer)
                      .HasForeignKey<customer>(x=>x.customerdetailsid);
            });

modelBuilder.Entity<customerdetails>(entity =>{
    entity.HasKey(x=>x.customerdetailsid);
});
}
 

}

public class customer{
    public int id{get; set;}
    public string name{get; set;}
    public int customerdetailsid{get; set;}
    public customerdetails customerdetails{get; set;}
}

public class customerdetails{
    public int customerdetailsid{get; set;}
    public string address{get; set;}
    public string phone{get; set;}

    public customer customer{get; set;}

}