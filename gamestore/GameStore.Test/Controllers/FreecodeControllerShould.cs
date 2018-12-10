using GameStore.DTOs;
using GameStore.Extention;
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
    [Collection("FreecodeE2E")]
    public  class FreecodeControllerShould : BaseController
    {
        private readonly ITestOutputHelper _output;
      
        public FreecodeControllerShould(ITestOutputHelper output) : base(49914)
        {
            _output = output;
        }
        [Fact]
        [Trait("Freecodes", "FreecodeE2E")]
        public void TestGetAllFreeCodesController()
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/freecodes").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<FreeCodeDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<FreeCodeDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                //Assert.Equal(8, freeCodeResponse.Payload.Count);
                Assert.True(freeCodeResponse.IsSuccess);
            }

        }
        [Theory]
        [InlineData("39ACCDD9-161A-4FE0-8A10-310F8C98AD93")]
        [InlineData("8B4DDF45-3956-486B-A2F6-3FEC1B3D3048")]
        [InlineData("F5153E60-15B8-468E-97AE-A01E5188F053")]
        [InlineData("42DFEC91-42C7-49F5-B449-B4E22E895088")]
        [InlineData("EC1FB6A2-755E-4561-903C-D504845D9475")]
        [Trait("Freecodes", "FreecodeE2E")]
        public void TestGetFreeCodeByIdGameController(string gameId)
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync($"api/freecodes/{gameId}").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<FreeCodeDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<FreeCodeDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(freeCodeResponse.IsSuccess);
            }
        }


       

        [Theory]
        [InlineData("39ACCDD9-161A-4FE0-8A10-310F8C98AD93")]
        [InlineData("8B4DDF45-3956-486B-A2F6-3FEC1B3D3048")]
        [InlineData("EC1FB6A2-755E-4561-903C-D504845D9475")]
        [InlineData("42DFEC91-42C7-49F5-B449-B4E22E895088")]

        [Trait("Freecodes", "FreecodeE2E")]
        public void TestPostNewFreeCodeController(string id)
        {
            Init(49914);

            SavedFreeCodeDTOs savedFreeCodeDTOsDemo = new SavedFreeCodeDTOs()
            {
                Code = (Guid.NewGuid()).ToString(),
                GameId = id.ToGuid()
            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.PostAsJsonAsync($"api/freecodes", savedFreeCodeDTOsDemo).GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Response<string> freeCodeResponse = JsonConvert.DeserializeObject<Response<string>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(freeCodeResponse.IsSuccess);
            }
        }

      
    }
}
