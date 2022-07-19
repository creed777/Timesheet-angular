using API.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace APITests
{
    public class ProjectControllerTest : IClassFixture<ApiWebApplicationFactory>
    {
        readonly ApiWebApplicationFactory _clientFactory;
        readonly string baseApiUrl = "https://localhost:7035/api/";
        HttpClient _client;

        public ProjectControllerTest(ApiWebApplicationFactory client)
        {
            _clientFactory = client = new ApiWebApplicationFactory();
            _client = _clientFactory.CreateClient();
        }

        [Fact]
        public async Task GetallProjects()
        {
            //need to create fake data 
            var response = await _client.GetStreamAsync(baseApiUrl + "Project/GetAllProjects");
            var deserial = await JsonSerializer.DeserializeAsync<List<ProjectModel>>(response);
            Assert.NotNull(deserial);
        }

        [Fact]
        public async Task GetProject()
        {
            //need to create fake data 
            var response = await _client.GetStreamAsync(baseApiUrl + "Project/GetProject/Test1");
            var deserial = await JsonSerializer.DeserializeAsync<ProjectModel>(response);
            Assert.NotNull(deserial);
        }

        [Fact]
        public async Task AddProject()
        {
            ProjectModel project = new()
            {
                ProjectSn = "ProjectAdd1",
                ProjectName = "API Add Test",
                ProjectStatus = new ProjectStatusModel()
                {
                    Id=1,
                    StatusName = "Active"
                },
                Client = new ClientModel()
                {

                }
            };

            var response = await _client.PostAsJsonAsync(baseApiUrl + "Project/AddProject/", project);
            Assert.NotNull(response);
        }

    }
}