using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Extent
    {

        private Min minField;

        private Max maxField;

        public Min Min
        {
            get
            {
                return this.minField;
            }
            set
            {
                this.minField = value;
            }
        }

        public Max Max
        {
            get
            {
                return this.maxField;
            }
            set
            {
                this.maxField = value;
            }
        }
    }
}
