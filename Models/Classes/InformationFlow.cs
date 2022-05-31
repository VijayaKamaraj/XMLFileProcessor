using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
   public class InformationFlow
    {
        private Association[] associationField;
        private GenericAttributes genericAttributesField;
        private CenterLine centerLineField;
        private Connection connectionField;
        private Extent extentField;
        private PersistentID persistentIDField;
        private Presentation presentationField;

        private string idField;

        private string componentClassField;

        private string componentNameField;

        private string componentClassURIField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentClass
        {
            get
            {
                return this.componentClassField;
            }
            set
            {
                this.componentClassField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentName
        {
            get
            {
                return this.componentNameField;
            }
            set
            {
                this.componentNameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentClassURI
        {
            get
            {
                return this.componentClassURIField;
            }
            set
            {
                this.componentClassURIField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Association")]
        public Association[] Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }

        public GenericAttributes GenericAttributes
        {
            get
            {
                return this.genericAttributesField;
            }
            set
            {
                this.genericAttributesField = value;
            }
        }

        public Extent Extent
        {
            get
            {
                return this.extentField;
            }
            set
            {
                this.extentField = value;
            }
        }
        public PersistentID PersistentID
        {
            get
            {
                return this.persistentIDField;
            }
            set
            {
                this.persistentIDField = value;
            }
        }
        public Presentation Presentation
        {
            get
            {
                return this.presentationField;
            }
            set
            {
                this.presentationField = value;
            }
        }

        public Connection Connection
        {
            get
            {
                return this.connectionField;
            }
            set
            {
                this.connectionField = value;
            }
        }
        public CenterLine CenterLine
        {
            get
            {
                return this.centerLineField;
            }
            set
            {
                this.centerLineField = value;
            }
        }

    }
}
