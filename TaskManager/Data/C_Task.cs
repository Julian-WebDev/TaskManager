using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using TaskManager.Models.TaskUpdate;
using TaskManager.Models;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace TaskManager.Data
{
    public class C_Task
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public void insertTask(string subject, string date, string name, string description)
        {
            SqlCommand command = new SqlCommand("INSERT_TASK", connection);

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@SUBJECT", System.Data.SqlDbType.NChar).Value = subject;
            command.Parameters.Add("@DATE", System.Data.SqlDbType.NChar).Value = date;
            command.Parameters.Add("@NAME", System.Data.SqlDbType.NChar).Value = name;
            command.Parameters.Add("@DESCRIPTION", System.Data.SqlDbType.NChar).Value = description;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteTask(string id)
        {
            SqlCommand command = new SqlCommand("DELETE_TASK", connection);

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@ID", System.Data.SqlDbType.NChar).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void update(string id, string subject, string date, string name, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE_TASK", connection);

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@SUBJECT", System.Data.SqlDbType.NChar).Value = subject;
            command.Parameters.Add("@DATE", System.Data.SqlDbType.NChar).Value = date;
            command.Parameters.Add("@NAME", System.Data.SqlDbType.NChar).Value = name;
            command.Parameters.Add("@DESCRIPTION", System.Data.SqlDbType.NChar).Value = description;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void complete(string id) 
        {
            SqlCommand command = new SqlCommand("COMPLETE_TASK", connection);

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void incomplete(string id)
        {
            SqlCommand command = new SqlCommand("INCOMPLETE_TASK", connection);

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}