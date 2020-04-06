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
            insertintoassociationtable(con,new List<empstudassociation>{new empstudassociation("name4","student1")});
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

      
        public static void insertintoassociationtable(trialtwocontext con,List<empstudassociation> items){

         //[
         // {
         // employeename:"name4"
         // studentname:  "student2"  
         // },
         // {
         // employeename:"name5"
         // studentname:  "student2"  
         // },
         //]

            List<string> existinge=items.Select(x=>x.ename).ToList();
         
         // ["name4","name5"]

            List<string> existings=items.Select(x=>x.sname).ToList();

        // ["student2","student2"]
        //  id  name
        //  1   gan
        //  2   gan
        var result = con.employees.AsEnumerable() 
                     .Where(x=>existinge.Contains(x.name))
                     .Distinct();

        //
        List<employee> eids=con.employees.Where(x=>existinge.       Contains(x.name)).Distinct().ToList();
        // Distinct here indicates the distinct of all the columns 
        // in the result set
        // select * from employee
        // where name in ("name4","name5")

        // [{},{}]
            List<student> sids=con.students.Where(x=>existings.Contains(x.name)).ToList();
        

        // select * from student
        // where name in ("student2","student2")
        
            foreach(var item in items){
            
                int eid=eids.Where(x=>x.name.Equals(item.ename))
                                     .FirstOrDefault()
                                     .id;
                int sid=sids.Where(x=>x.name.Equals(item.sname))
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
            }
                con.SaveChanges();

        }

        
        public static void joinExamples(trialtwocontext con) {
            
            con.employees.Where(x=>x.employeeDetails.EmployeeDetailsId==1).Count();
            // select count(*)

            // The below one should be avoided
            con.employees.Where(x=>x.employeeDetails.EmployeeDetailsId==1).ToList().Count();

            // select * from employee
            // where emp==1
            var result = from e in con.employees
            join emp in con.employeeDetails
            on e.EmployeeDetailsId equals emp.EmployeeDetailsId
            where emp.EmployeeDetailsId==1
            select e;

            // con.employees.Join(con.employeeDetails,(x)=>x.id,
            // (y) =>{
            //     y,
            // },(a,b)=>{
            //     a.id === b.
            // })

            
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
