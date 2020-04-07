using generics.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class EmployeeRepository: Repository<employee>{
    
    public EmployeeRepository(DbContext context): base(context){

    }
}