using BigonApp.Business.Modules.ColorsModule.Commands.ColorsRemoveCommand;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Commands.TagsRemoveCommand
{
    internal class TagsRemoveRequestHandler: IRequestHandler<TagsRemoveRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public TagsRemoveRequestHandler(ITagRepository tagRepository)
        {
           _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> Handle(TagsRemoveRequest request, CancellationToken cancellationToken)
        {
            var color = _tagRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);

            _tagRepository.Remove(color);

            return await _tagRepository.GetAll(x => x.DeletedBy == null);
        }
    }
}
