using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.CategoriesModule.Queries.CategoryGetById
{
    internal class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetByIdRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = (
                from current in _categoryRepository.GetAll(x => x.Id == request.Id)
                join parent in _categoryRepository.GetAll() on current.ParentId equals parent.Id
                into lj
                from leftJoin in lj.DefaultIfEmpty()
                select new CategoryGetByIdDto
                {
                    Name = current.Name,
                    ParentId = current.ParentId,
                    ParentName = leftJoin.Name 
                });

            var data = query.FirstOrDefault();

            return data; 
            
        }
    }
}
