using BigonApp.Infrastructure.Repositories;
using MediatR;

namespace BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetAll
{
    public class BlogPostGetAllRequestHandler : IRequestHandler<BlogPostGetAllRequest, IEnumerable<CategoriesGetAllDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogPostGetAllRequestHandler(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoriesGetAllDto>> Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = (from bp in  _blogPostRepository.GetAll(m => m.DeletedBy == null)
                        join ct in  _categoryRepository.GetAll() on bp.CategoryId equals ct.Id
                        select new CategoriesGetAllDto
                        {
                            Id = bp.Id,
                            Title = bp.Title,
                            Body = bp.Body,
                            FilePath=bp.FilePath,
                            CategoryId = bp.CategoryId,
                            CategoryName = ct.Name,
                            
                        }).ToList();

            return data;
        }
    }
}