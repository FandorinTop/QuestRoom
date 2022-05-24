﻿using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Personal.Request;
using QuestRoom.ViewModel.Personal.Responce;

namespace QuestRoom.Interfaces.Services
{
    public interface IPersonalService
    {
        public Task<int> Create(CreatePersonalViewModel viewModel);

        public Task Update(UpdatePersonalViewModel viewModel);

        public Task<GetPersonalViewModel> Get(int id);

        public Task<ApiResultViewModel<GetPersonalViewModel>> GetAll(int pageIndex, int pageSize, IEnumerable<FilterRequest> filters, IEnumerable<SortingRequest> sorting);
    }
}
