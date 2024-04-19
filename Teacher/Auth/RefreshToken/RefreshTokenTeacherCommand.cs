using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Auth.RefreshToken
{
    public class RefreshTokenTeacherCommand: ICommand
    {

        public string RefreshToken { get; init; }

    }
}