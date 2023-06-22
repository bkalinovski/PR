using PR.Domain.Shared;

namespace PR.Application.Common.Models;

public class CountryDto
{
    public int Id { get; set; }

    public string Description { get; set; }

    public Continent Continent { get; set; }
}