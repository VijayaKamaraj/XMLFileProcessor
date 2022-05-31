using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Component
    {
        private Extent extentField;

        private Presentation presentationField;

        private PersistentID persistentIDField;

        private PolyLine polyLineField;

        private Shape[] shapeField;

        private string idField;

        private string componentClassField;

       
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


        public PolyLine PolyLine
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
    }
}
