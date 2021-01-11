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