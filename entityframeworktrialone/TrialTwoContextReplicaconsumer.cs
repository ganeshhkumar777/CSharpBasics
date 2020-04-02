using System.Linq;
namespace generics.EntityFrameworkCore.trialtwocontextreplica{

  public class TrialTwoContextReplicaConsumer{

      public static void main(){
          trialtwocontextreplica con=new trialtwocontextreplica();
         // con.employees=con.Set<employee>();
        //   con.employees.Add(new employee(){
        //       name="Ganesh1"
        //   });
        var result=con.employees.Where(x=>x.name=="ganesh1").FirstOrDefault();
        result.name="ganesh2";
          con.SaveChanges();
      }

  }  

}