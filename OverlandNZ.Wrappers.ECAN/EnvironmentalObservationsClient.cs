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

    public string GenerateQuery(DateTime observationTime)
    {
	    return $@"
				query {{
					getObservations {{
						locationId
						name
						nztmx
						nztmy,
						observations(filter: {{ start: ""{observationTime.ToString("yyyy-MM-dd HH:00:00")}"", end: ""{observationTime.ToString("yyyy-MM-dd HH:59:59")}"" }}) {{
							qualityCode
							timestamp
							value
						}}
						type
						unit
					}}
				}}
            ";
    }

    /// <summary>
    /// Gets observations for the given hour
    /// YYYY-MM-DD HH:00:00 - YYYY-MM-DD HH:59:59
    /// </summary>
    /// <param name="observationTime"></param>
    /// <returns></returns>
    public async Task<List<GetObservation>> GetObservations(DateTime observationTime)
    {
        var restRequest = new RestRequest("waterdata/observations/graphql", Method.Post);
        var body = new
        {
            query = GenerateQuery(observationTime)
        };

        restRequest.AddJsonBody(body);

        var response = await _restClient.ExecuteAsync<RiverFlowResponse>(restRequest);
        return response.Data.Data.GetObservations;
    }
}