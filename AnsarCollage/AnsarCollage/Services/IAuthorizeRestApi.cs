using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AnsarCollage.Models;
using Refit;

namespace AnsarCollage.Services
{
    public class VerifyCodeRequest
    {
        public string phone { get; set; }
        public string code { get; set; }
        public string serverCode { get; set; }
        public string name { get; set; }
    }
    public interface IAuthorizeRestApi
    {
        [Post("/send-verification-code/")]
        Task<ApiResult<CodeValidationResponse>> SendVeryCode([Body] VerifyCodeRequest content);

        [Post("/sign-up/")]
        Task<ApiResult<TokenResponse>> SignUp([Body] VerifyCodeRequest content);

        [Post("/login/")]
        Task<ApiResult<TokenResponse>> Login([Body] VerifyCodeRequest content);

    }
}
