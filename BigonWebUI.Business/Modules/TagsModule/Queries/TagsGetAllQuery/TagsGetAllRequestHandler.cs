using BigonApp.Business.Modules.ColorsModule.Queries.ColorsGetAllQuery;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Queries.TagsGetAllQuery
{
    internal class TagsGetAllRequestHandler : IRequestHandler<TagsGetAllRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public TagsGetAllRequestHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IEnumerable<Tag>> Handle(TagsGetAllRequest request, CancellationToken cancellationToken)
        {   
            return await _tagRepository.GetAll(c => c.DeletedBy == null);   
        }
    }
}
