using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace First_ASP.Models
{
    public class CCustomerFactory
    {
        public List<CCustomer> getAll()
        {
            return getBySql("select * from tCustomer", null);
        }
        public CCustomer getById(int fid)
        {
            string sql = "select * from tCustomer where fId=@K_fid";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_fId", (object)fid));
            List<CCustomer> list = getBySql(sql, paras);
            if (list.Count !=0)
                return list[0];
            return null;
        }

        public List<CCustomer> getByKeyWord(string keyword)
        {
            
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_fName", "%"+(object)keyword+"%"));
            paras.Add(new SqlParameter("K_fPhone", "%"+(object)keyword+"%"));
            paras.Add(new SqlParameter("K_fEmail", "%"+(object)keyword+"%"));
            paras.Add(new SqlParameter("K_fAddress", "%"+(object)keyword+"%"));
            string sql = "select * from tCustomer where fName Like @K_fName";
            sql += " OR fPhone Like @K_fPhone";
            sql += " OR fEmail Like @K_fEmail";
            sql += " OR fAddress Like @K_fAddress";
            return getBySql(sql, paras);           
                
        }

        private static List<CCustomer> getBySql(string sql,List<SqlParameter>paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.;Initial Catalog=dBDeom;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
            }
            SqlDataReader dr = cmd.ExecuteReader();
            List<CCustomer> list = new List<CCustomer>();
            while (dr.Read())
            {
                CCustomer cust = new CCustomer()
                {
                    fId = (int)dr["fId"],
                    fName = dr["fName"].ToString(),
                    fPassword = dr["fPassword"].ToString(),
                    fEmail = dr["fEmail"].ToString(),
                    fPhone = dr["fPhone"].ToString(),
                    fAddress = dr["fAddress"].ToString()
                };
                list.Add(cust);
            }
            con.Close();
            con.Dispose();
            return list;
        }

       

        //todo 新增帶參數
        public void insert(CCustomer cCustomer)
        {
            //insert into tCustomer (fName,fPassword,fEmail,fPhone,fAddress) values ('John','123456','John@gmail.com','0987654321','新北市')
            string sql = "Insert into tCustomer (";
            sql += "fName,";
            sql += "fPassword,";
            sql += "fEmail,";
            sql += "fPhone,";
            sql += "fAddress";
            sql += ") Values (";
            sql += "@K_fName,";
            sql += "@K_fPassword,";
            sql += "@K_fEmail,";
            sql += "@K_fPhone,";
            sql += "@K_fAddress)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(cCustomer.fName.ToString()))
                sqlParameters.Add(new SqlParameter("K_fName", (object)cCustomer.fName));
            if (!string.IsNullOrEmpty(cCustomer.fPassword.ToString()))
                sqlParameters.Add(new SqlParameter("K_fPassword", (object)cCustomer.fPassword));
            if (!string.IsNullOrEmpty(cCustomer.fEmail.ToString()))
                sqlParameters.Add(new SqlParameter("K_fEmail", (object)cCustomer.fEmail));
            if (!string.IsNullOrEmpty(cCustomer.fPhone.ToString()))
                sqlParameters.Add(new SqlParameter("K_fPhone", (object)cCustomer.fPhone));
            if (!string.IsNullOrEmpty(cCustomer.fAddress.ToString()))
                sqlParameters.Add(new SqlParameter("K_fAddress", (object)cCustomer.fAddress));
            sqlConnection(sql, sqlParameters);
        }
        
        //todo 修改帶參數
        public void update(CCustomer cCustomer)
        {
            string sql = "Update  tCustomer SET ";
            sql += "fName=@K_fName,";
            sql += "fPassword=@K_fPassword,";
            sql += "fEmail=@K_fEmail,";
            sql += "fPhone=@K_fPhone,";
             sql += "fAddress=@K_fAddress ";
            sql += "Where fId=@K_fId";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(cCustomer.fName.ToString()))
                sqlParameters.Add(new SqlParameter("K_fName", (object)cCustomer.fName));
            if (!string.IsNullOrEmpty(cCustomer.fPassword.ToString()))
                sqlParameters.Add(new SqlParameter("K_fPassword", (object)cCustomer.fPassword));
            if (!string.IsNullOrEmpty(cCustomer.fEmail.ToString()))
                sqlParameters.Add(new SqlParameter("K_fEmail", (object)cCustomer.fEmail));
            if (!string.IsNullOrEmpty(cCustomer.fPhone.ToString()))
                sqlParameters.Add(new SqlParameter("K_fPhone", (object)cCustomer.fPhone));
            if (!string.IsNullOrEmpty(cCustomer.fAddress.ToString()))
                sqlParameters.Add(new SqlParameter("K_fAddress", (object)cCustomer.fAddress));
            if (!string.IsNullOrEmpty(cCustomer.fId.ToString()))
                sqlParameters.Add(new SqlParameter("K_fId", (object)cCustomer.fId));
            sqlConnection(sql,sqlParameters);
        }

        //todo 刪除 帶參數
        public void delete(CCustomer cCustomer)
        {
            string sql = "Delete From tCustomer where fId=@K_fId";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //判斷
            if (!string.IsNullOrEmpty(cCustomer.fId.ToString()))
                sqlParameters.Add(new SqlParameter("K_fId", (object)cCustomer.fId));
            sqlConnection(sql, sqlParameters);
        }
        
        //todo SQL連線帶參數
        private void sqlConnection(string sql, List<SqlParameter> sqlParameters)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dBDeom;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (sqlParameters != null)
            {
                foreach (SqlParameter p in sqlParameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
    }
}