using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class MenuRepository : GenericRepository<Menu>, IMenu
    {
        private AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public MenuRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    
    }
}