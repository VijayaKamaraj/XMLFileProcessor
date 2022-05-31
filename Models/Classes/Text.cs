using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Text
    {
        private Presentation presentationField;

        private Extent extentField;

        private Position positionField;

        private string stringField;

        private string fontField;

        private string justificationField;

        private decimal widthField;

        private decimal heightField;

        private double textAngleField;


        private double slantAngleField;

        private string dependantAttributeField;

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
        public string String
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }

   
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Font
        {
            get
            {
                return this.fontField;
            }
            set
            {
                this.fontField = value;
            }
        }

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Justification
        {
            get
            {
                return this.justificationField;
            }
            set
            {
                this.justificationField = value;
            }
        }

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double TextAngle
        {
            get
            {
                return this.textAngleField;
            }
            set
            {
                this.textAngleField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double SlantAngle
        {
            get
            {
                return this.slantAngleField;
            }
            set
            {
                this.slantAngleField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DependantAttribute
        {
            get
            {
                return this.dependantAttributeField;
            }
            set
            {
                this.dependantAttributeField = value;
            }
        }
    }
}
