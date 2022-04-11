﻿using Tangy_Models;

namespace TangyWeb_Client.Service.IService
{
    public interface IAuthenticationService
    {
        Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequestDTO);
        Task<SignInResponseDTO> Login(SignUpRequestDTO signInRequestDTO);
        Task Logout();
    }
}
