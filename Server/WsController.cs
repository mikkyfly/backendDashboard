using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Server;

[ApiController]
public class WsController : ControllerBase
{
    [Route("/ws")]
    public async Task<ActionResult> Test(
        [FromServices] ISource source)
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            //HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return BadRequest();
        }

        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

        var completionSource = new TaskCompletionSource();

        async void Send(List<Data> datas)
        {
            try
            {
                var jsons = datas.Select(d => JsonSerializer.Serialize(d)).ToList();

                foreach (var json in jsons)
                {
                    await webSocket.SendAsync(Encoding.UTF8.GetBytes(json),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                source.Notify -= Send;
                completionSource.SetException(ex);
            }
        }

        source.Notify += Send;
        
        await completionSource.Task;
        return null;
    }
}