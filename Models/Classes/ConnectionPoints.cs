using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class ConnectionPoints
    {
        private Presentation presentationField;

        private Extent extentField;

        private Node[] nodeField;

        private byte numPointsField;

        private byte flowInField;

        private bool flowInFieldSpecified;

        private byte flowOutField;

        private bool flowOutFieldSpecified;

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

        [System.Xml.Serialization.XmlElementAttribute("Node")]
        public Node[] Node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }


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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte FlowIn
        {
            get
            {
                return this.flowInField;
            }
            set
            {
                this.flowInField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FlowInSpecified
        {
            get
            {
                return this.flowInFieldSpecified;
            }
            set
            {
                this.flowInFieldSpecified = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte FlowOut
        {
            get
            {
                return this.flowOutField;
            }
            set
            {
                this.flowOutField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FlowOutSpecified
        {
            get
            {
                return this.flowOutFieldSpecified;
            }
            set
            {
                this.flowOutFieldSpecified = value;
            }
        }
    }
}
