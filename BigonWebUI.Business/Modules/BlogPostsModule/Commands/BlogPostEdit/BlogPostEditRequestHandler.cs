using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Extensions;
using BigonApp.Infrastructure.Repositories;
using BigonApp.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Commands.BlogPostEdit
{
    internal class BlogPostEditRequestHandler : IRequestHandler<BlogPostEditRequest, BlogPost>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IFileService _fileService;

        public BlogPostEditRequestHandler(IBlogPostRepository blogPostRepository,IFileService fileService)
        {
            _blogPostRepository = blogPostRepository;
            _fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostEditRequest request, CancellationToken cancellationToken)
        {
            var blogPost = _blogPostRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);

            blogPost.CategoryId = request.CategoryId;
            blogPost.Slug = request.Title.ToSlug();
            blogPost.Title = request.Title;
            blogPost.Body = request.Body;
            blogPost.FilePath = await _fileService.ChangeFileAsync(request.File, blogPost.FilePath);

            _blogPostRepository.Save();

            return blogPost;
        }
    }
}
