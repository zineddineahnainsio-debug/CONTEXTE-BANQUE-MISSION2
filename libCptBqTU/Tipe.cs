using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCptBqTU
{
    public class Tipe
    {
        public string code;
        public string libellé;
        public char sens;
        public Tipe(string cod, string libell, char _sens)
        {
            code = cod;
            libellé = libell;
            sens = _sens;
        }
        public string GetCode()
        {
            return code;
        }
        public string ToString()
        {
            return $"code : {code}   libellé : {libellé}    sens : {sens}";
        }
    }
}
