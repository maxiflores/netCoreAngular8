using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Contract
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAll();
    }
}
