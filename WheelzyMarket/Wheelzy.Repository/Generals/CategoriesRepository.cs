using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;

namespace Wheelzy.Repository.Generals
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly EntityDbContext _dbContext;

        public CategoriesRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Category>> GetAll()
        {
            return _dbContext.Set<Category>()
                .ToListAsync();
        }
    }
}
