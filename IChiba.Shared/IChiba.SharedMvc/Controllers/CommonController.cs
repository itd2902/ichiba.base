using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IChiba.Web.Framework.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace IChiba.Web.Framework.Controllers
{
    [Route("common")]
    [ApiController]
    public class CommonController : IChibaController
    {
        #region Fields

        private readonly IHttpClientFactory _clientFactory;

        #endregion

        #region Ctor

        public CommonController(
            IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        #endregion

        #region SSO

        [Route("refresh-token")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenModel model)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = "",

                ClientId = "client",
                ClientSecret = "secret",

                RefreshToken = model.RefreshToken
            });

            return Ok();
        }

        #endregion

        #region Helpers



        #endregion

        #region Utilities



        #endregion
    }
}
