using BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetAll;
using BigonApp.Infrastructure.Repositories;
using BigonApp.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Commands.BlogPostRemove
{
    internal class CategoriesRemoveRequestHandler : IRequestHandler<BlogPostRemoveRequest, IEnumerable<CategoriesGetAllDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IFileService _fileService;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesRemoveRequestHandler(IBlogPostRepository blogPostRepository,IFileService fileService,ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _fileService = fileService;
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoriesGetAllDto>> Handle(BlogPostRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = _blogPostRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);

            entity.FilePath = await _fileService.ChangeFileAsync(null, entity.FilePath/*, true*/);



            _blogPostRepository.Remove(entity);
            

            var data = (from bp in /*await*/ _blogPostRepository.GetAll(m => m.DeletedBy == null)
                        join ct in /*await*/ _categoryRepository.GetAll() on bp.CategoryId equals ct.Id
                        select new CategoriesGetAllDto
                        {
                            Id = bp.Id,
                            Title = bp.Title,
                            Body = bp.Body,
                            FilePath = bp.FilePath,
                            CategoryId = bp.CategoryId,
                            CategoryName = ct.Name,

                        }).ToList();

            return data;
        }
    }
}
