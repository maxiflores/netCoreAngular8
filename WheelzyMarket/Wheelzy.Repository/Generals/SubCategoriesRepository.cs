using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;

namespace Wheelzy.Repository.Generals
{
    public class SubCategoriesRepository : ISubCategoriesRepository
    {
        private readonly EntityDbContext _dbContext;

        public SubCategoriesRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<SubCategory>> GetAll()
        {
            return _dbContext.Set<SubCategory>()
                .ToListAsync();
        }
    }
}
