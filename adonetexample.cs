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
       insertrecords(names);
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

    }
    
}