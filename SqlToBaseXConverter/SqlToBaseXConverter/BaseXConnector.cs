using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseXClient;
using System.Xml;
using System.IO;

namespace SqlToBaseXConverter
{
    class BaseXConnector : DatabaseConnector
    {
        public Session session;
        public static BaseXConnector baseXConnector = null;
        private string host;
        private int port;
        private string userName;
        private string password;

        public static BaseXConnector GetConnector()
        {
            if (baseXConnector == null)
            {
                baseXConnector = new BaseXConnector();
                return baseXConnector;
            }
            else
            {
                return baseXConnector;
            }
        }
        public override void Connect()
        {
            GetConnectionSettings();
            session = new Session(host, port, userName, password);
        }
        public override void Connect(string databaseName)
        {
            GetConnectionSettings();
            session = new Session(host, port, userName, password);
            session.Execute("open " + databaseName);
        }
        protected override void GetConnectionSettings()
        {
            XmlReader xmlReader = XmlReader.Create(new StreamReader("connectionSettings.xml"));

            while (xmlReader.Read())
            {
                if((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "baseX"))
                {
                    xmlReader.ReadToFollowing("host");
                    host = xmlReader.ReadElementContentAsString();
                    xmlReader.ReadToFollowing("port");
                    port = xmlReader.ReadElementContentAsInt();
                    xmlReader.ReadToFollowing("userName");
                    userName = xmlReader.ReadElementContentAsString();
                    xmlReader.ReadToFollowing("password");
                    password = xmlReader.ReadElementContentAsString();
                }
            }
        }
    }
}