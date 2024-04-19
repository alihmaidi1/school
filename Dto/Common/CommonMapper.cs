using AutoMapper;
using Domain.Base.Entity;
using Shared.File;

namespace Dto.Common;

public class CommonMapper : Profile
{


    public CommonMapper()
    {

        CreateMap<ImageResponse, Image>().ReverseMap();
    }
    
    
}