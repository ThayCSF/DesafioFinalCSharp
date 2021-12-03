using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.Sytem.Teste.Support;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlueBank.Sytem.Teste.Api.Controller
{
    public class AccountControllerTests : IntegrationTest
    {
        private string AccountEndpoint { get; set; }

        public AccountControllerTests(ApiWebApplicationFactory fixture)
            : base(fixture)
        {
            AccountEndpoint = $"/api/account";
        }

        [Fact]
        public void PostAndGetById_Accounts_ValidRequest_ReturnSuccess()
        {
            var request = new AddAccountRequest()
            {
                CustomerId = Guid.NewGuid(),
                Balance = 950
            };

            var data = JsonData(request);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{AccountEndpoint}", data)).Result;
            var accountResult = ObjectData<AddAccountResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.GetAsync($"{AccountEndpoint}/{accountResult.Id}")).Result;

            // Assert
            var getResult = ObjectData<GetAccountByIdResponse>(result.Content.ReadAsStringAsync().Result);

            result.Should().Be200Ok();
            getResult.Id.Should().Be(accountResult.Id);
        }
        
        [Fact]
        public void PostAndRemove_Accounts_ValidRequest_ReturnSuccess()
        {
            var request = new AddAccountRequest()
            {
                CustomerId = Guid.NewGuid(),
            Balance = 500
            };

            var data = JsonData(request);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{AccountEndpoint}", data)).Result;
            var accountResult = ObjectData<AddAccountResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.DeleteAsync($"{AccountEndpoint}/{accountResult.Id}")).Result;

            // Assert
            result.Should().Be200Ok();
        }

        [Fact]
        public void PostAndPut_Accounts_ValidRequest_ReturnSuccess()
        {
            var postRequest = new AddAccountRequest()
            {
                CustomerId = Guid.NewGuid(),
            Balance = 295
            };
            var postData = JsonData(postRequest);

            var putRequest = new UpdateAccountRequest()
            {
                Id = Guid.NewGuid(),
                Balance = 100
            };
            var putData = JsonData(putRequest);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{AccountEndpoint}", postData)).Result;
            var accountResult = ObjectData<AddCustomerResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.PutAsync($"{AccountEndpoint}/{accountResult.Id}", putData)).Result;

            // Assert
            var putResult = ObjectData<UpdateAccountResponse>(result.Content.ReadAsStringAsync().Result);

            result.Should().Be200Ok();
            putResult.Balance.Should().Be(100);
        }

        [Fact]
        public void GetAll_Accounts_ValidRequest_ReturnSuccess()
        {
            // Act
            var result = Task.Run(async () => await _client.GetAsync($"{AccountEndpoint}")).Result;

            // Assert
            result.Should().Be200Ok();
        }

        [Fact]
        public void GetAll_Operations_ValidRequest_ReturnSuccess()
        {
            // Act
            var result = Task.Run(async () => await _client.GetAsync($"{AccountEndpoint}/operation")).Result;

            // Assert
            result.Should().Be200Ok();
        }

        [Fact]
        public void Post_Operations_ValidRequest_ReturnSuccess()
        {
            
            var request = new AddOperationRequest()
            {
                AccountOrigin = Guid.NewGuid(),
                AccountRecipient = Guid.NewGuid(),
                Value = 155
            };

            var data = JsonData(request);

            // Act
            var postResult = Task.Run(async () => await _client.PostAsync($"{AccountEndpoint}/operation", data)).Result;
            var operationResult = ObjectData<AddOperationResponse>(postResult.Content.ReadAsStringAsync().Result);
            var result = Task.Run(async () => await _client.GetAsync($"{AccountEndpoint}/{operationResult.Id}")).Result;

            // Assert
            result.Should().Be200Ok();
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
