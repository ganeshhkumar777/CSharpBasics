using System.Data.SqlClient;
using System.Data;
using System;
namespace generics.adonet{
    public class adonet{
    public static void main(){
        
        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            connection.Open();
            SqlCommand command=new SqlCommand("select id from tablea where id=@id",connection);
            command.Parameters.Add(new SqlParameter("@id",1));
            SqlDataReader dataReader=command.ExecuteReader();
            if(dataReader.HasRows){
                while(dataReader.Read()){
                    Console.WriteLine(dataReader.GetInt32(dataReader.GetOrdinal("id")));
                    
                }
            }
            dataReader.Close();
            }
            //insert();
            callSP();
        }

        public static void insert(){
        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase; Integrated Security=true";
            connection.Open();
            SqlCommand command=new SqlCommand("alter table tablea add name2 varchar(100)",connection);
            command.CommandType=CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();

        }
        }

        public static void callSP(){
            using(SqlConnection connection=new SqlConnection()){
                connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase; Integrated Security=true";
                SqlCommand command=new SqlCommand();
                command.Connection=connection;
                command.CommandText="SAMPLEProc";
                command.CommandType=CommandType.StoredProcedure;

                var param1= new SqlParameter("@a",SqlDbType.Int);
                param1.Direction=ParameterDirection.Input;
                param1.Value=2;

                var param2= new SqlParameter("@b",SqlDbType.Int);
                param2.Direction=ParameterDirection.Output;

                
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                connection.Open();
                var result = command.ExecuteReader();
                while(result.Read()){
                    Console.WriteLine(result.IsDBNull(result.GetOrdinal("name"))
                    ? "" : result.GetString(result.GetOrdinal("name")));
                }

                 var temp=command.Parameters["@b"].Value;
                 Console.WriteLine(temp);
                
            }
        }

    }

    


}