using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class CenterLine
    {
        private Presentation presentationField;

        private Extent extentField;

        private Coordinate[] coordinateField;

        private PersistentID persistentIDField;

        private string idField;

        private byte numPointsField;


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


        [System.Xml.Serialization.XmlElementAttribute("Coordinate")]
        public Coordinate[] Coordinate
        {
            get
            {
                return this.coordinateField;
            }
            set
            {
                this.coordinateField = value;
            }
        }

        public PersistentID PersistentID
        {
            get
            {
                return this.persistentIDField;
            }
            set
            {
                this.persistentIDField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
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
    }
}
