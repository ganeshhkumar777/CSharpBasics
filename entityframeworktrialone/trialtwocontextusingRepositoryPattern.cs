using generics.EntityFrameworkCore;
using System.Linq;
public class trialtwocontextusingrepositorypattern{

    public static void main(){
        using(trialtwocontext con=new trialtwocontext()){
        UnitOfWork unit=new UnitOfWork();
        insertintoemployee(unit,"address4","name4");     
        }
    }

     public static void insertintoemployee(UnitOfWork con, string address, string name){
           con.employeeDetailsRepository.Add(new employeeDetails(){
              Address=address,
                
          });
          con.SaveChanges();
          var result = con.employeeDetailsRepository.GetAll().OrderByDescending(x=>x.EmployeeDetailsId).FirstOrDefault().EmployeeDetailsId;
         
          con.employeeRepository.Add(new employee(){
              name=name,
              EmployeeDetailsId=result
          });
          con.SaveChanges();

          
      }
}