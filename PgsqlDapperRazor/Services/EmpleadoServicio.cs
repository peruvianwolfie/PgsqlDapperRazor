using System;
using System.Data;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PgsqlDapperRazor.Services
{
    public class EmpleadoServicio: IEmpleado
    {
        IConfiguration configuration;
        public EmpleadoServicio(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object EmpleadoDetalle(int empId)
        {
            object result = null;
            try
            {

                var dyParam = new DynamicParameters();
                dyParam.Add("empid", empId);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "usp_employee_details";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object ListaEmpleados()
        {
            object result = null;
            try
            {

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "select * from employee";
                    result = SqlMapper.Query(conn, query, commandType: CommandType.Text);
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
