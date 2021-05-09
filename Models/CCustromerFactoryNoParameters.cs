using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace First_ASP.Models
{
    public class CCustromerFactoryNoParameters
    {
        //todo新增
      public void insert(CCustomer cCustomer)
        {
            
            string sql = "Insert into tCustomer (";
            sql += "fName,";
            sql += "fPassword,";
            sql += "fEmail,";
            sql += "fPhone,";
            sql += "fAddress";
            sql += ") Values (";
            sql += "'" + cCustomer.fName + "',";
            sql += "'" + cCustomer.fPassword + "',";
            sql += "'" + cCustomer.fEmail + "',";
            sql += "'" + cCustomer.fPhone + "',";
            sql += "'" + cCustomer.fAddress + "')";
            sqlConnection(sql);
        }
        
        //todo修改
        public void update(CCustomer cCustomer)
        {
            string sql = "Update  tCustomer SET ";
            sql += "fName='" + cCustomer.fName + "',";
            sql += "fPassword='" + cCustomer.fPassword + "',";
            sql += "fEmail='" + cCustomer.fEmail + "',";
            sql += "fPhone='" + cCustomer.fPhone + "',";
            sql += "fAddress='" + cCustomer.fAddress + "' ";
            sql += "Where fId=" + cCustomer.fId;
            sqlConnection(sql);
        }

        //todo 刪除
        public void delete(CCustomer cCustomer)
        {
            string sql = "Delete from tCustomer where fId='" +cCustomer.fId+"'";
            sqlConnection(sql);
        }

        ////todo 查詢--
        

        public CCustomer getById_noParas(int fid)
        {
            string sql = "select *from tCustomer where fId=" + fid.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.;Initial Catalog=dBDeom;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlDataReader dr = cmd.ExecuteReader();
            CCustomer cust = null;
            if (dr.Read())
            {
                cust = new CCustomer()
                {
                    fId = (int)dr["fId"],
                    fName = dr["fName"].ToString(),
                    fPassword = dr["fPassword"].ToString(),
                    fEmail = dr["fEmail"].ToString(),
                    fPhone = dr["fPhone"].ToString(),
                    fAddress = dr["fAddress"].ToString()
                };
            }
            con.Close();
            con.Dispose();
            return cust;
        }

        ////-------------------------------------------------------------
        // todo開啟連線
        private void sqlConnection(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dBDeom;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }

    }
}