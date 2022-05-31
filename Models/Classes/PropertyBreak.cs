using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class PropertyBreak
    {
        private Position positionField;
        private PolyLine polyLineField;
        private Presentation presentationField;
        private Extent extentField;
        private Line[] lineField;
        private Text[] textField;
        private GenericAttributes genericAttributesField;
        private ConnectionPoints connectionPointsField;
        private Shape[] shapeField;
        private Scale scaleField;

        private PersistentID persistentIDField;
        private string idField;

        private string componentClassField;

        private string componentNameField;
        private string componentClassURIField;

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

        public PolyLine PolyLine
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

        [System.Xml.Serialization.XmlElementAttribute("Presentation")]
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

        [System.Xml.Serialization.XmlElementAttribute("Extent")]
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


        [System.Xml.Serialization.XmlElementAttribute("Position")]
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
