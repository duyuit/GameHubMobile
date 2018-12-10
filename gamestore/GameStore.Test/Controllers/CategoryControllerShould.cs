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
    [Collection("CategoryE2E")]
    public class CategoryControllerShould : BaseController
    {
        private readonly ITestOutputHelper _output;

        public CategoryControllerShould(ITestOutputHelper output) : base(49913)
        {
            _output = output;
        }

        [Fact]
        [Trait("Category", "CategoryE2E")]
        public void TestGetAllCategoriesController()
        {
            Init(49913);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/categories").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<CategoryDTOs> categoriesResponse = JsonConvert.DeserializeObject<Responses<CategoryDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(5, categoriesResponse.Payload.Count);
                Assert.True(categoriesResponse.IsSuccess);
            }
        }

        


    }
}
