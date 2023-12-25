using Domain.Base.Entity;
using Domain.Entities.Admin;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dto;

public class TokenDto
{
    public string Token { get; set; }

    public string ?RefreshToken { get; set; }

    public int ExpiredAt { get; set; }
    public static TokenDto ToTokenDto(string Token,int ExpiredAt,string RefreshToken=null)
    {

        return new TokenDto
        {
            Token=Token,
            ExpiredAt=ExpiredAt,
            RefreshToken=RefreshToken

        };

    }

    
    

}