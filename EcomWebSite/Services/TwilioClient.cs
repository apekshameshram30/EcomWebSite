using Twilio.Clients;
using Twilio.Http;

namespace Web.Services
{
    public class TwilioClient:ITwilioRestClient
    {
        private readonly TwilioRestClient _client;
        public TwilioClient(IConfiguration configuration, System.Net.Http.HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            _client = new TwilioRestClient(
                configuration["Twilio:AccountSid"],
                configuration["Twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(httpClient));
        }

        public string AccountSid => _client.AccountSid;

        public string Region => _client.Region;

        public Twilio.Http.HttpClient HttpClient => _client.HttpClient;

        public Response Request(Request request) => _client.Request(request);

        public Task<Response> RequestAsync(Request request) => _client.RequestAsync(request);

    }
}
