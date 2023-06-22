using MediatR;
using Microsoft.AspNetCore.Components;
using PR.Application.Common.Models;
using PR.Application.Country.Commands.RemoveCountry;
using PR.Application.Country.Queries.GetAllCountries;

namespace PR.Web.Pages;

public partial class Countries
{
    [Inject] private IMediator Mediator { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    private List<CountryDto>? CountryList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await RetrieveCountriesAsync();
    }

    private async Task RetrieveCountriesAsync()
    {
        CountryList = await Mediator.Send(new GetAllCountriesQuery());
    }

    private void OpenCountry(int countryId)
    {
        NavigationManager.NavigateTo($"/countries/{countryId}");
    }

    private async Task DeleteCountry(int id)
    {
        await Mediator.Send(new RemoveCountryCommand(id));
        await RetrieveCountriesAsync();
    }
}