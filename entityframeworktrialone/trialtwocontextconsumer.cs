using System.Linq;
namespace generics.EntityFrameworkCore{
    public class trialtwocontextconsumer{
      public static void main(){
          trialtwocontext con=new trialtwocontext();
         insertintoemployee(con,"address4","name4");
         insertintoemployee(con,"address5","name5");
         insertintoemployee(con,"address6","name6");
         insertintostudent(con);
      }

      public static void insertintoemployee(trialtwocontext con, string address, string name){
           con.employeeDetails.Add(new employeeDetails(){
              Address=address,
                
          });
          int r=con.SaveChanges();
          var result = con.employeeDetails.OrderByDescending(x=>x.EmployeeDetailsId).FirstOrDefault().EmployeeDetailsId;
         
          con.employees.Add(new employee(){
              name=name,
              EmployeeDetailsId=result
          });
          con.SaveChanges();

          
      }

      public static void insertintostudent(trialtwocontext con){
          con.students.AddRange(new student[]{
              new student(){
              name="student1"},
               new student(){
              name="student2"},
               new student(){
              name="student3"}
          });
          con.SaveChanges();
      }

      

     
    }
}
