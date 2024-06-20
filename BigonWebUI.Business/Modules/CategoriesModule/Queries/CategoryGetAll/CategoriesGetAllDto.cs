﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Queries.CategoryGetAll
{
    public class CategoriesGetAllDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string FilePath { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
      
    }
}