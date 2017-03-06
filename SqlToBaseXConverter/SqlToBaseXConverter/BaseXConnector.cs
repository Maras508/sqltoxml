﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseXClient;

namespace SqlToBaseXConverter
{
    class BaseXConnector: DatabaseConnector
    {
        public Session session;
        public override void Connect()
        {
            session = new Session("localhost", 1984, "admin", "admin");
        }
        public override void Connect(string databaseName)
        {
            session = new Session("localhost", 1984, "admin", "admin");
            session.Execute("open " + databaseName);
        }
    }
}