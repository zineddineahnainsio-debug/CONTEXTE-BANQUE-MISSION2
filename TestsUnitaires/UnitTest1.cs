
using libCptBqTU;
using System.Reflection;

namespace TestsUnitaires
{
    [TestClass]
    public class TestCompte
    {
        [TestMethod]
        public void ClasseCompteExiste()
        {
            //Arranger
            Type compteType = typeof(Compte);
            //Auditer
            Assert.IsNotNull(compteType, "La classe Compte n'existe pas.");
        }
        [TestMethod]
        public void ConstructeurCompteExiste()
        {
            // Arranger
            Type compteType = typeof(Compte);
            Type[] parametersTypes = new Type[] { typeof(int), typeof(string), typeof(decimal), typeof(decimal) };

            // Agir
            ConstructorInfo constructeur = compteType.GetConstructor(parametersTypes);

            // Assert
            Assert.IsNotNull(constructeur, "Le constructeur Compte(string numero, string nom, decimal solde, decimal decouvertAutorise) n'existe pas.");


        }
        [TestMethod]
        public void ConstructeurSansParametres_InitialiseCorrectement()
        {
            // Arranger
            Compte compte = new Compte();

            // Assert
            Assert.AreEqual(0, compte.Numero, "Le numéro doit être initialisé à 0");
            Assert.AreEqual(0, compte.DecouvertAutorise, "Le découvert autorisé doit être initialisé à 0");
            Assert.AreEqual("", compte.Nom, "le nom doit être vide");
            Assert.AreEqual(0, compte.Solde, "Le solde doit être initialisé à 0");
        }
        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arranger
            Compte compte = new Compte
            {
                Numero = 123456,
                Nom = "toto",
                Solde = 1000.50m,
                DecouvertAutorise = -500.00m
            };

            string expected = "numero: 123456 nom: toto solde: 1000,50 decouvert autorisé: -500,00";

            // Agir
            string result = compte.ToString();

            // Assert
            Assert.AreEqual(expected, result, "La méthode ToString() ne retourne pas le format attendu.");
        }
        public void ToString_ReturnsFormatNull()
        {
            // Arranger
            Compte compte = new Compte
            {
                Numero = 0,
                Nom = "",
                Solde = 0.00m,
                DecouvertAutorise = 0.00m
            };

            string expected = "numero: 0 nom:  solde: 0,00 decouvert autorisé: 0,00";

            // Agir
            string result = compte.ToString();

            // Assert
            Assert.AreEqual(expected, result, "La méthode ToString() ne retourne pas le format attendu.");
        }
        [TestMethod]
        public void Crediter_AugmenteSolde_CorrectementTested()
        {
            // Arranger
            Compte compte = new Compte(1, "Test", 1000m, 500m);
            decimal montantCredit = 500m;
            decimal soldeAttendu = 1500m;

            // Agir
            compte.Crediter(montantCredit);

            // Assert
            Assert.AreEqual(soldeAttendu, compte.Solde, "Le solde n'a pas été correctement crédité");
        }

        [TestMethod]
        public void Crediter_AvecMontantNegatif_AugmenteSoldeTested()
        {
            // Arranger
            Compte compte = new Compte(2, "Test2", 1000m, 500m);
            decimal montantCredit = -200m;
            decimal soldeInitial = compte.Solde;

            // Agir
            compte.Crediter(montantCredit);

            // Assert
            Assert.AreEqual(soldeInitial, compte.Solde, "Le solde ne devrait pas changer lors d'un crédit négatif");
        }

        [TestMethod]
        public void Crediter_AvecZero_NePasChanferSoldeTested()
        {
            // Arranger
            Compte compte = new Compte(3, "Test3", 1000m, 500m);
            decimal montantCredit = 0m;
            decimal soldeAttendu = 1000m;

            // Agir
            compte.Crediter(montantCredit);

            // Assert
            Assert.AreEqual(soldeAttendu, compte.Solde, "Le solde ne devrait pas changer lors d'un crédit de zéro");
        }
        [TestMethod]
        public void Transferer_MontantValideEntreSoldesSuffisants_TransfertReussiTested()
        {
            // Arranger
            Compte compteSource = new Compte(1, "Source", 1000m, 500m);
            Compte compteDestination = new Compte(2, "Destination", 500m, 500m);
            decimal montantTransfert = 300m;

            // Agir
            bool resultat = compteSource.Transferer(montantTransfert, compteDestination);

            // Assert
            Assert.IsTrue(resultat, "Le transfert aurait dû réussir");
            Assert.AreEqual(700m, compteSource.Solde, "Le solde du compte source n'a pas été correctement débité");
            Assert.AreEqual(800m, compteDestination.Solde, "Le solde du compte destination n'a pas été correctement crédité");
        }

        [TestMethod]
        public void Transferer_MontantSuperieurAuSoldeDisponible_TransfertEchoueTested()
        {
            // Arranger
            Compte compteSource = new Compte(3, "Source", 1000m, 500m);
            Compte compteDestination = new Compte(4, "Destination", 500m, 500m);
            decimal montantTransfert = 1600m; // Supérieur au solde + découvert autorisé

            // Agir
            bool resultat = compteSource.Transferer(montantTransfert, compteDestination);

            // Assert
            Assert.IsFalse(resultat, "Le transfert aurait dû échouer");
            Assert.AreEqual(1000m, compteSource.Solde, "Le solde du compte source n'aurait pas dû changer");
            Assert.AreEqual(500m, compteDestination.Solde, "Le solde du compte destination n'aurait pas dû changer");
        }

        [TestMethod]
        public void Transferer_MontantNul_TransfertReussiSansChangementTested()
        {
            // Arranger
            Compte compteSource = new Compte(5, "Source", 1000m, 500m);
            Compte compteDestination = new Compte(6, "Destination", 500m, 500m);
            decimal montantTransfert = 0m;

            // Agir
            bool resultat = compteSource.Transferer(montantTransfert, compteDestination);

            // Assert
            Assert.IsFalse(resultat, "Le transfert d'un montant nul devrait échouer");
            Assert.AreEqual(1000m, compteSource.Solde, "Le solde du compte source n'aurait pas dû changer");
            Assert.AreEqual(500m, compteDestination.Solde, "Le solde du compte destination n'aurait pas dû changer");
        }

        [TestMethod]
        public void Transferer_MontantNegatif_TransfertEchoueTested()
        {
            // Arranger
            Compte compteSource = new Compte(7, "Source", 1000m, 500m);
            Compte compteDestination = new Compte(8, "Destination", 500m, 500m);
            decimal montantTransfert = -200m;

            // Agir
            bool resultat = compteSource.Transferer(montantTransfert, compteDestination);

            // Assert
            Assert.IsFalse(resultat, "Le transfert d'un montant négatif devrait échouer");
            Assert.AreEqual(1000m, compteSource.Solde, "Le solde du compte source n'aurait pas dû changer");
            Assert.AreEqual(500m, compteDestination.Solde, "Le solde du compte destination n'aurait pas dû changer");
        }
        [TestMethod]
        public void Superieur_SoldeSuperieur_RetourneTrueTested()
        {
            // Arrange
            Compte compte1 = new Compte(1, "Compte1", 1000m, 500m);
            Compte compte2 = new Compte(2, "Compte2", 500m, 500m);

            // Agir
            bool resultat = compte1.Superieur(compte2);

            // Assert
            Assert.IsTrue(resultat, "Le compte1 devrait être supérieur au compte2");
        }

        [TestMethod]
        public void Superieur_SoldeInferieur_RetourneFalseTested()
        {
            // Arrange
            Compte compte1 = new Compte(1, "Compte1", 500m, 500m);
            Compte compte2 = new Compte(2, "Compte2", 1000m, 500m);

            // Agir
            bool resultat = compte1.Superieur(compte2);

            // Assert
            Assert.IsFalse(resultat, "Le compte1 ne devrait pas être supérieur au compte2");
        }

        [TestMethod]
        public void Superieur_SoldesEgaux_RetourneFalseTested()
        {
            // Arrange
            Compte compte1 = new Compte(1, "Compte1", 1000m, 500m);
            Compte compte2 = new Compte(2, "Compte2", 1000m, 500m);

            // Agir
            bool resultat = compte1.Superieur(compte2);

            // Assert
            Assert.IsFalse(resultat, "Les comptes ayant des soldes égaux ne devraient pas être considérés comme supérieurs");
        }

        [TestMethod]
        public void Superieur_ComparaisonAvecSoldeNegatif_RetourneTrueTested()
        {
            // Arrange
            Compte compte1 = new Compte(1, "Compte1", 0m, 500m);
            Compte compte2 = new Compte(2, "Compte2", -100m, 500m);

            // Agir
            bool resultat = compte1.Superieur(compte2);

            // Assert
            Assert.IsTrue(resultat, "Le compte1 avec un solde de 0 devrait être supérieur au compte2 avec un solde négatif");
        }

    }
}
