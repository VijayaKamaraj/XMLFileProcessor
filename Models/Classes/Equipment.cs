using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLWebApiCore.Models.Classes
{
    public class Equipment
    {
        private string descriptionField;
        private Line[] lineField;
        private Text[] textField;
        private PersistentID persistentIDField;
        private Position positionField;
        private Presentation presentationField;
        private Extent extentField;
        private TrimmedCurve[] trimmedCurveField;
        private string idField;
        private Circle circleField;
        private Scale scaleField;
        private Equipment equipmentField;
        private PolyLine[] polyLineField;
        private string stockNumberField;
        private Association associationField;

        private GenericAttributes genericAttributesField;

        private string componentClassURIField;

        private string tagNameField;

        private string componentClassField;

        private string componentNameField;

        private Nozzle[] nozzleField;

        private MaximumDesignPressure maximumDesignPressureField;
        private MinimumDesignPressure minimumDesignPressureField;

        private MaximumDesignTemperature maximumDesignTemperatureField;
        private MinimumDesignTemperature minimumDesignTemperatureField;

        [System.Xml.Serialization.XmlElementAttribute("Line")]
        public Line[] Line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("PolyLine")]
        public PolyLine[] PolyLine
        {
            get
            {
                return this.polyLineField;
            }
            set
            {
                this.polyLineField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Equipment")]
        public Equipment Equipments
        {
            get
            {
                return this.equipmentField;
            }
            set
            {
                this.equipmentField = value;
            }
        }

        public Association Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }

        public GenericAttributes GenericAttributes
        {
            get
            {
                return this.genericAttributesField;
            }
            set
            {
                this.genericAttributesField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Text")]
        public Text[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        [XmlElement(ElementName = "Description")]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }


        public Scale Scale
        {
            get
            {
                return this.scaleField;
            }
            set
            {
                this.scaleField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Presentation")]
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

        [System.Xml.Serialization.XmlElementAttribute("Extent")]
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


        [System.Xml.Serialization.XmlElementAttribute("Position")]
        public Position Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("PersistentID")]

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

        [System.Xml.Serialization.XmlElementAttribute("TrimmedCurve")]
        public TrimmedCurve[] TrimmedCurve
        {
            get
            {
                return this.trimmedCurveField;
            }
            set
            {
                this.trimmedCurveField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
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
        public string TagName
        {
            get
            {
                return this.tagNameField;
            }
            set
            {
                this.tagNameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentClass
        {
            get
            {
                return this.componentClassField;
            }
            set
            {
                this.componentClassField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StockNumber
        {
            get
            {
                return this.stockNumberField;
            }
            set
            {
                this.stockNumberField = value;
            }
        }



        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentName
        {
            get
            {
                return this.componentNameField;
            }
            set
            {
                this.componentNameField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComponentClassURI
        {
            get
            {
                return this.componentClassURIField;
            }
            set
            {
                this.componentClassURIField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Nozzle")]
        public Nozzle[] Nozzle
        {
            get
            {
                return this.nozzleField;
            }
            set
            {
                this.nozzleField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Circle")]
        public Circle Circle
        {
            get
            {
                return this.circleField;
            }
            set
            {
                this.circleField = value;
            }
        }


        public MaximumDesignTemperature MaximumDesignTemperature
        {
            get
            {
                return this.maximumDesignTemperatureField;
            }
            set
            {
                this.maximumDesignTemperatureField = value;
            }
        }

        public MinimumDesignTemperature MinimumDesignTemperature
        {
            get
            {
                return this.minimumDesignTemperatureField;
            }
            set
            {
                this.minimumDesignTemperatureField = value;
            }
        }

        public MaximumDesignPressure MaximumDesignPressure
        {
            get
            {
                return this.maximumDesignPressureField;
            }
            set
            {
                this.maximumDesignPressureField = value;
            }
        }

        public MinimumDesignPressure MinimumDesignPressure
        {
            get
            {
                return this.minimumDesignPressureField;
            }
            set
            {
                this.minimumDesignPressureField = value;
            }
        }


    }
}
