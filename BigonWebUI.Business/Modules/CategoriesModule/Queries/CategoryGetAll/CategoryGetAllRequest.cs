﻿using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Queries.CategoryGetAll
{
    public class CategoryGetAllRequest:IRequest<IEnumerable<Category>>
    {
    }
}
