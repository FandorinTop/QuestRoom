using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess;
using QuestRoom.DataAccess.UnitOfWork;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Services;
using QuestRoom.ViewModel.Client.Request;
using QuestRoom.ViewModel.Common;

namespace QuestRoom
{
    public class ClientServiceTest
    {
        [Fact]
        public async Task CreateClientViewModelValidData()
        {
            // Arrange 
            var testHelper = new TestHelper();
            var DbContext = testHelper.GetInMemoryRepo();
            IClientService service = new ClientService(testHelper.GetUnitOfWork(DbContext));
            //Act

            var resId = await service.Create(new CreateClientViewModel()
            {
                Name = "Bor 5 Z",
                Email = "GGG@gmail.com",
                PhoneNumbe = "+380995533311212"
            });

            var res = await DbContext.Clients.FirstOrDefaultAsync(item => item.Id == resId);

            //Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task GetApiResponce()
        {
            // Arrange 
            var testHelper = new TestHelper();
            var DbContext = testHelper.GetInMemoryRepo();
            IClientService service = new ClientService(testHelper.GetUnitOfWork(DbContext));

            DbContext.Clients.AddRange(new List<Client>()
            {
                new Client(){Id = 1, Name = "1", Email = "6543", PhoneNumbe = "+380"},
                new Client(){Id = 2, Name = "2", Email = "7888", PhoneNumbe = "+380"},
                new Client(){Id = 3, Name = "3", Email = "556", PhoneNumbe = "+380"},
                new Client(){Id = 4, Name = "4", Email = "321", PhoneNumbe = "+380"},
                new Client(){Id = 5, Name = "5", Email = "6768", PhoneNumbe = "+380"},
                new Client(){Id = 6, Name = "6", Email = "5766", PhoneNumbe = "+380"},
                new Client(){Id = 7, Name = "7", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 8, Name = "8", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 9, Name = "8", Email = "1323", PhoneNumbe = "+380"},
                new Client(){Id = 10, Name = "8", Email = "555", PhoneNumbe = "+380"},
                new Client(){Id = 11, Name = "8", Email = "8888", PhoneNumbe = "+380"},
            });

            await DbContext.SaveChangesAsync();

            //Act
            var res = await service.GetAll(0, 5, new List<FilterRequest>(), new List<SortingRequest>());

            //Assert
            Assert.Equal(5, res.PageSize);
            Assert.Equal(0, res.PageIndex);
            Assert.Equal(11, res.TotalCount);
            Assert.Equal(3, res.TotalPages);
        }

        [Fact]
        public async Task FilterGetApiResponce()
        {
            // Arrange 
            var testHelper = new TestHelper();
            var DbContext = testHelper.GetInMemoryRepo();
            IClientService service = new ClientService(testHelper.GetUnitOfWork(DbContext));

            DbContext.Clients.AddRange(new List<Client>()
            {
                new Client(){Id = 1, Name = "1", Email = "6543", PhoneNumbe = "+380"},
                new Client(){Id = 2, Name = "2", Email = "7888", PhoneNumbe = "+380"},
                new Client(){Id = 3, Name = "3", Email = "556", PhoneNumbe = "+380"},
                new Client(){Id = 4, Name = "4", Email = "321", PhoneNumbe = "+380"},
                new Client(){Id = 5, Name = "5", Email = "6768", PhoneNumbe = "+380"},
                new Client(){Id = 6, Name = "6", Email = "5766", PhoneNumbe = "+380"},
                new Client(){Id = 7, Name = "7", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 8, Name = "8", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 9, Name = "8", Email = "1323", PhoneNumbe = "+380"},
                new Client(){Id = 10, Name = "8", Email = "555", PhoneNumbe = "+380"},
                new Client(){Id = 11, Name = "8", Email = "8888", PhoneNumbe = "+380"},
            });

            var filter = new FilterRequest()
            {
                FilterColumn = "Name",
                FilterQuery = "8",
                IsPartFilter = true
            };

            await DbContext.SaveChangesAsync();

            //Act
            var res = await service.GetAll(0, 5, new List<FilterRequest>() { filter }, new List<SortingRequest>());

            //Assert
            Assert.Equal(5, res.PageSize);
            Assert.Equal(0, res.PageIndex);
            Assert.Equal(4, res.TotalCount);
            Assert.Equal(1, res.TotalPages);
        }

        [Fact]
        public async Task SortGetApiResponce()
        {
            // Arrange 
            var testHelper = new TestHelper();
            var DbContext = testHelper.GetInMemoryRepo();
            IClientService service = new ClientService(testHelper.GetUnitOfWork(DbContext));

            DbContext.Clients.AddRange(new List<Client>()
            {
                new Client(){Id = 1, Name = "1", Email = "6543", PhoneNumbe = "+380"},
                new Client(){Id = 2, Name = "2", Email = "7888", PhoneNumbe = "+380"},
                new Client(){Id = 3, Name = "3", Email = "556", PhoneNumbe = "+380"},
                new Client(){Id = 4, Name = "4", Email = "321", PhoneNumbe = "+380"},
                new Client(){Id = 5, Name = "5", Email = "6768", PhoneNumbe = "+380"},
                new Client(){Id = 6, Name = "6", Email = "5766", PhoneNumbe = "+380"},
                new Client(){Id = 7, Name = "7", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 8, Name = "8", Email = "3232", PhoneNumbe = "+380"},
                new Client(){Id = 9, Name = "8", Email = "1323", PhoneNumbe = "+380"},
                new Client(){Id = 10, Name = "8", Email = "555", PhoneNumbe = "+380"},
                new Client(){Id = 11, Name = "8", Email = "8888", PhoneNumbe = "+380"},
            });

            var sort = new SortingRequest()
            {
                SortColumn = "Id",
                SortOrder = "DESC"
            };

            await DbContext.SaveChangesAsync();

            //Act
            var res = await service.GetAll(0, 10, null, new List<SortingRequest>() { sort });

            //Assert
            Assert.Equal(11, res.Data.First().Id);

        }
    }


    public class TestHelper
    {
        private readonly ApplicationDbContext _context;

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: "InMemoryDb");

            var dbContextOptions = builder.Options;
            _context = new ApplicationDbContext(dbContextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public ApplicationDbContext GetInMemoryRepo()
        {
            return _context;
        }

        public UnitOfWork GetUnitOfWork(ApplicationDbContext context)
        {
            return new UnitOfWork(context);
        }

    }

}