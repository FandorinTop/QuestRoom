﻿using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class PersonalTypeRepository : GenericRepository<PersonalType>, IPersonalTypeRepository
    {
        public PersonalTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
