namespace generics.EntityFrameworkCore.trialtwocontextreplica{

  public class TrialTwoContextReplicaConsumer{

      public static void main(){
          trialtwocontextreplica con=new trialtwocontextreplica();
          con.employees=con.Set<employee>();
          con.employees.Add(new employee(){
              name="Ganesh"
          });
          con.SaveChanges();
      }

  }  

}