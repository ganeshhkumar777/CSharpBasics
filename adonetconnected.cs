using System.Data.SqlClient;
using System.Data;
using System;
namespace generics.adonet{
    public static class AdoNetConnectedExamples{
        public static void main(){

            SqlConnection connection=new SqlConnection();
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            connection.Open();
             
            SqlParameter param1=new SqlParameter();
            param1.Direction=ParameterDirection.Input;
            param1.DbType=DbType.Int32;
            param1.ParameterName="@value";
            param1.Value=1;
            SqlTransaction transaction=connection.BeginTransaction(IsolationLevel.ReadUncommitted);

            SqlCommand command=new SqlCommand();
            command.CommandText="select name,id from TABLEA where id =@value ";
            command.Connection=connection;
            command.Transaction=transaction;
            command.Parameters.Add(param1);

            var reader = command.ExecuteReader();
            while(reader.Read()){
                Console.WriteLine(reader.IsDBNull(0) ? null :reader.GetString(0));
            }
            reader.Close();
            transaction.Commit();
            connection.Close();

            // SqlDataAdapter adapter=new SqlDataAdapter("select name,id from TABLEA where id =@value","Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true");
            // adapter.Fill();
            // adapter.InsertCommand="";
            // adapter.AcceptChangesDuringFill()

        }
    }
}