﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMT_MVCv2.Models.DAL.DAO
{
    public class DBconnection
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            string srvrLink = @"Data source=DESKTOP-75K29E8\SQLEXPRESS;Database=SMTV1;Integrated Security=SSPI";
            connection.ConnectionString = srvrLink;
            connection.Open();
            return connection;
        }
    }
}