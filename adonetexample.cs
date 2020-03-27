using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
// using System.Transactions.;
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
        // SaveUsingSP();
        DisconnectedFill();
       // DisconnectedInsert("disconnectedinsert");
     //  DisconnectedUpdate("updatedname");
      String[] transactionName=new String[]{
            "firstname",
        };
     // Transaction(transactionName);
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

    public static void DisconnectedFill(string CommandText="select id,name from firsttable"){

        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";

        SqlCommand command=new SqlCommand();
        command.CommandText=CommandText;
        command.Connection=connection;

        SqlDataAdapter dataAdapter=new SqlDataAdapter();
        dataAdapter.SelectCommand=command;
        
        DataSet dataSet=new DataSet();
        //collection of datatables
        
        dataAdapter.Fill(dataSet);


        DataTable dataTable=new DataTable();
        if(dataSet.Tables.Count >0){
            dataTable=dataSet.Tables[0];
        }
        

        foreach(DataRow dr in dataTable.Rows){

             foreach (DataColumn item in dataTable.Columns)
             {
                 Console.WriteLine(dr[item]);
             }   
        }
    }

    public static void DisconnectedInsert(string toInsert){
        
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";

        SqlCommand command=new SqlCommand();
        command.CommandText="insert into firsttable(name) values(@name)";
        command.Connection=connection;
        
        SqlParameter parameter=new SqlParameter();
        parameter.ParameterName="@name";
        parameter.SourceColumn="name";

        command.Parameters.Add(parameter);

        DataTable dataTable=new DataTable();
        dataTable.Columns.Add("name");

        DataRow dataRow=dataTable.NewRow();
        dataRow["name"]=toInsert;
        dataTable.Rows.Add(dataRow);

        SqlDataAdapter dataAdapter=new SqlDataAdapter();
        dataAdapter.InsertCommand=command;

        var result = dataAdapter.Update(dataTable);
        
        DisconnectedFill();

        // name    id 
        // name1    1
        // name3    4
        // name5    5
    }

    public static void DisconnectedUpdate(string newName){
        
       
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";

        SqlCommand command=new SqlCommand();
        command.CommandText="select name,id from firsttable where id=1";
        command.Connection=connection;

        SqlDataAdapter dataAdapter=new SqlDataAdapter();
        dataAdapter.SelectCommand=command;
        
        DataSet dataSet=new DataSet();
        //collection of datatables
        
        dataAdapter.Fill(dataSet);


        DataTable dataTable=new DataTable();
        if(dataSet.Tables.Count >0){
            dataTable=dataSet.Tables[0];
        }
        dataTable.Rows[0][0]=newName;

        SqlCommand commandupdate=new SqlCommand();
        commandupdate.CommandText="update firsttable set name=@name where id=@id";
        commandupdate.Connection=connection;

        SqlParameter parameter1=new SqlParameter();
        parameter1.ParameterName="@name";
        parameter1.SourceColumn="name";

        SqlParameter parameter2=new SqlParameter();
        parameter2.ParameterName="@id";
        parameter2.SourceColumn="id";

        commandupdate.Parameters.Add(parameter1);
        commandupdate.Parameters.Add(parameter2);

        dataAdapter.UpdateCommand=commandupdate;

        dataAdapter.Update(dataTable);

        DisconnectedFill();
        // name         id 
        // newname1     1
        // name3        4
        // name5        5



        
    }
        
        //address
        //mobile
        //name

        // insert statement2    
        // userdetails 
            // userdetailsid
            // address
            // mobile

        // insert statement1 
        // user --> userdetailsid as foreign key
            // userid
            // name
            // userdetailsid
    
     public static void Transaction(String[] names){

        
        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=adonetsample;Integrated Security=true";
            connection.Open();

            SqlTransaction transaction=connection.BeginTransaction();

            SqlCommand command=new SqlCommand();
            command.CommandText="insert into firsttable values(@name)";
            command.CommandType=CommandType.Text;
            command.Connection=connection;
            command.Transaction=transaction;

            SqlParameter parameter=new SqlParameter();
            parameter.ParameterName="@name";
            parameter.Direction=ParameterDirection.Input;
            
            command.Parameters.Add(parameter);
            List<int> result=new List<int>();
            foreach(string name in names){
                
            parameter.Value= name;
             result.Add(command.ExecuteNonQuery()); //insert,update,delete, dealing with schemas 
            }
           
            SqlCommand command1=new SqlCommand();
            command1.CommandText="insert into firsttable values('secondname')";
            command1.CommandType=CommandType.Text;
            command1.Connection=connection;
            command1.Transaction=transaction;

            command1.ExecuteNonQuery();
            
           //

            transaction.Commit();
            // transaction.Rollback();

            Console.WriteLine(result);
            //ExecuteScalar -- Count(1), Max(1),
            //ExecuteReader -- Reading in 
        }
    }

}


// client chrome browser
// upload           
// excel file


// API
// 