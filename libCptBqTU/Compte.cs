using System.Collections;
using System.Reflection.Metadata;

namespace libCptBqTU
{
    public class Compte
    {
        /// <summary>
        /// Propriétés implémentées automatiquement
        /// </summary>
        public int Numero { get; set; }
        public string Nom { get; set; }
        public decimal Solde { get; set; }
        public decimal DecouvertAutorise { get; set; }
        public ArrayList mesMouvements { get; set; }

        /// <summary>
        /// Constructeur à 4 arguments
        /// </summary>
        /// <param name="numero">le numéro</param>
        /// <param name="nom">le nom</param>
        /// <param name="solde">le solde</param>
        /// <param name="decouvertAutorise">le découvert autorisé</param>
        public Compte(int numero, string nom, decimal solde, decimal decouvertAutorise)
        {
            this.Numero = numero;
            this.Nom = nom;
            this.Solde = solde;
            this.DecouvertAutorise = decouvertAutorise;
            this.mesMouvements = new ArrayList();
  
        }
        /// <summary>
        /// Constructeur de compte par défaut
        /// </summary>
        public Compte()
        {

        }
        /// <summary>
        /// Réecriture de la méthode ToString
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string mvts = "";
            string main = $"Numero:{this.Numero},Nom:{this.Nom},Solde:{this.Solde},Decouvert Autorisé:{this.DecouvertAutorise}\n";
            foreach (Mouvement m in mesMouvements)
            {
                mvts += m.ToString()+"\n";
            }
            return main + mvts;
        }

        /// <summary>
        /// Crédite le compte du montant spécifié
        /// </summary>
        /// <param name="montant">Le montant à créditer</param>
        public void Crediter(decimal montant)
        {
            this.Solde += montant;
        }


        /// <summary>
        /// Débite le compte du montant spécifié si le solde le permet
        /// </summary>
        /// <param //name="t">Le montant à débiter</param>
        /// <returns>True si le débit a été effectué, False sinon</returns>
        public bool Debiter(decimal montant)
        {
            this.Solde -= montant;
            return true;
        }


        /// <summary>
        /// Transférer un montant vers un autre compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="compteDestination"></param>
        /// <returns></returns>
        public bool Transferer(decimal montant,Compte compte)
        {
            this.Solde -= montant;
            compte.Solde += montant;
            return true;
        }


        /// <summary>
        /// Savoir si le solde est supérieur à celui d'un autre compte
        /// </summary>
        /// <param name="compteDestination"></param>
        /// <returns></returns>
        public bool Superieur(Compte compte)
        {
            return this.Solde>compte.Solde;
        }
        public void AjouterMouvement(Mouvement mvt)
        {
            mesMouvements.Add(mvt);
        }
        public void AjouterMouvement(double mont,DateTime date,Tipe type)
        {
            mesMouvements.Add(new Mouvement(mont,date,type));
        }
    }
}
