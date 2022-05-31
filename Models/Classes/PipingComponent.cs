using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class PipingComponent
    {

        private Circle circleField;
        private PersistentID persistentIDField;

        private Position positionField;

        private GenericAttributes genericAttributesField;

        private Presentation presentationField;

        private Extent extentField;

        private Line[] lineField;

        private ConnectionPoints connectionPointsField;

        private Text[] textField;

        private PolyLine[] polyLineField;
        private Shape[] shapeField;
        private Scale scaleField;
        private NominalDiameter nominalDiameterField;

        private string idField;

        private string componentClassField;

        private string componentNameField;

        private string componentClassURIField;
        private string specificationField;

        private string tagNameField;

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

        /// <remarks/>
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



        [System.Xml.Serialization.XmlElementAttribute("Circle")]
        public Circle Circle
        {
            get
            {
                return this.circleField;
            }
            set
            {
                this.circleField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("PolyLine")]
        public PolyLine[] PolyLine
        {
            get
            {
                return this.polyLineField;
            }
            set
            {
                this.polyLineField = value;
            }
        }

        public Scale Scale
        {
            get
            {
                return this.scaleField;
            }
            set
            {
                this.scaleField = value;
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

        [System.Xml.Serialization.XmlElementAttribute("Shape")]
        public Shape[] Shape
        {
            get
            {
                return this.shapeField;
            }
            set
            {
                this.shapeField = value;
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

        [System.Xml.Serialization.XmlElementAttribute("Line")]
        public Line[] Line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }


        public ConnectionPoints ConnectionPoints
        {
            get
            {
                return this.connectionPointsField;
            }
            set
            {
                this.connectionPointsField = value;
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
    }
}
