using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class ProjectHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

#region WorkItem

    public async Task ItemAdded(Guid columnId, Guid itemId)
    {
        await Clients.All.SendAsync("ItemAdded", columnId, itemId);
    }

    public async Task ItemUpdate(Guid itemId)
    {
        await Clients.All.SendAsync("ItemUpdate", itemId);
    }

    public async Task ItemDeleted(Guid columnId, Guid itemId)
    {
        await Clients.All.SendAsync("ItemDeleted", columnId, itemId);
    }

#endregion

#region WorkColumn

    public async Task ColumnAdded(Guid columnId)
    {
        await Clients.All.SendAsync("ColumnAdded", columnId);
    }

    public async Task ColumnUpdate(Guid columnId)
    {
        await Clients.All.SendAsync("ColumnUpdate", columnId);
    }

    public async Task ColumnDeleted(Guid columnId)
    {
        await Clients.All.SendAsync("ColumnDeleted", columnId);
    }

#endregion
}