﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
   public class PolyLine
    {
        private Presentation presentationField;

        private Extent extentField;

        private Coordinate[] coordinateField;

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
