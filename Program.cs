using System;

// Classe représentant un employé
public class Employe
{
    public string? Nom { get; set; }
    public double SalaireDeBase { get; set; }
    public bool EstTempsPlein { get; set; }

    public double CalculerSalaire()
    {
        double salaire = SalaireDeBase;

        // Calcul du salaire pour un employé à temps plein (+100 000 ariary de prime)
        if (EstTempsPlein)
        {
            salaire += 10000;
        }
        // Calcul du salaire pour un employé à temps partiel (moitié)
        else
        {
            salaire *= 0.5;
        }

        return salaire;
    }
}

// Utilisation de la classe Employe
public class Program
{
    static void Run()
    {
        Employe employe1 = new Employe
        {
            Nom = "Rakoto",
            SalaireDeBase = 1000000,
            EstTempsPlein = true
        };

        double salaireEmploye1 = employe1.CalculerSalaire();
        Console.WriteLine($"Le salaire de {employe1.Nom} est de {salaireEmploye1} ariary.");
    }
}
