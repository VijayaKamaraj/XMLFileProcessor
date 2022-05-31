using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Connection
    {
        private string fromIDField;

        private string toIDField;

        private byte fromNodeField;

        private bool fromNodeFieldSpecified;

        private byte toNodeField;

        private bool toNodeFieldSpecified;

     
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FromID
        {
            get
            {
                return this.fromIDField;
            }
            set
            {
                this.fromIDField = value;
            }
        }

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ToID
        {
            get
            {
                return this.toIDField;
            }
            set
            {
                this.toIDField = value;
            }
        }

  
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte FromNode
        {
            get
            {
                return this.fromNodeField;
            }
            set
            {
                this.fromNodeField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FromNodeSpecified
        {
            get
            {
                return this.fromNodeFieldSpecified;
            }
            set
            {
                this.fromNodeFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ToNode
        {
            get
            {
                return this.toNodeField;
            }
            set
            {
                this.toNodeField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToNodeSpecified
        {
            get
            {
                return this.toNodeFieldSpecified;
            }
            set
            {
                this.toNodeFieldSpecified = value;
            }
        }
    }
}
