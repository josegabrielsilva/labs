using System.Net;
using System.Text;
using System.Text.Json;

namespace Labs.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class UserRegisterStepDefinitions
    {
        private readonly HttpClient _client;
        private HttpResponseMessage _response;

        public UserRegisterStepDefinitions()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7007");
        }

        [Given("que a API User está disponível")]
        public void TheUserApiAreAvailable()
        {
            // 
        }

        [When("eu envio uma solicitação POST para o endpoint (.*) com os seguintes dados:")]
        public void WhenTheTwoNumbersAreAdded(string endpoint, Table table)
        {
            var data = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                data.Add("Name", row["Name"]);
                data.Add("Email", row["Email"]);
                data.Add("Password", row["Password"]);
            }
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:7007{endpoint}"),
                Content = new StringContent(
                        JsonSerializer.Serialize(new {
                            Name = data["Name"],
                            Email = data["Email"],
                            Password = data["Password"]
                        }), 
                        Encoding.UTF8, "application/json"
                    )
            };
            _response = _client.SendAsync(requestMessage).Result;
        }

        [Then("a resposta da API deve conter o código de status 201")]
        public void TheHttpStatusCodeShouldBe201Created()
            => _response.StatusCode.Should().Be(HttpStatusCode.Created);

        [Then("o usuário deve ser cadastrado com sucesso no sistema")]
        public void TheUserShouldBeRegistered()
        {
            var createdUserId = 1; //get from response code

            var response = _client.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7007/user/{createdUserId}")
            }).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }           

    }
}