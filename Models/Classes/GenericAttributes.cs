using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class GenericAttributes
    {

        private GenericAttribute[] genericAttributeField;

        private string numberField;

        private string setField;

        [System.Xml.Serialization.XmlElementAttribute("GenericAttribute")]
        public GenericAttribute[] GenericAttribute
        {
            get
            {
                return this.genericAttributeField;
            }
            set
            {
                this.genericAttributeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Set
        {
            get
            {
                return this.setField;
            }
            set
            {
                this.setField = value;
            }
        }
    }
}
