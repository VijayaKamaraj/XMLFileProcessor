using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class InstrumentationLoopFunction
    {
        private GenericAttributes genericAttributesField;

        private Association associationField;

        private string idField;

        private string tagNameField;

        private string componentClassField;

        private string componentClassURIField;

    
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

        public Association Association
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
        public string TagName
        {
            get
            {
                return this.tagNameField;
            }
            set
            {
                this.tagNameField = value;
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
    }
}
