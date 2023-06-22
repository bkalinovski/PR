namespace PR.Domain.Oras;

public class Oras
{
    public int CodOras { get; private init; }
    
    public string Denumire { get; private set; }

    public int NumarLocuitori { get; private set; }

    public int CodTara { get; private set; }

    public Oras(string denumire, int numarLocuitori, int codTara)
    {
        Denumire = denumire;
        NumarLocuitori = numarLocuitori;
        CodTara = codTara;
    }
    
    public Oras(string denumire, int numarLocuitori, Tara.Tara tara)
    {
        Denumire = denumire;
        NumarLocuitori = numarLocuitori;
        CodTara = tara.CodTara;
    }

    public virtual Tara.Tara Tara { get; set; }
}