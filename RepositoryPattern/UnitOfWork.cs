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
        get{
            return new EmployeeRepository(context);
        } 
    }

    public EmployeeDetailsRepository employeeDetailsRepository{
        get{
            return new EmployeeDetailsRepository(context);
        }
    }
}