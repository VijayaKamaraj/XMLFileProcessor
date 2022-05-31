using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class PlantModel
    {
        private PlantInformation plantInformationField;
        private ShapeCatalogue shapeCatalogueField;

        private ProcessInstrumentationFunction[] processInstrumentationFunctionField;
        private InstrumentationLoopFunction[] instrumentationLoopFunctionField;
        private ActuatingSystem[] actuatingSystemField;

        private Extent extentField;

        private Drawing drawingField;

        private Equipment[] equipmentField;

        private PipingNetworkSystem[] pipingNetworkSystemField;

        private InstrumentComponent[] instrumentComponentField;

        private InstrumentLoop[] instrumentLoopField;

        private SignalLine[] signalLineField;

        public PlantInformation PlantInformation
        {
            get
            {
                return this.plantInformationField;
            }
            set
            {
                this.plantInformationField = value;
            }
        }

        public ShapeCatalogue ShapeCatalogue
        {
            get
            {
                return this.shapeCatalogueField;
            }
            set
            {
                this.shapeCatalogueField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ProcessInstrumentationFunction")]
        public ProcessInstrumentationFunction[] ProcessInstrumentationFunction
        {
            get
            {
                return this.processInstrumentationFunctionField;
            }
            set
            {
                this.processInstrumentationFunctionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("InstrumentationLoopFunction")]
        public InstrumentationLoopFunction[] InstrumentationLoopFunction
        {
            get
            {
                return this.instrumentationLoopFunctionField;
            }
            set
            {
                this.instrumentationLoopFunctionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ActuatingSystem")]
        public ActuatingSystem[] ActuatingSystem
        {
            get
            {
                return this.actuatingSystemField;
            }
            set
            {
                this.actuatingSystemField = value;
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

        public Drawing Drawing
        {
            get
            {
                return this.drawingField;
            }
            set
            {
                this.drawingField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Equipment")]
        public Equipment[] Equipment
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


        [System.Xml.Serialization.XmlElementAttribute("PipingNetworkSystem")]
        public PipingNetworkSystem[] PipingNetworkSystem
        {
            get
            {
                return this.pipingNetworkSystemField;
            }
            set
            {
                this.pipingNetworkSystemField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("InstrumentComponent")]
        public InstrumentComponent[] InstrumentComponent
        {
            get
            {
                return this.instrumentComponentField;
            }
            set
            {
                this.instrumentComponentField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("InstrumentLoop")]
        public InstrumentLoop[] InstrumentLoop
        {
            get
            {
                return this.instrumentLoopField;
            }
            set
            {
                this.instrumentLoopField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("SignalLine")]
        public SignalLine[] SignalLine
        {
            get
            {
                return this.signalLineField;
            }
            set
            {
                this.signalLineField = value;
            }
        }

    }
}
