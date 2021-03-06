﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;

namespace Wheelzy.Services.Contracts
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetCategories();
    }
}
