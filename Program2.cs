using System;

// Interface représentant un employé
public interface IEmploye
{
    double CalculerSalaire();
}

// Classe de base pour les employés
public abstract class EmployeBase : IEmploye
{
    public string? Nom { get; set; }
    public double SalaireBase { get; set; }

    public abstract double CalculerSalaire();
}

// Classe représentant un employé à temps plein
public class EmployeTempsPlein : EmployeBase
{
    public override double CalculerSalaire()
    {
        // Calcul du salaire pour un employé à temps plein (+5 000 ariary de prime)
        return SalaireBase + 5000;
    }
}

// Classe représentant un employé à temps partiel
public class EmployeTempsPartiel : EmployeBase
{
    public override double CalculerSalaire()
    {
        // Calcul du salaire pour un employé à temps partiel (moitié)
        return SalaireBase * 0.5;
    }
}

// Classe responsable du calcul du salaire pour tous les employés
public class CalculateurSalaire
{
    private readonly IEmploye _employe;

    public CalculateurSalaire(IEmploye employe)
    {
        _employe = employe;
    }

    public double CalculerSalaireTotal()
    {
        // Utilisation du principe Dependency Inversion Principle pour injecter l'employé à calculer
        return _employe.CalculerSalaire();
    }
}

// Utilisation du calculateur de salaire
public class Programme
{
    static void AfficherSalaire(IEmploye employe)
    {
        double salaireEmploye = new CalculateurSalaire(employe).CalculerSalaireTotal();
        Console.WriteLine($"Le salaire de {(employe as EmployeTempsPlein)?.Nom} est de {salaireEmploye} ariary.");
    }

    static void Main()
    {
        IEmploye employe1 = new EmployeTempsPlein
        {
            Nom = "Rakoto",
            SalaireBase = 10000
        };

        IEmploye employe2 = new EmployeTempsPartiel
        {
            Nom = "Rabe",
            SalaireBase = 15000
        };

        AfficherSalaire(employe1);
        AfficherSalaire(employe2);
    }
}
