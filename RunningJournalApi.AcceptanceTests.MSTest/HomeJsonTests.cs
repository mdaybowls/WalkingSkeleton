using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RunningJournalApi.AcceptanceTests.MSTest
{
    [TestClass]
    public class HomeJsonTests
    {
        [TestMethod]
        public void GetResponseReturnCorrectStatusCode()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;
                Assert.IsTrue(response.IsSuccessStatusCode, "Actual status code: " + response.StatusCode);
            }
        }

        [TestMethod]
        public void PostResponseReturnCorrectStatusCode()
        {
            using (var client = HttpClientFactory.Create())
            {
                var json = new
                {
                    time = DateTimeOffset.Now,
                    distance = 8500,
                    duration = TimeSpan.FromMinutes(44)
                };

                var response = client.PostAsJsonAsync("", json).Result;
                Assert.IsTrue(response.IsSuccessStatusCode, "Actual status code: " + response.StatusCode);
            }
        }

        [TestMethod]
        public void GetAfterPostReturnsResponseWithPostedEntry()
        {
            using (var client = HttpClientFactory.Create())
            {
                var json = new
                {
                    time = DateTimeOffset.Now,
                    distance = 8100,
                    duration = TimeSpan.FromMinutes(41)
                };
                var expected = JsonConvert.SerializeObject(json);
                client.PostAsJsonAsync("", json).Wait();
                client.PostAsJsonAsync("", json).Wait();
                var response = client.GetAsync("").Result;
                var actualJson = response.Content.ReadAsStringAsync().Result;
                var actual = JsonConvert.DeserializeObject <JournalModel>(actualJson);
                //Assert.IsTrue(actual.Entries.Contains(json));
            }
        }

    }
}
