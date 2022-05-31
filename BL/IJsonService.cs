using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLWebApiCore.Models.DBClasses;

namespace XMLWebApiCore.BL
{
    public interface IJsonService
    {
      public  string CreateJson(string name);
    }
}