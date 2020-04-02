using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Core.Containers.Implementation.Commands
{
    public class DeleteContainerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
