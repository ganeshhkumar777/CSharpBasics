//  whenever you see the class named trialtwocontext
//  you inject an instance of trialtwocontext
//
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
namespace generics.EntityFrameworkCore.trialtwocontextreplica{
public class trialtwocontextreplica : DbContext {
    public DbSet<employee> employees{get; set;}
    public DbSet<employeeDetails> employeeDetails{get; set;}
    public DbSet<student> students {get; set;}
    public DbSet<employeestudentassociation> employeestudentassociations{get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder
     builder){
         if(!builder.IsConfigured){
            builder.UseSqlServer("Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=entityframeworkexample;Integrated Security=true");
         }
    }

    protected override void OnModelCreating(ModelBuilder builder)    {
        builder.Entity<employee>(x=>{
            x.Property(y => y.id )
            .UseIdentityColumn(1,1);
            
            x.Property(y=>y.name)
            .HasMaxLength(100);

            x.Property(y=>y.lastname)
             .HasMaxLength(100);;
            
            x.Property(y=>y.EmployeeDetailsId)
            .IsRequired(false);
            x.HasKey(y=>y.id);

            x.HasOne(y=>y.employeeDetails)
            .WithOne(y=>y.employee)
            .HasForeignKey<employee>(y=>y.EmployeeDetailsId)
            .HasConstraintName("FK_employeedetailsid_employeedetails")
            .IsRequired(false);

            x.Property(y=>y.CreatesOn)
                .IsRowVersion();


        });

        builder.Entity<employeeDetails>(x=>{
            x.Property(y=>y.EmployeeDetailsId)
            .UseIdentityColumn(1,1)
            .HasColumnType("int")
            .HasColumnName("Id");

            x.Property(y=>y.Address)
            .IsRequired(false)
            .HasColumnType("nvarchar(500)");
            
            x.HasKey(y=>y.EmployeeDetailsId);
        });

        builder.Entity<student>(x=>{
            x.Property(y=>y.studentid)
            .UseIdentityColumn(1,1)
                .HasColumnType("int");
            x.Property(y=>y.name)
                .HasColumnType("nvarchar(100)");
            x.HasKey(y=>y.studentid);
        });

        builder.Entity<employeestudentassociation>(x=>{
            x.Property(y=>y.id)
            .UseIdentityColumn(1,1)
            .HasColumnType("int");
            x.HasKey(y=>y.id);

            x.HasOne(y=>y.students)
            .WithMany(y=>y.employeestudentassociation)
            .HasForeignKey(y=>y.studentid)
            .OnDelete(DeleteBehavior.Cascade);

            x.HasOne(y=>y.employees)
            .WithMany(y=>y.employeestudentassociations)
            .HasForeignKey(y=>y.employeeid);

            }
        );
    }
}

public class employee{
    public int id{get; set;}
    public string name{get; set;}
    public string lastname{get; set;}

    public int? EmployeeDetailsId{get; set;}

    public DateTime CreatesOn{get; set;}
    public employeeDetails employeeDetails{get; set;}
    public List<employeestudentassociation> employeestudentassociations { get; set; }
}

public class employeeDetails{
    public int EmployeeDetailsId{get; set;}
    public string Address{get; set;}
    public employee employee{get; set;}
}
public class student{
    public int studentid{get; set;}

    public string name {get; set;}

    public List<employeestudentassociation> employeestudentassociation { get; set; }
}

public class employeestudentassociation{
    public int id{get; set;}
    public int employeeid { get; set; }
    public int studentid { get; set; }
    public employee employees{get; set;}
    public student students{get; set;}

}

}

// student
 // id

// employeestudentassociationid studentid
//                              