using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using MimeKit.Cryptography;
using Shared.Abstraction;

namespace Parent.Student.Query.FinalResult;

public class GetParentFinalResultQuery:IQuery
{


    public Guid StudentId{get;set;}



}
