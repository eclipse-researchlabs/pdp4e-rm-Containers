// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

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
            if (container == null) throw new Exception("ReturnCode.ContainerNotFound");
            container.IsDeleted = true;
            _databaseContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}