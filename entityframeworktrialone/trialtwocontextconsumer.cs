using System.Linq;
using System.Collections.Generic;
namespace generics.EntityFrameworkCore{
    public class trialtwocontextconsumer{
      public static void main(){

          //[
          // ,
         // {
         // employeename:"name4"
         // studentname:  "student2"  
         // },
         // {
         // employeename:"name5"
         // studentname:  "student2"  
         // },
         // ]
         // 

         // {
         // employeename:"name4"
         // studentname:  "student1"  
         // }

        // find eid from employee table
        // find sid from student table
        // var empasc = join employee table with assoc table 
        // based on eid
        // var stdasc = join student table with assoc table
        // based on eid
        //

        
          using(trialtwocontext con=new trialtwocontext()){
            // insertintoemployee(con,"address4","name4");
            //  insertintoemployee(con,"address5","name5");
            // insertintoemployee(con,"address6","name6");
            // insertintostudent(con);
            insertintoassociationtable(con,new empstudassociation("name4","student1"));
          }
         
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

      
        public static void insertintoassociationtable(trialtwocontext con,empstudassociation item){


                int eid=con.employees.Where(x=>x.name.Equals(item.ename))
                                     .FirstOrDefault()
                                     .id;
                int sid=con.students.Where(x=>x.name.Equals(item.sname))
                                    .FirstOrDefault()
                                    .studentid;

                // var ascemp=    from a in con.employeestudentassociations
                //             join b in con.employees
                //             on a.employeeid equals b.id
                //             select new { a.studentid};
                // var ascstd= from a in con.employeestudentassociations
                //             join b in con.students
                //             on a.studentid equals b.studentid
                //             select new { a.employeeid};
                employeestudentassociation assoc=new employeestudentassociation();
                assoc.employeeid=eid;
                assoc.studentid=sid;
                con.employeestudentassociations.Add(assoc);
                con.SaveChanges();

        }
     
    }
    public class empstudassociation{
        public string ename;
        public string sname;
        public empstudassociation(string ename, string studname){
            this.ename=ename;
            this.sname=studname;
        }
    }
}
