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

namespace BigonApp.Business.Modules.BlogPostsModule.Commands.BlogPostAdd
{
    internal class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPost>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IFileService _fileService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository,IFileService fileService)
        {
            _blogPostRepository = blogPostRepository;
            _fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var blogPost = new BlogPost
            {
                Title = request.Title,
                Body = request.Body,
                FilePath = await _fileService.UploadAsync(request.File),
                Slug = request.Title.ToSlug(),
                CategoryId = request.CategoryId
            };

            _blogPostRepository.Add(blogPost);

            return blogPost;

        }
    }
}
