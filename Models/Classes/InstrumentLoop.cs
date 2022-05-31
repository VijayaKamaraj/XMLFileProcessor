using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class InstrumentLoop

    {
        private PersistentID persistentIDField;
        private Association[] associationField;

        private string idField;

        private string tagNameField;

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

    }
}
