using System.Data.SqlClient;
using System.Data;
using System;
using System.Transactions;
namespace generics.adonet{
    public static class AdoNetConnectedExamples{
        public static void main(){
            TransactionTest();
            // DisconnectedArchitecture();

        }

        public static void Transaction(){
            SqlConnection connection=new SqlConnection();
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            connection.Open();
             
            SqlParameter param1=new SqlParameter();
            param1.Direction=ParameterDirection.Input;
            param1.DbType=DbType.Int32;
            param1.ParameterName="@value";
            param1.Value=1;
            SqlTransaction transaction=connection.BeginTransaction();

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

        public static void DisconnectedArchitecture(){
            SqlConnection connection=new SqlConnection();
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            
            SqlDataAdapter adapter=new SqlDataAdapter(
                //"",
            );

            SqlCommand command=new SqlCommand();
            command.CommandText="select id,name from tablea";
            command.Connection=connection;

            adapter.SelectCommand=command;

            DataSet dataSet=new DataSet();
            adapter.Fill(dataSet);

            DataTable dt=dataSet.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                foreach(DataColumn col in dt.Columns){
                    // if(col.ColumnName.Equals("name"))
                    //  row[col]="newname";
                    Console.WriteLine(row[col]);
                }
            }
          
            SqlDataAdapter adapter2=new SqlDataAdapter(
                //"",
            );

            SqlCommand insertcommand=new SqlCommand();
            insertcommand.CommandText="update tablea set name=@name where id=@id";
            insertcommand.Connection=connection;
            adapter2.UpdateCommand=insertcommand;
            
            SqlParameter parameter1=new SqlParameter();
            parameter1.Direction=ParameterDirection.Input;
            parameter1.ParameterName="@name";
            parameter1.SourceColumn="name";
            

            
            SqlParameter parameter2=new SqlParameter();
            parameter2.Direction=ParameterDirection.Input;
            parameter2.ParameterName="@id";
            parameter2.SourceColumn="id";

            
            adapter2.UpdateCommand.Parameters.Add("@name",SqlDbType.NVarChar,100,"name");
            adapter2.UpdateCommand.Parameters.Add(parameter2);
            adapter2.Update(dt);

           DataRow dataRow=dt.NewRow();
           dataRow["name"]="newname4";
           dt.Rows.Add(dataRow);

            SqlCommand command1=new SqlCommand();
            command1.CommandText="insert into tablea(name) values(@name)";
            command1.Connection=connection;
            adapter2.InsertCommand=command1;
           adapter2.InsertCommand.Parameters.Add(parameter1);
           adapter2.Update(dt);
        }
    
        public static void TransactionTest(){
            SqlConnection connection=new SqlConnection();
            connection.ConnectionString="Data Source=CDC2-D-CGQVXJ2\\SQLEXPRESS01;Initial Catalog=sampledatabase;Integrated Security=true";
            connection.Open();

            SqlCommand command=new SqlCommand();
            command.CommandText="insert into tablea(name) values('abc')";
            command.CommandType=CommandType.Text;
            command.Connection=connection;
            
           // SqlTransaction transaction=connection.BeginTransaction();
           using(TransactionScope transaction=new TransactionScope()){
            command.ExecuteNonQuery();
            command.ExecuteNonQuery();
            transaction.Complete();
           }
            // command.Transaction=transaction;
            
        }
    }
}