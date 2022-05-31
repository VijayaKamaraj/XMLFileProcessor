using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class ShapeCatalogue
    {
        private ActuatingSystemComponent[] actuatingSystemComponentsField;
        private Equipment[] equipmentField;
        private Nozzle[] nozzleField;
        private PipingComponent[] pipingComponentField;
        private ProcessInstrumentationFunction[] processInstrumentationFunctionField;
        private PipeConnectorSymbol[] pipeConnectorSymbolField;
        private ProcessInstrument[] processInstrumentField;
        private PropertyBreak[] propertyBreakField;

        private string nameField;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ActuatingSystemComponent")]
        public ActuatingSystemComponent[] ActuatingSystemComponent
        {
            get
            {
                return this.actuatingSystemComponentsField;
            }
            set
            {
                this.actuatingSystemComponentsField = value;
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


        [System.Xml.Serialization.XmlElementAttribute("PipingComponent")]
        public PipingComponent[] PipingComponent
        {
            get
            {
                return this.pipingComponentField;
            }
            set
            {
                this.pipingComponentField = value;
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

        [System.Xml.Serialization.XmlElementAttribute("PipeConnectorSymbol")]
        public PipeConnectorSymbol[] PipeConnectorSymbol
        {
            get
            {
                return this.pipeConnectorSymbolField;
            }
            set
            {
                this.pipeConnectorSymbolField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("ProcessInstrument")]
        public ProcessInstrument[] ProcessInstrument
        {
            get
            {
                return this.processInstrumentField;
            }
            set
            {
                this.processInstrumentField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute("PropertyBreak")]
        public PropertyBreak[] PropertyBreak
        {
            get
            {
                return this.propertyBreakField;
            }
            set
            {
                this.propertyBreakField = value;
            }
        }
    }
}
