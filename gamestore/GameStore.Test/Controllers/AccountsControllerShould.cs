using GameStore.Common;
using GameStore.DTOs;
using GameStore.Model;
using GameStore.Test.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameStore.Test.Controllers
{
    [Collection("AccountE2E")]
    public class AccountsControllerShould : BaseController
    {
        private readonly ITestOutputHelper _output;

        public AccountsControllerShould(ITestOutputHelper output) : base(49912)
        {
            _output = output;
        }

        [Fact]
        [Trait("Account", "AccountE2E")]
        public void TestGetAllUsersController()
        {
            Init(49912);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/accounts").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<UserDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<UserDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(5, freeCodeResponse.Payload.Count);
                Assert.True(freeCodeResponse.IsSuccess);
            }

        }


        [Theory]
        [InlineData("B39ACCDD9-161A-4FE0-8A10-310F8C98AD93")]
        [InlineData("8B4DDF45-3956-486B-A2F6-3FEC1B3D3048")]
        [InlineData("F5153E60-15B8-468E-97AE-A01E5188F053")]
        [InlineData("42DFEC91-42C7-49F5-B449-B4E22E895088")]
        [InlineData("EC1FB6A2-755E-4561-903C-D504845D9475")]
        [Trait("Account", "AccountE2E")]
        public void TestGetUserByIdController(string Id)
        {
            Init(49912);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync($"api/accounts/{Id}").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Response<UserDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Response<UserDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(freeCodeResponse.IsSuccess);
            }

        }
    }
}
