using QuestRoom.DataAccess.Repositories;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DataAccess.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        private IDiscountRepository discountRepository;
        private IPersonalRepository personalRepository;
        private IPersonalTypeRepository personalTypeRepository;
        private IQuestActorRepository questActorRepository;
        private IQuestActorSetRepository questActorSetRepository;
        private IQuestRepository questRepository;
        private IQuestSessionRepository questSessionRepository;
        private IQuestTypeRepository questTypeRepository;
        private IQuestTypeNameRepository typeRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDiscountRepository DiscountRepository
        {
            get
            {
                if(discountRepository is null)
                {
                    discountRepository = new DiscountRepository(_context);
                }

                return discountRepository;
            }
        }

        public IPersonalRepository PersonalRepository
        {
            get
            {
                if (personalRepository is null)
                {
                    personalRepository = new PersonalRepository(_context);
                }

                return personalRepository;
            }
        }

        public IPersonalTypeRepository PersonalTypeRepository
        {
            get
            {
                if (personalTypeRepository is null)
                {
                    personalTypeRepository = new PersonalTypeRepository(_context);
                }

                return personalTypeRepository;
            }
        }

        public IQuestActorRepository QuestActorRepository
        {
            get
            {
                if (questActorRepository is null)
                {
                    questActorRepository = new QuestActorRepository(_context);
                }

                return questActorRepository;
            }
        }

        public IQuestActorSetRepository QuestActorSetRepository
        {
            get
            {
                if (questActorSetRepository is null)
                {
                    questActorSetRepository = new QuestActorSetRepository(_context);
                }

                return questActorSetRepository;
            }
        }

        public IQuestRepository QuestRepository
        {
            get
            {
                if (questRepository is null)
                {
                    questRepository = new QuestRepository(_context);
                }

                return questRepository;
            }
        }

        public IQuestSessionRepository QuestSessionRepository
        {
            get
            {
                if (questSessionRepository is null)
                {
                    questSessionRepository = new QuestSessionRepository(_context);
                }

                return questSessionRepository;
            }
        }

        public IQuestTypeRepository QuestTypeRepository
        {
            get
            {
                if (questTypeRepository is null)
                {
                    questTypeRepository = new QuestTypeRepository(_context);
                }

                return questTypeRepository;
            }
        }

        public IQuestTypeNameRepository TypeRepository
        {
            get
            {
                if (typeRepository is null)
                {
                    typeRepository = new TypeRepository(_context);
                }

                return typeRepository;
            }
        }
    }
}
