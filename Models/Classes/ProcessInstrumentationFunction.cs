using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class ProcessInstrumentationFunction
    {
        private ActuatingFunction actuatingFunctionField;
        private Association[] associationField;
        private ConnectionPoints connectionPointsField;
        private GenericAttributes genericAttributesField;
        private Extent extentField;
        private InformationFlow[] informationFlowField;
        private PersistentID persistentIDField;
        private Position positionField;
        private Presentation presentationField;
        private ProcessSignalGeneratingFunction processSignalGeneratingFunctionField;
        private Scale scaleField;
        private Line[] lineField;
        private TrimmedCurve[] trimmedCurveField;
        private Text textField;
        private string idField;

        private string tagNameField;

        private string componentClassField;

        private string componentNameField;

        private string componentClassURIField;

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

        [System.Xml.Serialization.XmlElementAttribute("Association")]
        public Association[] Association
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

        public Text Text
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

        public ConnectionPoints ConnectionPoints
        {

            get
            {
                return this.connectionPointsField;
            }
            set
            {
                this.connectionPointsField = value;
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

        

         public ActuatingFunction ActuatingFunction
        {

            get
            {
                return this.actuatingFunctionField;
            }
            set
            {
                this.actuatingFunctionField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("InformationFlow")]
        public InformationFlow[] InformationFlow
        {

            get
            {
                return this.informationFlowField;
            }
            set
            {
                this.informationFlowField = value;
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


        public ProcessSignalGeneratingFunction ProcessSignalGeneratingFunction
        {

            get
            {
                return this.processSignalGeneratingFunctionField;
            }
            set
            {
                this.processSignalGeneratingFunctionField = value;
            }
        }



    }
}
