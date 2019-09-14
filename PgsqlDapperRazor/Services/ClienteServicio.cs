using System;
using System.Data;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Services
{
    public class ClienteServicio: ICliente
    {
        IConfiguration configuration;
        public ClienteServicio(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Cliente ClienteDetalle(int id)
        {
            var conn = this.GetConnection();
            Cliente cliente = new Cliente();


            using (conn)
            {
                try
                {
                    conn.Open();
                    var dyParam = new DynamicParameters();
                    dyParam.Add("custid", id);
                    var query = "usp_customer_details";
                    //cliente= conn.Query<Cliente>(query, dyParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    cliente = SqlMapper.Query<Cliente>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

                return cliente;
            }
        }

        public List<Cliente> ListaClientes()
        {
            List<Cliente> result = new List<Cliente>();
            try
            {

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "select * from customer";
                    result = SqlMapper.Query<Cliente>(conn, query, commandType: CommandType.Text).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("DBInfo").GetSection("ConnectionString").Value;
            var conn = new NpgsqlConnection(connectionString);
            return conn;
        }
    }
}
