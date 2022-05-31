using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Axis
    {
        private double xField;

        private double yField;

        private double zField;

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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Z
        {
            get
            {
                return this.zField;
            }
            set
            {
                this.zField = value;
            }
        }
    }
}
