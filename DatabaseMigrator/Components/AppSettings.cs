using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Xml;
using DatabaseMigrator.Dtos;

namespace DatabaseMigrator.Components
{
    public static class AppSettings
    {
        public static List<MigrationNamespace> GetMigrationNamespaces()
        {
            var  migrationNamespaces = new List<MigrationNamespace>();
            string filePath = "MigrationNamespaces.config";

            var doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodes = doc.SelectNodes("//MigrationNamespace");
            if (nodes == null)
                throw new ApplicationException("invalid data");

            foreach (XmlNode node in nodes)
            {
                
                string name = node.Attributes["Name"].Value;
                string path = node.Attributes["Path"].Value;

                migrationNamespaces.Add(new MigrationNamespace { Name = name, Path = path });
                
            }
            return migrationNamespaces;
        }
    }
}
