using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace generics.EntityFrameworkCore.trialtwocontextreplica{

  public class TrialTwoContextReplicaConsumer{

      public static void main(){
          trialtwocontextreplica con=new trialtwocontextreplica();
         // con.employees=con.Set<employee>();
        //   con.employees.Add(new employee(){
        //       name="Ganesh1"
        //   });
        
        var result=con.employees.Where(x=>x.name=="ganesh1")
                      .Include(x=>x.employeeDetails)
                      .FirstOrDefault();
        var result2=con.students.Where(x=>x.studentid==1).FirstOrDefault();
        con.Entry(result2).Collection(x=>x.employeestudentassociation)
                    .Load();
        
        result.name="ganesh2";
        
          con.SaveChanges();
      }

  }  

}