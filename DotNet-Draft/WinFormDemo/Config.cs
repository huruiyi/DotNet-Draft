using System.Collections.Generic;

namespace WinFormDemo
{
    public class Config
    {
        public string CompareToolPath { get; set; }

        public string Dir_Org { get; set; }

        public string Dir_Before { get; set; }

        /// <summary>
        /// xx中的全部文件(4)个
        /// </summary>
        public List<string> FourPath { get; set; }

        public List<string> ThreePath { get; internal set; }

        public string VipSbusPath { get; set; }

        public string GipSbusPath { get; set; }

        public string C53_GIPSbusPath { get; set; }

        public string C53MakePath { get; set; }
        public string VgwPath { get; set; }
        public string VgwDstPath { get; set; }
    }
}