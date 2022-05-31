using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Shape
    {
        private Presentation presentationField;

        private Extent extentField;

        private Coordinate[] coordinateField;

        private byte numPointsField;

        private string filledField;

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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Coordinate")]
        public Coordinate[] Coordinate
        {
            get
            {
                return this.coordinateField;
            }
            set
            {
                this.coordinateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte NumPoints
        {
            get
            {
                return this.numPointsField;
            }
            set
            {
                this.numPointsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Filled
        {
            get
            {
                return this.filledField;
            }
            set
            {
                this.filledField = value;
            }
        }
    }
}
