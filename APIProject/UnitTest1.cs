using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace APIProject
{
    [TestFixture]
    public class UnitTest1
    {
        RestClient client;
        RestRequest request;
        string url = "https://reqres.in/";
        string url2 = "https://reqres.in/api/users?page=2";

        public UnitTest1()
        {
            this.client = new RestClient();
            this.request = new RestRequest();
        }

        [Test]
        public void GetRequest()
        {
            client = new RestClient(url);
            request = new RestRequest("api/users?page=2", Method.GET);
            request.AddParameter("Accept", "application/json");

            var response = client.Execute(request);

            if (response.IsSuccessful == true)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine((int)response.StatusCode);

                Assert.True(response.StatusCode.ToString() == "OK");

                Assert.AreEqual("OK", response.StatusCode.ToString());

                Assert.AreEqual(200, (int)response.StatusCode, 
                    "Statuscode not correct");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }
        }

        [Test]
        public void GetRequest2()
        {
            client = new RestClient(url);
            request = new RestRequest("api/users?page=2", Method.GET);
            request.AddParameter("Accept", "application/json");

            var response = client.Execute<Users>(request);


            if (response.IsSuccessful == true)
            {
                Assert.True(response.StatusCode.ToString() == "OK");

                Assert.AreEqual("OK", response.StatusCode.ToString());

                Assert.AreEqual(200, (int)response.StatusCode,
                    "Statuscode not correct");

                Assert.True(response.Content.Contains("Michael"));
                Assert.AreEqual("Michael", response.Data.data[0].first_name);
                Assert.AreEqual("Lawson", response.Data.data[0].last_name);

                Assert.AreEqual("Tobias", response.Data.data[2].first_name);
                Assert.AreEqual("Funke", response.Data.data[2].last_name);
            }
        }

        [Test]
        public void GetRequest3()
        {
            var client = new RestClient(url2);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "__cfduid=d41c1f346f4b41d3dc4e9522bc0c4f87d1614528400");
            //request.AddParameter("application/json", "{\r\n    \"name\": \"Sam\",\r\n    \"job\": \"Smith\"\r\n}", 
             //   ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Xml;
            var payload = request.AddJsonBody(new Datum()
            {
                id = 40,
                first_name = "John",
                last_name = "Knight",
                email = "JJ@yahoo.com",
            });

            var response = client.Execute<Datum>(payload);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);
            Assert.AreEqual("Knight", response.Data.last_name);
        }
    }
}
