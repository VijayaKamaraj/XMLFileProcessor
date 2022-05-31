using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Presentation
    {
        private string layerField;

        private string colorField;

        private string lineTypeField;

        private string lineWeightField;

        private double rField;

        private double gField;

        private double bField;

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Layer
        {
            get
            {
                return this.layerField;
            }
            set
            {
                this.layerField = value;
            }
        }

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }

   
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LineType
        {
            get
            {
                return this.lineTypeField;
            }
            set
            {
                this.lineTypeField = value;
            }
        }

   
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LineWeight
        {
            get
            {
                return this.lineWeightField;
            }
            set
            {
                this.lineWeightField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double R
        {
            get
            {
                return this.rField;
            }
            set
            {
                this.rField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double G
        {
            get
            {
                return this.gField;
            }
            set
            {
                this.gField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double B
        {
            get
            {
                return this.bField;
            }
            set
            {
                this.bField = value;
            }
        }
    }
}
