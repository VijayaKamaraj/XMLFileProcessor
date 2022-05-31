using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class NodePosition
    {
        private Location locationField;

        private Axis axisField;

        private Reference referenceField;

        public Location Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        public Axis Axis
        {
            get
            {
                return this.axisField;
            }
            set
            {
                this.axisField = value;
            }
        }

        public Reference Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }
}
