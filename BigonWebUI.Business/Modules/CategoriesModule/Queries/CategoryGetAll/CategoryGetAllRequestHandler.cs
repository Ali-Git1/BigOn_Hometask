using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Queries.CategoryGetAll
{
    internal class CategoryGetAllRequestHandler : IRequestHandler<CategoryGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetAllRequestHandler(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
             return _categoryRepository.GetAll(x => x.DeletedBy == null).ToList();
        }
    }
}
