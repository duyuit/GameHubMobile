using GameStore.DTOs;
using GameStore.Test.ResponseModel;
using Newtonsoft.Json;
using GameStore.Extention;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Collections.ObjectModel;

namespace GameStore.Test.Controllers
{
    [Collection("GameE2E")]
    public class GameControllerShould : BaseController
    {
        private readonly ITestOutputHelper _output;

        public GameControllerShould(ITestOutputHelper output) : base(49914)
        {
            _output = output;
        }
        [Fact]
        [Trait("Games", "GameE2E")]
        public void TestGetAllGamesController()
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/games").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<GameDTOs> gamesResponse = JsonConvert.DeserializeObject<Responses<GameDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.Equal(5, gamesResponse.Payload.Count);
                Assert.True(gamesResponse.IsSuccess);
            }

        }

        [Theory]
        [InlineData("39ACCDD9-161A-4FE0-8A10-310F8C98AD93")]
        [InlineData("8B4DDF45-3956-486B-A2F6-3FEC1B3D3048")]
        [InlineData("F5153E60-15B8-468E-97AE-A01E5188F053")]
        [InlineData("42DFEC91-42C7-49F5-B449-B4E22E895088")]
        [InlineData("EC1FB6A2-755E-4561-903C-D504845D9475")]
        [Trait("Games", "GameE2E")]
        public void TestGetGameByIdController(string Id)
        {
            Init(49914);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync($"api/games/{Id}").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Response<GameDTOs> gamesResponse = JsonConvert.DeserializeObject<Response<GameDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(gamesResponse.IsSuccess);
            }

        }


        [Theory]
        [InlineData("Gunny", "0E276582-8CA0-4DE3-A465-ED721530AE2C", "EC1FB6A2-755E-4561-903C-D504845D9475",
            "42DFEC91-42C7-49F5-B449-B4E22E895088", "42DFEC91-42C7-49F5-B449-B4E22E895088",
            "EC1FB6A2-755E-4561-903C-D504845D9475", 3,"logo here",
            "video here","content here ", "EC1FB6A2-755E-4561-903C-D504845D9475",
            "42DFEC91-42C7-49F5-B449-B4E22E895088", 1000000
            )]


        [Trait("Freecodes", "FreecodeE2E")]
        public void TestPostNewGameController(string name, string publisherId,
                                              string members1, string members2,
                                              string favoriteMembers1, string favoriteMembers2,
                                              float rating,string logo,
                                              string videoUrl,string content,
                                              string categories1,string categories2,
                                              float price)
        {
            Init(49914);

            SavedGameDTOs savedGameDTOs = new SavedGameDTOs()
            {
                Name = name,
                PublisherId = publisherId.ToGuid(),
                Members = new Collection<Guid>{ members1.ToGuid(), members2.ToGuid()},
                FavoriteMembers= new Collection<Guid> { favoriteMembers1.ToGuid(), favoriteMembers2.ToGuid() },
                Rating=rating,
                Logo=logo,
                VideoUrl=videoUrl,
                Content=content,
                Categories=new Collection<Guid> { categories1.ToGuid(),categories2.ToGuid()},
                Price=price,
                PurchaseDate=DateTime.Now
            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.PostAsJsonAsync($"api/games", savedGameDTOs).GetAwaiter().GetResult();
                var contentResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Response<GameDTOs> gameResponse = JsonConvert.DeserializeObject<Response<GameDTOs>>(contentResult);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(gameResponse.IsSuccess);
            }
        }
    }
}
