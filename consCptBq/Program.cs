using System.Numerics;
using libCptBqTU;
Compte c1 = new Compte(12345, "toto", 1000, -500);
Compte c2 = new Compte(45657, "titi", 2000, -1000);
c1.Transferer(3300, c2);

if (c1.Superieur(c2))
{ Console.WriteLine("supérieur"); }
else
{
    Console.WriteLine("inférieur");
    Console.WriteLine(c2.ToString());
}

c1.Crediter(2000);
c1.Debiter(5300);


