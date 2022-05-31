using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Line
    {
        private Presentation presentationField;

        private Extent extentField;

        private Coordinate[] coordinateField;


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

    }
}
