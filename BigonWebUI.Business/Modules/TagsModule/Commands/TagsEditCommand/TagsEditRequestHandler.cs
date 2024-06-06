using BigonApp.Business.Modules.ColorsModule.Commands.ColorsEditCommand;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Commands.TagsEditCommand
{
    internal class TagsEditRequestHandler : IRequestHandler<TagsEditRequest, Tag>
    {
        private readonly ITagRepository _tagRepository;

        public TagsEditRequestHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagsEditRequest request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Id = request.Id,
                Title = request.Title,
                
            };

            _tagRepository.Edit(tag);

            return tag;
        }
    }
}
