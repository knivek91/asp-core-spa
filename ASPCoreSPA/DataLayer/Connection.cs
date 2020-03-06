using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLayer
{
    public sealed class Connection
    {
        private static IDbConnection DB;
        private static Connection Conn;
        private static string ConnString;

        private Connection() { }

        #region Property
        public static Connection Instance
        {
            get
            {
                if (Conn == null)
                    Conn = new Connection();
                return Conn;
            }
        }
        #endregion


        #region Create Connection
        public void SetConnectionString(string conn)
        {
            if (string.IsNullOrEmpty(conn))
                throw new Exception("Connection string in invalid.");
            ConnString = conn;
        }
        #endregion

        #region Query
        public IEnumerable<T> Query<T>(string sql, IEnumerable<SQLParameter> parameters = null)
        {
            using (DB = new SqlConnection(ConnString))
            {
                DynamicParameters dapperParams = this.CreateParameters(parameters);
                return DB.Query<T>(sql, dapperParams);
            }
        }
        #endregion

        #region Execute
        public long Execute(string sql, IEnumerable<SQLParameter> parameters = null, bool retriveIdentity = false)
        {
            using (DB = new SqlConnection(ConnString))
            {
                DynamicParameters dapperParams = this.CreateParameters(parameters);
                return retriveIdentity ? DB.Query<long>(sql, dapperParams).Single() : DB.Execute(sql, dapperParams);
            }
        }
        #endregion

        #region Create Parameter
        private DynamicParameters CreateParameters(IEnumerable<SQLParameter> parameters)
        {

            if (parameters == null)
                return null;

            DynamicParameters dapperParams = new DynamicParameters();
            foreach (var param in parameters)
            {
                dapperParams.Add(param.Name, param.Value, this.CheckDbType(param.Value), param.Direction);
            }
            return dapperParams;

        }
        /**
         * if you can you can avoid this validation
         * if you want you can add a prop into the SQLParameter Class with the type, and remove this function
        */
        private DbType CheckDbType(object value)
        {
            string type = value.GetType().Name;
            switch (type)
            {
                case "String":
                case "Char":
                    return DbType.String;
                case "Integer":
                    return DbType.Int32;
                case "Boolean":
                    return DbType.Boolean;
                case "DateTime":
                    return DbType.DateTime;
                default:
                    return DbType.Int64;
            }
        }
        #endregion
    }
}