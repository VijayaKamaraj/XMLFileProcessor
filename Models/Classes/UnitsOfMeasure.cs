using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class UnitsOfMeasure
    {
        private string distanceField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }
    }
}
