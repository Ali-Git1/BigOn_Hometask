using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Commands.CategoryAdd
{
    internal class CategoryAddRequestHandler : IRequestHandler<CategoryAddRequest, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAddRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId,
              };
            

             _categoryRepository.Add(category);

            return category;
        }
    }
}
