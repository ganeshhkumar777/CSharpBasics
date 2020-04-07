using generics.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class EmployeeDetailsRepository: Repository<employeeDetails>{
    
    public EmployeeDetailsRepository(DbContext context): base(context){

    }
}