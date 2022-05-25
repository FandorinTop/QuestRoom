using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Personal.Responce;
using QuestRoom.ViewModel.Quest.Request;
using QuestRoom.ViewModel.QuestActor.Request;
using QuestRoom.ViewModel.QuestActor.Responce;
using QuestRoom.ViewModel.Type.Responce;
using System.Net.Http.Json;

namespace QuestRoom.Web.Client.Pages.Quest
{
    public partial class QuestCU
    {
        private MatAutocompleteList<GetPersonalViewModel> autocompleteList = null;
        private MatAutocompleteList<GetQuestTypeNameViewModel> TypeAutocompleteList = null;
        private string AddPersonalLabel
        { 
            get
            {
                return Personals.Any() ? "Add personal" : "No more personal left";
            } 
        }

        private string Title
        {
            get
            {
                return Id == null ? "Create Quest" : $"Edit Quest with id: '{Id}'";
            }
        }

        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        [Parameter]
        public int? Id { get; set; } = default;

        private bool _isDelete;

        private List<GetQuestTypeNameViewModel> TypeSelector { get; set; } = new List<GetQuestTypeNameViewModel>();

        private GetQuestTypeNameViewModel SelectedType { get; set; }

        private UpdateQuestViewModel Model { get; set; } = new UpdateQuestViewModel();

        private List<GetPersonalViewModel> Personals { get; set; } = new List<GetPersonalViewModel>();

        private List<GetQuestActorViewModel> Actors { get; set; } = new List<GetQuestActorViewModel>();

        private GetQuestActorViewModel SelectedActor { get; set; }

        public async Task Success()
        {
            Console.WriteLine("Success");

            if (Id == null)
            {
                await CreateAsync();
            }
            else
            {
                await UpdateAsync();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await GetAsync();
            await GetSelectorType();
            await UpdateTable();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (Model.QuestTypeId.HasValue)
            {
                TypeAutocompleteList.Value = TypeSelector.FirstOrDefault(item => item.Id == Model.QuestTypeId.Value) ?? SelectedType;
            }
        }

        private async Task GetAsync()
        {
            if (Id != default)
            {
                var responce = await HttpClient.GetAsync($"api/Quest/Get?id={Id}");
                var result = await responce.Content.ReadFromJsonAsync<UpdateQuestViewModel>();

                Console.WriteLine("getResult: " + result);

                Model = result ?? Model;
            }
        }

        private async Task CreateAsync()
        {
            var result = await HttpClient.PostAsJsonAsync(@"api/Quest/Create", Model);

            if (result.IsSuccessStatusCode)
            {
                var id = await result.Content.ReadAsStringAsync();
                Id = Convert.ToInt32(id);
                await JS.InvokeAsync<object>("alert", $"Successful created! with id: '{id}'");
                navManager.NavigateTo($"/manage/Quest/{Id}");
            }
            else
            {
                await JS.InvokeAsync<object>("alert", $"CreationError {await result.Content.ReadAsStringAsync()}");
            }
        }

        private async Task UpdateAsync()
        {
            var result = await HttpClient.PutAsJsonAsync(@"api/Quest/Update", Model);

            if (result.IsSuccessStatusCode)
            {
                await JS.InvokeAsync<object>("alert", $"Successful updated! for id: '{Model.Id}'");
            }
            else
            {
                await JS.InvokeAsync<object>("alert", $"UpdateError {await result.Content.ReadAsStringAsync()}");
            }
        }

        private async Task GetSelectorType()
        {
            var responce = await HttpClient.PostAsJsonAsync($"api/QuestTypeName/GetApiResponce", new GetApiBodyRequest()
            {
                PageIndex = 0,
                PageSize = 1000
            });

            var result = await responce.Content.ReadFromJsonAsync<ApiResultViewModel<GetQuestTypeNameViewModel>>();

            try
            {
                TypeSelector = result?.Data.ToList() ?? TypeSelector;
            }
            catch (Exception ex)
            {

            }
        }

        private async Task AddActor(GetPersonalViewModel personal)
        {
            if(personal is null)
            {
                return;
            }

            var viewModel = new CreateQuestActorViewModel()
            {
                PersonalId = personal.Id,
                QuestId = Id.Value
            };

            var responce = await HttpClient.PostAsJsonAsync(@"api/questActor/Create", viewModel);

            if (responce.IsSuccessStatusCode)
            {
                Personals.Remove(personal);
                var actor = new GetQuestActorViewModel()
                {
                    Id = Convert.ToInt32(await responce.Content.ReadAsStringAsync()),
                    PersonalId = viewModel.PersonalId,
                    QuestId = Id.Value,
                    PersonalName = personal.Name,
                    CreatedAt = DateTime.Now
                };
                Actors.Add(actor);

                autocompleteList.ClearText(EventArgs.Empty);
            }

            StateHasChanged();
        }

        private async Task DeleteActor()
        {
            _isDelete = true;

            if (SelectedActor != null && SelectedActor.Id > 0)
            {
                var actor = Actors.FirstOrDefault(item => item.Id == SelectedActor.Id);

                if (actor is null)
                {
                    return;
                }
                else
                {
                    await DeleteActor(actor);
                    _isDelete = false;
                    StateHasChanged();
                }
            }
        }

        private async Task DeleteActor(GetQuestActorViewModel actor)
        {
            var responce = await HttpClient.DeleteAsync(@$"api/questActor/delete?id={actor.Id}");

            if (responce.IsSuccessStatusCode)
            {
                Actors.Remove(actor);
                var personal = new GetPersonalViewModel()
                {
                    Id = actor.PersonalId,
                    Name = actor.PersonalName,
                };
                Personals.Add(personal);
            }

            StateHasChanged();
        }

        private async Task UpdateTable()
        {
            if (Id.HasValue)
            {
                await GetActorAsync();
            }

            await GetPersonalAsync();

            foreach (var actor in Actors)
            {
                Personals.RemoveAll(item => item.Id == actor.PersonalId);
            }
        }

        private async Task GetActorAsync()
        {
            var responce = await HttpClient.PostAsJsonAsync($"api/QuestActor/GetApiResponce", new GetApiBodyRequest()
            {
                PageIndex = 0,
                PageSize = 100000,
                FilterRequests = new List<FilterRequest>()
                {
                    new FilterRequest(){
                        FilterColumn = "QuestId",
                        FilterQuery = Id.Value.ToString(),
                        IsPartFilter = false,
                    }
                }
            });

            var result = await responce.Content.ReadFromJsonAsync<ApiResultViewModel<GetQuestActorViewModel>>();

            Actors = result?.Data.ToList() ?? Actors;
        }

        private async Task GetPersonalAsync()
        {
            var responce = await HttpClient.PostAsJsonAsync($"api/Personal/GetApiResponce", new GetApiBodyRequest()
            {
                PageIndex = 0,
                PageSize = 100000,
            });

            var result = await responce.Content.ReadFromJsonAsync<ApiResultViewModel<GetPersonalViewModel>>();

            Personals = result?.Data.ToList() ?? Personals;
        }

        private void OnNullType(object obj)
        {
            var res = obj as GetQuestTypeNameViewModel;

            if (res is not null)
            {
                SelectedType = res;
                Model.QuestTypeId = res.Id;
            }
        }

        public async Task SelectionChangedEvent(object obj)
        {
            var actor = obj as GetQuestActorViewModel;

            if (actor is null)
            {
                SelectedActor = new GetQuestActorViewModel();
            }
            else
            {
                SelectedActor = actor;

                if (_isDelete)
                {
                    await DeleteActor(SelectedActor);

                    StateHasChanged();
                }
            }
        }
    }
}
