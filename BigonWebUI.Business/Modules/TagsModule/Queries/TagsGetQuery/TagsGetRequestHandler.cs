using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Queries.TagsGetQuery
{
    internal class TagsGetRequestHandler : IRequestHandler<TagsGetRequest, Tag>
    {
        private readonly ITagRepository _tagRepository;

        public TagsGetRequestHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagsGetRequest request, CancellationToken cancellationToken)
        {
            return _tagRepository.Get(e => e.Id == request.Id & e.DeletedBy == null);
        }
    }
}
