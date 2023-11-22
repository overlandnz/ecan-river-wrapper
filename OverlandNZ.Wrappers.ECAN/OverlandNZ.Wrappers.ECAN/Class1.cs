using GraphQL.SystemTextJson;
using GraphQL.Types;

namespace OverlandNZ.Wrappers.ECAN;

public class EnvironmentalObservationsClient
{
    private readonly string _apiKey;

    public EnvironmentalObservationsClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<string> GetObservations()
    {
        var schema = Schema.For(@"
            type Query {
                getObservations: [ObservationQueryResult!]!
            }

            type ObservationQueryResult {
              locationId: ID!
              name: String!
              nztmx: Decimal!
              nztmy: Decimal!
              type: ObservationType!
              unit: String!
              observations(filter: TimeRangeFilter!): [Observation!]!
            }

            type Observation {
              timestamp: DateTime!
              value: Decimal!
              qualityCode: String!
            }

            input ObservationsFilter {
              locations: LocationFilter
              observationTypes: [ObservationType!]
            }

            input LocationFilter {
              locationId: ID
              nameContains: String
            }

            enum ObservationType {
              FLOW
            }
        ");
        
        var json = await schema.ExecuteAsync(_ =>
        {
            _.Query = "{ getObservations { name } }";
        });
        
        return json;
    }
}