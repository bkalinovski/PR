using MediatR;
using Microsoft.AspNetCore.Components;
using PR.Application.City.Queries.GetAllCities;
using PR.Application.Common.Models;
using PR.Application.Country.Commands.RemoveCountry;
using PR.Application.Country.Queries.GetAllCountries;

namespace PR.Web.Pages;

public partial class Cities
{
    [Inject] private IMediator Mediator { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    private List<CityDto>? CityList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await RetrieveCitiesAsync();
    }

    private async Task RetrieveCitiesAsync()
    {
        CityList = await Mediator.Send(new GetAllCitiesQuery());
    }

    private void OpenCity(int cityId)
    {
        NavigationManager.NavigateTo($"/cities/{cityId}");
    }

    private async Task DeleteCity(int id)
    {
        await Mediator.Send(new RemoveCountryCommand(id));
        await RetrieveCitiesAsync();
    }
}