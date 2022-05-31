using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Node
    {
        private NodePosition nodepositionField;
        private GenericAttributes genericAttributesField;
        private NominalDiameter nominalDiameterField;

        private byte nameField;

        private bool nameFieldSpecified;
        private string typeField;
        private string idField;

        private Position positionField;

         public Position Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        public NominalDiameter NominalDiameter
        {
            get
            {
                return this.nominalDiameterField;
            }
            set
            {
                this.nominalDiameterField = value;
            }
        }

        public NodePosition NodePosition
        {
            get
            {
                return this.nodepositionField;
            }
            set
            {
                this.nodepositionField = value;
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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Name
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

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NameSpecified
        {
            get
            {
                return this.nameFieldSpecified;
            }
            set
            {
                this.nameFieldSpecified = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
}
