using API.Interfaces;
using API.Models;


namespace APITests.BogusData
{
    public class ClientBogusData : IClientBogusData
    {
        private IClientDataServices _cds { get; set; }

        public ClientBogusData(IClientDataServices cds)
        {
            _cds = cds;
        }

        public async Task GenerateClientData()
        {
            var status = new ClientStatusModel()
            {
                Id = 1,
                ClientStatusName = "Active"
            };

            //var client = new Faker<ClientModel>()
            //    .StrictMode(true)
            //    .RuleFor(c => c.ClientId, f => f.Random.Number(1, 1000))
            //    .RuleFor(c => c.ClientStatus, f => f.PickRandom(status))
            //    .RuleFor(c => c.ClientDescription, f => f.Random.Number(1, 1000).ToString())
            //    .RuleFor(c => c.ClientName, f => string.Concat("Client", f.Random.Number(1, 1000).ToString()));

            //var testClient = client.Generate();

            //await _cds.AddClientAsync(testClient);

        }
    }
}
