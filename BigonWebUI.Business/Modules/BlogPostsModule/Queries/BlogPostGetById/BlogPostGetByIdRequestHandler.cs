using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetById
{
    internal class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPostGetByIdDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository,ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<BlogPostGetByIdDto> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = (from bp in await _blogPostRepository.GetAll(x => x.DeletedBy == null)
                         join ct in await _categoryRepository.GetAll(x => x.DeletedBy == null)
                         on bp.CategoryId equals ct.Id
                         where bp.Id == request.Id
                         select new BlogPostGetByIdDto
                         {
                             Id=bp.Id,
                             Body = bp.Body,
                             CreatedBy = bp.CreatedBy,
                             CreatedAt = bp.CreatedAt,
                             ModifiedAt = bp.ModifiedAt,
                             PublishedAt = bp.PublishedAt,
                             CategoryName=ct.Name,
                             CategoryId = ct.Id,
                             FilePath = bp.FilePath,
                             Slug = bp.Slug,
                             ModifiedBy = bp.ModifiedBy,
                             PublishedBy = bp.PublishedBy,
                             Title = bp.Title

                         });

            var data = query.FirstOrDefault();

            return data;
        }
    }
}
