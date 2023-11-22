using OverlandNZ.Wrappers.ECAN.Models;
using RestSharp;

namespace OverlandNZ.Wrappers.ECAN;

public class EnvironmentalObservationsClient
{
    private readonly IRestClient _restClient;

    public EnvironmentalObservationsClient(string apiKey, string apiUrl = "https://apis.ecan.govt.nz/")
    {
        _restClient = new RestClient(apiUrl);
        _restClient.AddDefaultQueryParameter("subscription-key", apiKey);
        _restClient.AddDefaultHeader("Content-Type", "application/json");
    }

    public async Task<List<GetObservation>> GetObservations()
    {
        var restRequest = new RestRequest("waterdata/observations/graphql", Method.Post);
        var body = new
        {
	        query = @"
				query {
					getObservations {
						locationId
						name
						nztmx
						nztmy
						type
						unit
					}
				}
            "
        };

        restRequest.AddJsonBody(body);
      
        var response = await _restClient.ExecuteAsync<RiverFlowResponse>(restRequest);
        return response.Data.Data.GetObservations;
    }
}