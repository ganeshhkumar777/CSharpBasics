using System.Data.SqlClient;
using System.Data;
using System;
namespace generics.adonet{
    public class adonet{
    public static void main(){
        ;
        
        using(SqlConnection connection=new SqlConnection()){
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            connection.Open();
            SqlCommand command=new SqlCommand("select id,name from tablea",connection);

            SqlDataReader dataReader=command.ExecuteReader();
            if(dataReader.HasRows){
                while(dataReader.Read()){
                    Console.WriteLine(dataReader.GetInt32(0) + dataReader.GetString(1));
                    
                }
            }
            dataReader.Close();
            }
        }
    }



}