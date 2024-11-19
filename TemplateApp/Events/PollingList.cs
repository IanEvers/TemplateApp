using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateApp.Constants;
using TemplateApp.Events.Models.Payload;
using TemplateApp.Events.Models.Polling;
using TemplateApp.Invocables;
using TemplateApp.Models.Dto;
using TemplateApp.Models.Response;
using TemplateApp.RestSharp;

namespace TemplateApp.Events;

[PollingEventList]
public class PollingList : AppInvocable
{
    #region Constructors

    public PollingList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #endregion

    [PollingEvent("On polled event", "This is triggered periodically, depending on the user's prefered input.")]
    public async Task<PollingEventResponse<Memory, PollingResponse>> OnProjectCreated(PollingEventRequest<Memory> request)
    {
        var berriesRequest = new AppRestRequest(ApiEndpoints.Berry, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<ListResponse<Berry>>(berriesRequest);

        // If the memory is null, this means that the bird was only just published. We should therefore establish the base case and not fly the bird.
        if (request.Memory is null)
        {
            return new()
            {
                FlyBird = false,
                Memory = new()
                {
                    AllBerries = response.Results
                }
            };
        }

        // Check if there are any new berries since the last poll
        var newBerries = response.Results.Where(x => !request.Memory.AllBerries.Select(y => y.Id).Contains(x.Id));

        return new()
        {
            FlyBird = newBerries.Count() > 0, // Only fly the bird if there are new berries
            Memory = new()
            {
                AllBerries = response.Results // Update the memory
            },
            Result = new()
            {
                NewBerries = newBerries, // The content that will be sent to event when triggered in the bird
            }
        };
    }
}
