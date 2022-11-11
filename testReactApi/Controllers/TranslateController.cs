using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace testReactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private const string Key = "8dcc4dbbf8304acdaf413e521de6f294";
        private const string Endpoint = "https://api.cognitive.microsofttranslator.com";
        private const string Location = "centralus";

        [HttpGet]
        public async Task<IActionResult> Translate()
        {
            const string route = "/translate?api-version=3.0&from=en&to=fr&to=zu";
            const string textToTranslate =
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;";

            var body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using var client = new HttpClient();
            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoint + route),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
                Headers = { { "Ocp-Apim-Subscription-Key", Key }, { "Ocp-Apim-Subscription-Region", Location } }
            };


            // Send the request and get response.
            var response = await client.SendAsync(request).ConfigureAwait(false);

            // Read response as a string.
            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}
