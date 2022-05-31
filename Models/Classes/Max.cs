using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Max
    {
        private double xField;

        private double yField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double X
        {
            get
            {
                return this.xField;
            }
            set
            {
                this.xField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Y
        {
            get
            {
                return this.yField;
            }
            set
            {
                this.yField = value;
            }
        }
    }
}
