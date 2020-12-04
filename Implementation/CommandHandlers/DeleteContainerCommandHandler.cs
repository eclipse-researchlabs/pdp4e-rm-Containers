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
        private IDatabaseContext _databaseContext;

        public DeleteContainerCommandHandler(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<bool> Handle(DeleteContainerCommand request, CancellationToken cancellationToken)
        {
            var container = _databaseContext.Container.FirstOrDefault(x => x.RootId == request.Id);
                if(container == null) throw new Exception("ReturnCode.ContainerNotFound");
            container.IsDeleted = true;
            _databaseContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
