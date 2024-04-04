using Newtonsoft.Json;
using RestSharp_Example.POCO;

namespace RestSharp_Example;

using RestSharp;

public class Tests
{
    private RestClient client = null;
    [OneTimeSetUp]
    public void Setup()
    {
         client = new RestClient(new RestClientOptions
        {
            BaseUrl = new System.Uri("https://reqres.in")
        });
    }

    [Test]
    public async Task  TestGetRequest()
    {
        var request = new RestRequest("/api/users?page=2", Method.Get);
        var response = await client.GetAsync<Root>(request);
        Console.WriteLine("Test Response : " + response.data[0].email);
        Assert.That(response.data[0].email, Is.EqualTo("michael.lawson@reqres.in"));
    }
 
    [Test]
    public async Task  TestPostRequest()
    {
        var request = new RestRequest("/api/users", Method.Post);
        request.AddJsonBody("{\n    \"name\": \"morpheus\",\n    \"job\": \"leader\"\n}");
        var response = await client.PostAsync(request);
        Console.WriteLine(response.Content);

    }

    [Test, Timeout(15000)]
    public async Task TestDelayedResponse()
    {
        var request = new RestRequest("/api/users?delay=10", Method.Get);
        var response = await client.GetAsync(request);
        Console.WriteLine(response.Content);
    }
}