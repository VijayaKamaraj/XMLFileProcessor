using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class PlantInformation
    {
        private UnitsOfMeasure unitsOfMeasureField;

        private string schemaVersionField;

        private string originatingSystemField;

        private System.DateTime dateField;

        private System.DateTime timeField;

        private string is3DField;

        private string unitsField;

        private string disciplineField;

        private string modelNameField;



        public UnitsOfMeasure UnitsOfMeasure
        {
            get
            {
                return this.unitsOfMeasureField;
            }
            set
            {
                this.unitsOfMeasureField = value;
            }
        }

     
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SchemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OriginatingSystem
        {
            get
            {
                return this.originatingSystemField;
            }
            set
            {
                this.originatingSystemField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ModelName
        {
            get
            {
                return this.modelNameField;
            }
            set
            {
                this.modelNameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

   
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "time")]
        public System.DateTime Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

          [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Is3D
        {
            get
            {
                return this.is3DField;
            }
            set
            {
                this.is3DField = value;
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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Discipline
        {
            get
            {
                return this.disciplineField;
            }
            set
            {
                this.disciplineField = value;
            }
        }
    }
}
