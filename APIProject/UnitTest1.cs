using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace APIProject
{
    [TestFixture]
    public class UnitTest1
    {
        RestClient client;
        RestRequest request;
        string url = "https://reqres.in/";
        string url2 = "https://reqres.in/api/users?page=2";
        string AssessmentUrl = "https://jsonplaceholder.typicode.com/";

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
            //request.RequestFormat = DataFormat.Xml;
            //var payload = request.AddJsonBody(new Datum()
            //{
            //    id = 40,
            //    first_name = "John",
            //    last_name = "Knight",
            //    email = "JJ@yahoo.com",
            //});

            var response = client.Execute<Datum>(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);
            Assert.AreEqual("Knight", response.Data.last_name);
        }


        [Test]
        public void GetRequestAssessment()
        {
            client = new RestClient(AssessmentUrl);
            request = new RestRequest("users", Method.GET);
            request.AddParameter("Accept", "application/json");

            var response = client.Execute<List<User>>(request);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);
            Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.IsTrue(response.Content.Contains("Bret"));

            if (response.IsSuccessful == true)
            {
                Assert.AreEqual(200, (int)response.StatusCode);
                Assert.AreEqual("Bret", response.Data[0].username);
                Assert.AreEqual("Leanne Graha", response.Data[0].name);
            }
        }

        [Test]
        public void PostRequest()
        {
            client = new RestClient(AssessmentUrl);
            request = new RestRequest("users", Method.POST);
            request.AddParameter("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            var payload = request.AddJsonBody(new User() 
            { 
                 id = 12,
                 name = "Odun Martin",
                 username = "OdunM",
                 email = "abc@abc.com",
                 address = new Address()
                 {
                      street = "6 not str",
                      suite = "Apt. 556",
                      city = "manchester",
                      zipcode = "M28 5GD",
                      geo = new Geo()
                      {
                           lat = "-3456",
                           lng = "6787"
                      }
                 }
            });

            var response = client.Execute<List<User>>(payload);
            if (response.IsSuccessful == true)
            {
                Assert.AreEqual(201, (int)response.StatusCode);
            }

        }

        [Test]
        public void PutRequest()
        {
            client = new RestClient(AssessmentUrl);
            request = new RestRequest("users", Method.PUT);
            request.AddParameter("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            var payload = request.AddJsonBody(new User()
            {
                id = 11,
                name = "Odun Don",
                username = "OdunM",
                email = "dbc@dbc.com",
                address = new Address()
                {
                    street = "6 not str",
                    suite = "Apt. 556",
                    city = "manchester",
                    zipcode = "M28 5GD",
                    geo = new Geo()
                    {
                        lat = "-3456",
                        lng = "6787"
                    }
                }
            });

            var response = client.Execute<List<User>>(payload);
            if (response.IsSuccessful == true)
            {
                Assert.AreEqual(200, (int)response.StatusCode);
            }
        }
    }
}
