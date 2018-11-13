using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace SistemaEstoque.Models
{
    public static class DapperORM
    {
        //é a string de conexão
        private static string connectionString=@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstoqueDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();//abrir conexão
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        //método retorna uma lista
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }

        //retorna qualquer objeto de qualquer tipo
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                 return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        //DapperORM.ReturnList<Model> <= IEnumerable<Model>  

    }
}
