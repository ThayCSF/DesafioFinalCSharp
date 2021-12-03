using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.Sytem.Teste.Support;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BlueBank.Sytem.Teste.Api.Controller
{
    public class CustomerControllerTests : IntegrationTest
    {
        private string CustomerEndpoint { get; set; }

        public CustomerControllerTests(ApiWebApplicationFactory fixture)
            : base(fixture)
        {
            CustomerEndpoint = $"/api/customer";
        }

        [Fact]
        public void GetAll_ValidRequest_ReturnSuccess()
        {
            // Act
            var result = Task.Run(async () => await _client.GetAsync($"{CustomerEndpoint}")).Result;
            
            // Assert
            result.Should().Be200Ok();
        }

        [Fact]
        public void PostAndGetById_ValidRequest_ReturnSuccess()
        {
            // Arrange
            var request = new AddCustomerRequest()
            { 
                Name = "Teste",
                Telephone = "55111111111"
            };

            var data = JsonData(request);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{CustomerEndpoint}", data)).Result;
            var customerResult = ObjectData<AddCustomerResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.GetAsync($"{CustomerEndpoint}/{customerResult.Id}")).Result;

            // Assert
            var getResult = ObjectData<GetCustomerByIdResponse>(result.Content.ReadAsStringAsync().Result);

            result.Should().Be200Ok();
            getResult.Id.Should().Be(customerResult.Id);
        }

        [Fact]
        public void PostAndRemove_ValidRequest_ReturnSuccess()
        {
            // Arrange
            var request = new AddCustomerRequest()
            {
                Name = "Teste",
                Telephone = "55111111111"
            };

            var data = JsonData(request);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{CustomerEndpoint}", data)).Result;
            var customerResult = ObjectData<AddCustomerResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.DeleteAsync($"{CustomerEndpoint}/{customerResult.Id}")).Result;

            // Assert
            result.Should().Be200Ok();
        }

        [Fact]
        public void PostAndPut_ValidRequest_ReturnSuccess()
        {
            // Arrange
            var postRequest = new AddCustomerRequest()
            {
                Name = "Teste",
                Telephone = "55111111111"
            };
            var postData = JsonData(postRequest);

            var putRequest = new UpdateCustomerRequest()
            {
                Name = "Atualizado",
                Telephone = "55111111111"
            };
            var putData = JsonData(putRequest);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{CustomerEndpoint}", postData)).Result;
            var customerResult = ObjectData<AddCustomerResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.PutAsync($"{CustomerEndpoint}/{customerResult.Id}", putData)).Result;

            // Assert
            var putResult = ObjectData<UpdateCustomerResponse>(result.Content.ReadAsStringAsync().Result);

            result.Should().Be200Ok();
            putResult.Name.Should().Be("Atualizado");
        }

        private static StringContent JsonData<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static T ObjectData<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
