using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Manager.Admin.Command.ChangeStatus;

    public class ChangeAdminStatusCommand: ICommand
    {

        public Guid Id {get;set;}

        public bool Status{get;set;}

    }
