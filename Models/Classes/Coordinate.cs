using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Coordinate
    {
        private decimal xField;

        private decimal yField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal X
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
        public decimal Y
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
