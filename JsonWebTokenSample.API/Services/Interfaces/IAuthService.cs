using JsonWebTokenSample.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebTokenSample.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<MyAccessTokenDto> SignInAsync(LoginDto loginDto);
    }
}
