using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Contract
{
    public interface ISubCategoriesRepository
    {
        Task<List<SubCategory>> GetAll();
    }
}
