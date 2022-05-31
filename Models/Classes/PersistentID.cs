using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class PersistentID
    {
        private string identifierField;

        private string contextField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Context
        {
            get
            {
                return this.contextField;
            }
            set
            {
                this.contextField = value;
            }
        }
    }
}
