using System.Numerics;
using libCptBqTU;

namespace Banque
{
    class Banque
    {
        private List<Compte> mesComptes;
        public Banque()
        {
            mesComptes = new List<Compte>();
        }
        public void AjouterCompte(Compte compte)
        {
            mesComptes.Add(compte);
        }
        public string ToString()
        {
            string res = "";
            foreach (var compte in mesComptes) { res += compte.ToString() + "\n"; }
            return res;
        }
    }
}
