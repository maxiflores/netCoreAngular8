using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Dto
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
