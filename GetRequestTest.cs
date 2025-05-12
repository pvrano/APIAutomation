using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using APITestingRestWithRestSharp.Models;

namespace APITestingRestWithRestSharp
{
    [TestFixture]
    public class GetRequestTest
    {
        private IRestClient RestClient;

        [OneTimeSetUp]
        public void Setup()
        {
            RestClient = new RestClient("https://jsonplaceholder.typicode.com/");
        }

        [Test, Order(2)]
        public async Task GetPostById_ReturnCorrectPost()
        {
            var request = new RestRequest("/posts/2", Method.Get);
            var response = await RestClient.ExecuteAsync(request);

            Assert.That(response.IsSuccessful, Is.True, "API call failed");

            var post = JsonSerializer.Deserialize<Post>(response.Content);
            Console.WriteLine(response.Content);


            Assert.That(post, Is.Not.Null);
            Assert.That(post.Id, Is.EqualTo(2));
            Assert.That(post.Title, Is.Not.Empty);

        }

        [Test, Order(1)]
        public async Task GetAllPostAndCountTotalPosts()
        {
            var request = new RestRequest("/posts", Method.Get);
            var response = await RestClient.ExecuteAsync(request);

            Assert.That(response.IsSuccessful, Is.True, " Post API call failed");

            var posts = JsonSerializer.Deserialize<List<Post>>(response.Content);

            Console.WriteLine("total number of posts are "+ posts.Count);
            

        }

        [Test, Order(3)]
        public async Task GetAllCommentsAndValidateCount()
        {
            var request = new RestRequest("/comments", Method.Get);
            var response = await RestClient.ExecuteAsync(request);

            Assert.That(response.IsSuccessStatusCode, Is.True, "Comment API call failed");

            var comments = JsonSerializer.Deserialize<List<Comment>>(response.Content);

            Assert.That(comments.Count, Is.EqualTo(500));

        }

        private static int[] commentIDs = new int[] { 1, 6, 12, 17, 104, 499 };

        [Test, TestCaseSource(nameof(commentIDs))]
        public async Task ValidateThePresenceOfCommentswithGivenIds(int commentIDs)
        {

        }
        

        [OneTimeTearDown]
        public void TearDown()
        {
            RestClient.Dispose();
        }

      
    }
}