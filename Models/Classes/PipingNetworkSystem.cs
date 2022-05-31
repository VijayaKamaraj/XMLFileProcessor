using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class PipingNetworkSystem
    {
        private Extent extentField;

        private GenericAttributes genericAttributesField;

        private PipingNetworkSegment[] pipingNetworkSegmentField;

        public PropertyBreak[] propertyBreakField;

        private PersistentID persistentIDField;
        private NominalDiameter nominalDiameterField;
        private Presentation presentationField;
        private Text[] textField;

        private string idField;

        private string tagNameField;
        private string componentClassField;

        private string componentClassURIField;
        private string specificationField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Specification
        {
            get
            {
                return this.specificationField;
            }
            set
            {
                this.specificationField = value;
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

        [System.Xml.Serialization.XmlElementAttribute("PipingNetworkSegment")]
        public PipingNetworkSegment[] PipingNetworkSegment
        {
            get
            {
                return this.pipingNetworkSegmentField;
            }
            set
            {
                this.pipingNetworkSegmentField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Text")]
        public Text[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("PropertyBreak")]
        public PropertyBreak[] PropertyBreak
        {
            get
            {
                return this.propertyBreakField;
            }
            set
            {
                this.propertyBreakField = value;
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
