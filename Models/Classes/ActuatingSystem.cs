using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class ActuatingSystem
    {
        private Association associationField;

        private GenericAttributes genericAttributesField;

        private ActuatingSystemComponent[] actuatingSystemComponentField;

        private string idField;

        private string componentClassField;

        private string componentClassURIField;

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


        [System.Xml.Serialization.XmlElementAttribute("ActuatingSystemComponent")]
        public ActuatingSystemComponent[] ActuatingSystemComponent
        {
            get
            {
                return this.actuatingSystemComponentField;
            }
            set
            {
                this.actuatingSystemComponentField = value;
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
