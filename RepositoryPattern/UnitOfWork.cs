using generics.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
public class UnitOfWork{
    private DbContext context;
    public UnitOfWork(){
        context=new trialtwocontext();
    }

    public void SaveChanges(){
        try{
            context.SaveChanges();
        } catch(Exception ex){
            throw ex;
        } 
    }

    public EmployeeRepository employeeRepository{
        get; set;
    }

    public EmployeeDetailsRepository employeeDetailsRepository{
        get; set;
    }
}