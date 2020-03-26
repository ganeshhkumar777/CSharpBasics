using Microsoft.EntityFrameworkCore;
using System;
public class ebankingcontext : DbContext{

public DbSet<Customer> customers;

protected override void OnConfiguring(DbContextOptionsBuilder builder){
    builder.UseSqlServer("Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=ebanking;Integrated Security=true");
}

protected override void OnModelCreating(ModelBuilder builder){

    builder.Entity<RowStatus>((entity)=>{
        entity.HasKey(x=>x.RowstatusUid)
            .HasName("PK_RowStatus_RowStatusUid");
        entity.Property(x=>x.RowStatusId)
            .HasColumnType("int")
            .UseIdentityColumn(1,1);
        entity.Property(x=>x.RowstatusUid);   
        entity.Property(x=>x.Name)
            .HasMaxLength(100);
    });

    builder.Entity<Customer>((entity)=>{
        entity.HasKey(x=>x.CustomerUid)
             .HasName("PK_Customer_CustomerUid");
        entity.Property(x=>x.CustomerUid)
             .HasDefaultValueSql("(newsequentialid())");
        entity.Property(x=>x.Name)
             .HasMaxLength(100);
        entity.Property(x=>x.Password)
             .HasMaxLength(100);
        entity.Property(x=>x.CustomerId)
             .HasColumnType("int")
             .UseIdentityColumn(1,1);
        entity.HasOne(x=>x.RowStatus)
            .WithOne(x=>x.customer)
            .HasForeignKey<Customer>(x=>x.RowStatusUid)
            .OnDelete(DeleteBehavior.ClientNoAction);
        entity.Property(x=>x.RowStatusUid)    
                .HasDefaultValue(new Guid("01000000-0000-0000-0000-000000000000"));
    });

    builder.Entity<CustomerDetails>((entity)=>{
        entity.HasKey(x=>x.CustomerDetailsUid)
            .HasName("PK_CustomerDetails_CustomerDetailsUid");
        entity.Property(x=>x.CustomerDetailsUid)
            .HasDefaultValueSql("(newsequentialid())");
        entity.Property(x=>x.CustomerDetailsId)
            .HasColumnType("int")
            .UseIdentityColumn(1,1);
        entity.Property(x=>x.Address)   
            .HasColumnType("nvarchar(2000)")
            .HasMaxLength(1000);
        entity.Property(x=>x.Mobile)
            .HasColumnType("nvarchar(28)")
            .HasMaxLength(14);
        entity.HasOne(x=>x.Customer)
              .WithOne(x=>x.CustomerDetails)
              .HasForeignKey<Customer>(x=>x.CustomerUid);
        entity.Property(x=>x.RowStatusUid)    
              .HasDefaultValue(new Guid("01000000-0000-0000-0000-000000000000"));
         entity.HasOne(x=>x.RowStatus)
            .WithOne(x=>x.CustomerDetails)
            .HasForeignKey<CustomerDetails>(x=>x.RowStatusUid)
            .OnDelete(DeleteBehavior.ClientNoAction);;
    });

    builder.Entity<TransactionType>(entity=>{
        entity.HasKey(x=>x.RowStatusUid);
        entity.Property(x=>x.TransactionTypeUid);
    });

}
}

public class RowStatus{
    public Guid RowstatusUid{get; set;}
    public int RowStatusId{get; set;}
    public string Name{get; set;}
    public Customer customer{get; set;}
    public CustomerDetails CustomerDetails{get; set;}
    public TransactionType TransactionType{get; set;}
}
public class Customer{
public int CustomerId { get; set; }
public Guid CustomerUid { get; set; }
public string Name {get; set;}
public string Password{get; set;}

public Guid RowStatusUid { get; set; }

public RowStatus RowStatus{get; set;}

public CustomerDetails CustomerDetails{get; set;}
}

public class CustomerDetails{
public int CustomerDetailsId{get; set;}
public Guid CustomerDetailsUid{get; set;}
public Guid CustomerUid{get; set;}
public string Address{get; set;}
public string Mobile{get; set;}
public Guid RowStatusUid{get; set;}
public RowStatus RowStatus{get; set;}
public Customer Customer{get; set;}
}

public class TransactionType{
    public Guid TransactionTypeUid{get; set;}
    public int TransactionTypeId{get; set;}
    public string Name{get; set;}
    public Guid RowStatusUid{get; set;}
    public RowStatus RowStatus{get;set;}
}

