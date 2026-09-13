using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibssNPSPaymentStack.Data.Repositories
{
    public class Dappeer : IDappeer,IDisposable
    {
        private readonly string _connectionString;

        public Dappeer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EPayDatabase")
                ?? throw new ArgumentNullException(nameof(configuration));
        }

        private SqlConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public async Task<T?> GetAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            await using var connection = CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<T>(
                storedProcedure,
                parameters,
                commandType: commandType);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            await using var connection = CreateConnection();

            var result = await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: commandType);

            return result.AsList();
        }

        public async Task<T?> ExecuteInTransactionAsync<T>(
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            await using var connection = CreateConnection();
            await connection.OpenAsync();

            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                var result = await connection.QueryFirstOrDefaultAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: commandType,
                    transaction: transaction);

                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public DbConnection GetDbConnection()
            => CreateConnection();

        public void Dispose()
        {
            // Connection lifecycle handled per method
        }
    }
}

