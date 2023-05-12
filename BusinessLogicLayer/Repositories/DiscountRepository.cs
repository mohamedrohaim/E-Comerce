using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class DiscountRepository: GenericRepository<Discount>, IDiscountRepository
    {
        private readonly AppDbContext _appDbContext;

        public DiscountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    
    }
}
