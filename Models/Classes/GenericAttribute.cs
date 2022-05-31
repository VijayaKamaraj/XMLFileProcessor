using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class GenericAttribute
    {
        private string nameField;

        private string valueField;

        private string formatField;

        private string unitsField;
        private string attributeURIField;
        private string unitsURIField;
        private string valueURIField;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AttributeURI
        {
            get
            {
                return this.attributeURIField;
            }
            set
            {
                this.attributeURIField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UnitsURI
        {
            get
            {
                return this.unitsURIField;
            }
            set
            {
                this.unitsURIField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ValueURI
        {
            get
            {
                return this.valueURIField;
            }
            set
            {
                this.valueURIField = value;
            }
        }
    }
}
