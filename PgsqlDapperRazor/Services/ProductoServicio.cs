using System;
using System.Data;
using Dapper;
using Npgsql;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PgsqlDapperRazor.Entities;


namespace PgsqlDapperRazor.Services
{
    public class ProductoServicio: IProducto
    {
        IConfiguration configuration;
        public ProductoServicio(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Producto ProductoDetalle(int prodId)
        {
            Producto result = new Producto();
            try
            {
                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "select * from product where id="+prodId;
                    result = SqlMapper.Query<Producto>(conn, query, commandType: CommandType.Text).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return result;
        }
        public List<Producto> ListaProductos()
        {
            List<Producto> result = new List<Producto>();
            try
            {

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "select id,name from product";
                    result = SqlMapper.Query<Producto>(conn, query, commandType: CommandType.Text).ToList();
                }
                conn.Close();

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