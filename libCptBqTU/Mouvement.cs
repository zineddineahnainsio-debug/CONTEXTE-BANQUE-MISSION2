using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCptBqTU
{
    public class Mouvement
    {
        public double montant;
        public DateTime dateMvt;
        public Tipe leType;
        public Mouvement( double mont,DateTime date,Tipe type)
        {
            montant = mont;
            dateMvt = date;
            leType = type;
        }
        public string ToString()
        {
            string code = leType.GetCode();
            return $"montant: {montant}   date:{dateMvt}   code:{code}";
        }
    }
}
