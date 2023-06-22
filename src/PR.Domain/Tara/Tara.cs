using PR.Domain.Shared;

namespace PR.Domain.Tara;

public class Tara
{
    public int CodTara { get; private init; }

    public string Denumire { get; private set; }

    public Continent Continent { get; private set; }

    public Tara(string denumire, Continent continent)
    {
        Denumire = denumire;
        Continent = continent;
    }

    public void SetContinent(Continent continent)
    {
        Continent = continent;
    }

    public virtual ICollection<Oras.Oras> Orase { get; private set; } = new HashSet<Oras.Oras>();
}