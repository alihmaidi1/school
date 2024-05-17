using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace infrastructure.Convertor;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{

    public TimeOnlyConverter() : base(timeOnly => timeOnly.ToTimeSpan(), timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {


    }
}
