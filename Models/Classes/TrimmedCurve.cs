using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class TrimmedCurve
    {

        private Circle circleField;

        private double startAngleField;

        private double endAngleField;

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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double StartAngle
        {
            get
            {
                return this.startAngleField;
            }
            set
            {
                this.startAngleField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double EndAngle
        {
            get
            {
                return this.endAngleField;
            }
            set
            {
                this.endAngleField = value;
            }
        }
    }
}
