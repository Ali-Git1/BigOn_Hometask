using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Commands.TagsAddCommand
{
    internal class ColorsAddRequestHandler : IRequestHandler<TagsAddRequest, Tag>
    {
        private readonly ITagRepository _tagRepository;

        public ColorsAddRequestHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagsAddRequest request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Title = request.Title,
                
            };

            _tagRepository.Add(tag);

            return tag;
        }
    }
}
