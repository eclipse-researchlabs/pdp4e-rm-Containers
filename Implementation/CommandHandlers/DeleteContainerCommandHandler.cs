using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Containers.Implementation.Commands;
using Core.Database;
using MediatR;

namespace Core.Containers.Implementation.CommandHandlers
{
    public class DeleteContainerCommandHandler : IRequestHandler<DeleteContainerCommand, bool>
    {
        private IBeawreContext _beawreContext;

        public DeleteContainerCommandHandler(IBeawreContext beawreContext)
        {
            _beawreContext = beawreContext;
        }

        public Task<bool> Handle(DeleteContainerCommand request, CancellationToken cancellationToken)
        {
            var container = _beawreContext.Container.FirstOrDefault(x => x.RootId == request.Id);
                if(container == null) throw new Exception("ReturnCode.ContainerNotFound");
            container.IsDeleted = true;
            _beawreContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
