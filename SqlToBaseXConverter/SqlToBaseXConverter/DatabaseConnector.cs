using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlToBaseXConverter
{
      abstract class DatabaseConnector
    {
      
      public virtual void Connect(string databaseName){}
      public virtual void Connect(){}
      protected virtual void GetConnectionSettings() { }
    }
}
