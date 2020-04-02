using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MediatR;

namespace Core.Containers.Implementation.Commands
{
    public class CreateContainerCommand : Core.Database.Tables.Container, IRequest<Core.Database.Tables.Container>
    {
        public object PayloadObject { get; set; }
        public Guid? ParentRootId { get; set; }

        public string[] NotifyGroups { get; set; }
    }
}
