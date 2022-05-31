using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class CrossPageConnection
    {
        private LinkedPersistentID linkedPersistentIDField;

        private string drawingNameField;

        private string linkLabelField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DrawingName
        {
            get
            {
                return this.drawingNameField;
            }
            set
            {
                this.drawingNameField = value;
            }
        }

    
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LinkLabel
        {
            get
            {
                return this.linkLabelField;
            }
            set
            {
                this.linkLabelField = value;
            }
        }
        public LinkedPersistentID LinkedPersistentID
        {
            get
            {
                return this.linkedPersistentIDField;
            }
            set
            {
                this.linkedPersistentIDField = value;
            }
        }
    }
}
