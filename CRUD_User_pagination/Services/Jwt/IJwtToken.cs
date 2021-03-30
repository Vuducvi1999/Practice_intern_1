using Domain.Dtos.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Jwt
{
    public interface IJwtToken
    {
        public string Generate(UserLogin user);
    }
}
