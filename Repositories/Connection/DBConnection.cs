﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data.Common;

namespace Repositories
{
    public class DBConnection
    {
        private NpgsqlConnection conn = null;

        private static DBConnection instance;
        private DBConnection() { }
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }
        public void setConnection(NpgsqlConnection conn)
        {
            this.conn = conn;
        }
        public void openConnection()
        {
            if (conn == null)
                throw new NullReferenceException("connection is null");
            conn.Open();
        }

        public NpgsqlConnection connection
        {
            get
            {
                return conn;
            }
        }
        public void closeConnection()
        {
            if (conn == null)
                throw new NullReferenceException("connection is null");
            conn.Close();
        }
    }
}
