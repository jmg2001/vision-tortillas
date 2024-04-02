using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    public class Settings
    {
        [Serializable]
        public struct Product_Configuration
        {
            public string Code;
            public string Description;
            public float Max_Diameter;
            public float Min_Diameter;
            public float Max_Ovality;
            public float Max_Compacity;
        }
    }
}
