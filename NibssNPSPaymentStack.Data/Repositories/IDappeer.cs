using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;


namespace NibssNPSPaymentStack.Data.Repositories
{
    public interface IDappeer
    {
       
        Task<T?> GetAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure);

        Task<T?> ExecuteInTransactionAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure);

        DbConnection GetDbConnection();
    }
}
