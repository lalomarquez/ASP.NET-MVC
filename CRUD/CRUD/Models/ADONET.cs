using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class ADONET
    {
        public static SqlConnection ReturnConn()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            if (Conn.State == ConnectionState.Closed)
            {
                try
                {
                    Conn.Open();
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //switch (ex.Number)
                    //{
                    //    case 4060:                            
                    //        MessageBox.Show("Cannot open database.\nThe login failed.");
                    //        break;
                    //    case 26:
                    //        MessageBox.Show("Error: 26");
                    //        break;
                    //    default:
                    //        MessageBox.Show("Other Error");
                    //        break;
                    //}
                }
            }
            return Conn;
        }
        public static SqlCommand CreateCmd(string procName, SqlConnection Conn)
        {
            SqlConnection SqlConn = Conn;
            if (SqlConn.State.Equals(ConnectionState.Closed))
            {
                SqlConn.Open();
            }
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = SqlConn;
            Cmd.CommandText = procName;
            return Cmd;
        }
        public static DataSet GetAllRecords(string NameSP)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(NameSP, Conn);
            SqlDataAdapter Dtr = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            Dtr.SelectCommand = Cmd;
            Dtr.Fill(Ds);
            Cmd.Dispose();
            //DataTable Dt = Ds.Tables[0];
            Conn.Close();

            return Ds;
        }
    }
    public class SCRUD
    {
        SqlConnection conn = ADONET.ReturnConn();
        SqlCommand cmd;
        SqlDataAdapter adp;
        public DataTable ReadRecordsADONet()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("[SP_FetchRegisterUser]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt.Dispose();
            }
            return dt;
        }
    }
}