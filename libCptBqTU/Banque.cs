using System.Numerics;

namespace libCptBqTU
{
    public class Banque
    {
        private List<Compte> mesComptes;
        private List<Tipe> mesTypes;
        public Banque()
        {
            mesComptes = new List<Compte>();
            mesTypes = new List<Tipe>();
        }
        public void AjouterCompte(int numero, string nom, decimal solde, decimal decouvertAutorise)
        {
            mesComptes.Add(new Compte(numero, nom, solde, decouvertAutorise));
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
        public Compte RendCompte(int num)
        {
                foreach (Compte compte in mesComptes)
                {
                    if (compte.Numero == num) 
                    { 
                        return compte;
                    }
                }
            return null;
        }
        public void AjouterType(string code, string libelle, char sens)
        {
            this.mesTypes.Add(new Tipe(code, libelle, sens));
        }
        public void AjouterType(Tipe unType)
        {
            this.mesTypes.Add(unType);
        }
        public Tipe GetType(string code)
        {
            foreach (Tipe type in mesTypes)
            {
                if (type.code == code)
                {
                    return type;
                }
            }
            return null;
        }
    }
}
