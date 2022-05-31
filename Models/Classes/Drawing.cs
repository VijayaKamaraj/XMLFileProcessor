using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Drawing
    {

        private Presentation presentationField;

        private Extent extentField;

        private DrawingBorder drawingBorderField;

        private GenericAttributes genericAttributesField;

        private Label[] labelField;
        private Circle[] circleField;
        private PolyLine[] polyLineField;
        private Shape[] shapeField;
        private Text[] textField;

        private string nameField;

        private string typeField;

        private string sizeField;
        private string revisionField;

        private string titleField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Revision
        {
            get
            {
                return this.revisionField;
            }
            set
            {
                this.revisionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    

    /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
        public DrawingBorder DrawingBorder
        {
            get
            {
                return this.drawingBorderField;
            }
            set
            {
                this.drawingBorderField = value;
            }
        }

        /// <remarks/>
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

        [System.Xml.Serialization.XmlElementAttribute("Label")]
        public Label[] Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Circle")]
        public Circle[] Circle
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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
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

   
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
    }
}
