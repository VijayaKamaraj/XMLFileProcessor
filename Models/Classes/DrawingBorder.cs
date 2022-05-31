using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{

        public class DrawingBorder
        {
            private Presentation presentationField;

            private Extent extentField;

            private Line[] lineField;

            private Text[] textField;
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


        }
    }

