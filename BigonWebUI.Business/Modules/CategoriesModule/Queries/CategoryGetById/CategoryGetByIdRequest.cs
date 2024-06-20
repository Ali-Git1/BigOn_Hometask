using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Queries.CategoryGetById
{
    public class CategoryGetByIdRequest:IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
