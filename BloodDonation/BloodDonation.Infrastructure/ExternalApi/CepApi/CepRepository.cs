using BloodDonation.Core.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace BloodDonation.Infrastructure.ExternalApi.CepApi
{
    public class CepRepository : ICepRepository
    {
        private readonly RestClient _client;

        public CepRepository()
        {
            var restOptions = new RestClientOptions("https://viacep.com.br/ws/")
            {
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromSeconds(30)
            };
            _client = new RestClient(restOptions);
        }

        public async Task<Address> GetAddress(string cep, CancellationToken cancellationToken)
        {
            try
            {
                var restRequest = new RestRequest($"{cep}/json/", Method.Get);
                var result = await _client.ExecuteAsync(restRequest, cancellationToken);

                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return null;

                System.Diagnostics.Debug.Print($"Print: {result.StatusCode}");
                var viaCepModel = JsonConvert.DeserializeObject<ViaCepModel>(result.Content);
                if (viaCepModel == null)
                    return null;

                System.Diagnostics.Debug.Print($"cepContent: {viaCepModel.Cep} - {viaCepModel.Estado}");

                return new Address
                {
                    Cep = viaCepModel.Cep,
                    City = viaCepModel.Localidade,
                    Logradouro = viaCepModel.Logradouro,
                    State = viaCepModel.Estado
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao extrair os dados do CEP. Mensagem: {ex.Message}");
                return null;
                //throw;
            }
        }
    }
}
