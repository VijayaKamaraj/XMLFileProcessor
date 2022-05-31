using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
   public class MaximumDesignTemperature
    {
        private byte valueField;

        private string unitsField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
    }
}
