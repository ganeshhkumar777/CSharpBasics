using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
public class adonetsample{
    public static void main(){
       // createtableandinsertdata();
       String[] names=new String[]{
            "name2",
            "name3",
            "name4",
            "name5"
        };
       //insertrecords(names);
       // Reading();
      // ReadingUsingSP();
      SaveUsingSP();
    }

    public static void createtableandinsertdata(){

        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandText="create table firsttable (id int identity(1,1) primary key,name nvarchar(50))";
            command.CommandType=CommandType.Text;
            command.Connection=connection;

            var result = command.ExecuteNonQuery(); //insert,update,delete, dealing with schemas 

            Console.WriteLine(result);
            //ExecuteScalar -- Count(1), Max(1),
            //ExecuteReader -- Reading in 
        }
    }

    public static void insertrecords(String[] names){

        
        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandText="insert into firsttable values(@name)";
            command.CommandType=CommandType.Text;
            command.Connection=connection;

            SqlParameter parameter=new SqlParameter();
            parameter.ParameterName="@name";
            parameter.Direction=ParameterDirection.Input;
            
            command.Parameters.Add(parameter);
            List<int> result=new List<int>();
            foreach(string name in names){
                
            parameter.Value= name;
             result.Add(command.ExecuteNonQuery()); //insert,update,delete, dealing with schemas 
            }
           

            Console.WriteLine(result);
            //ExecuteScalar -- Count(1), Max(1),
            //ExecuteReader -- Reading in 
        }
    }

    public static void Reading(){
        
        List<String> names=new List<string>();
        using(SqlConnection connnection=new SqlConnection()){
            
            connnection.ConnectionString = "Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connnection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText="select name,id from firsttable";

            command.Connection=connnection;

            SqlDataReader reader= command.ExecuteReader();
            if(reader.HasRows){
                while(reader.Read()){
                  var result = !reader.IsDBNull(reader.GetOrdinal("name")) ?  reader.GetString(reader.GetOrdinal("name")) :  null;
                  Console.WriteLine(result);
                  names.Add(result);
                }
            }

            //      id  name
            //      1  name1
            //      2  name2

            reader.Close();

        }

    }


 public static void ReadingUsingSP(){
        
        List<String> names=new List<string>();
        using(SqlConnection connnection=new SqlConnection()){
            
            connnection.ConnectionString = "Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connnection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText="firstprocedure";

            command.Connection=connnection;

            SqlParameter parameter=new SqlParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName="@a";
            parameter.Value=1;

            command.Parameters.Add(parameter);

            SqlParameter parameter1=new SqlParameter();
            parameter1.Direction = ParameterDirection.ReturnValue;
            parameter1.ParameterName="@b";

            command.Parameters.Add(parameter1);

            SqlDataReader reader= command.ExecuteReader();
            if(reader.HasRows){
                while(reader.Read()){
                  var result = !reader.IsDBNull(reader.GetOrdinal("name")) ?  reader.GetString(reader.GetOrdinal("name")) :  null;
                  Console.WriteLine(result);
                  names.Add(result);
                }
            }

            //      id  name
            //      1  name1
            //      2  name2

            reader.Close();
            var temp= command.Parameters["@b"].Value;
            Console.WriteLine(temp);
        }

    }

    public static void SaveUsingSP(){
        
        List<String> names=new List<string>();
        using(SqlConnection connnection=new SqlConnection()){
            
            connnection.ConnectionString = "Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connnection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText="saveprocedure";

            command.Connection=connnection;

            SqlParameter parameter=new SqlParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName="@a";
            parameter.Value="insernameusingsp";

            command.Parameters.Add(parameter);

            SqlParameter parameter1=new SqlParameter();
            parameter1.Direction = ParameterDirection.ReturnValue;
            parameter1.ParameterName="@b";

            command.Parameters.Add(parameter1);

            var result = command.ExecuteNonQuery();
            

            //      id  name
            //      1  name1
            //      2  name2

            var temp= command.Parameters["@b"].Value;
            Console.WriteLine(temp);
        }

    }

    
}


// client chrome browser
// upload           
// excel file


// API
// 