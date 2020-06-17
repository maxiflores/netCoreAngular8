using System;
using System.Collections.Generic;
using System.Text;

namespace Wheelzy.Models.Entities
{
    public class SubCategory
    {
        #region Properties
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }

        #endregion

        #region Relations

        public Category Category { get; set; }
        #endregion
    }
}
