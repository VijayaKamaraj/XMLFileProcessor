using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
   public  class PipingNetworkSegment
    {
        private Association associationField;
        private Component[] componentField;
        private CenterLine centerLineField;
        private Connection connectionField;
        private Extent extentField;
        private GenericAttributes[] genericAttributesField;
        private Label[] labelField;
        private PersistentID persistentIDField;

        private MaximumDesignPressure maximumDesignPressureField;

        private NominalDiameter nominalDiameterField;

        public PipeConnectorSymbol pipeConnectorSymbolField;

        private PipeFlowArrow pipeFlowArrowField;
        public PipingComponent[] pipingComponentField;
        private ProcessInstrument processInstrumentField;
        private Position positionField;
        private Presentation presentationField;
        private Text[] textField;
        private Shape[] shapeField;

        private string specificationField;
        private string idField;

        private string tagNameField;

        private string componentClassField;

        private string componentClassURIField;

        private bool dualFlowField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Specification
        {
            get
            {
                return this.specificationField;
            }
            set
            {
                this.specificationField = value;
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

        public CenterLine CenterLine
        {
            get
            {
                return this.centerLineField;
            }
            set
            {
                this.centerLineField = value;
            }
        }
        public Connection Connection
        {
            get
            {
                return this.connectionField;
            }
            set
            {
                this.connectionField = value;
            }
        }
       

        [System.Xml.Serialization.XmlElementAttribute("GenericAttributes")]
        public GenericAttributes[] GenericAttributes
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

        [System.Xml.Serialization.XmlElementAttribute("Label")]
        public Label[] Label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
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


        [System.Xml.Serialization.XmlElementAttribute("Shape")]
        public Shape[] Shape
        {
            get
            {
                return this.shapeField;
            }
            set
            {
                this.shapeField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Component")]
        public Component[] Component
        {
            get
            {
                return this.componentField;
            }
            set
            {
                this.componentField = value;
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

        public NominalDiameter NominalDiameter 
        {
            get
            {
                return this.nominalDiameterField;
            }
            set
            {
                this.nominalDiameterField = value;
            }
        }

     
        public PipeConnectorSymbol PipeConnectorSymbol
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

        public PipeFlowArrow PipeFlowArrow
        {
            get
            {
                return this.pipeFlowArrowField;
            }
            set
            {
                this.pipeFlowArrowField = value;
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

        public ProcessInstrument ProcessInstrument
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

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DualFlow
        {
            get
            {
                return this.dualFlowField;
            }
            set
            {
                this.dualFlowField = value;
            }
        }
    }
}
