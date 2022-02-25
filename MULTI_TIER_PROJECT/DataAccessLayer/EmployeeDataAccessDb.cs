using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data;
using CommonLayer.Models;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class EmployeeDataAccessDb
    {
        private DbConnection db = new DbConnection();
        public List<Employees> GetEmployees()
        {
            string query = "select * from Employee";
            SqlCommand Command = new SqlCommand();
            Command.CommandText = query;
            Command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed) 
            { db.Cnn.Open(); }
               
            SqlDataReader reader = Command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                    Employees emp = new Employees();
                    emp.emp_no = (int)reader["emp_no"];
                    emp.emp_name = reader["emp_name"].ToString();
                    emp.emp_email = reader["emp_email"].ToString();
                    emp.emp_mobile = reader["emp_mobille"].ToString();
                    emp.emp_gender = reader["emp_gender"].ToString();
                    
                    employees.Add(emp);
             }
             db.Cnn.Close();

            return employees;
            
         
        }
    }
}
