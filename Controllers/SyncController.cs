using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncServer;

[ApiController]
[Route("api/sync")]
public class SyncController : ControllerBase
{
    private readonly SyncDBContext _db;

    public SyncController(SyncDBContext db) => _db = db;

    [HttpPost("push/dict")]
    public async Task<IActionResult> PushDict([FromBody] List<Dict> items)
        => await PushGeneric(_db.Dicts, items);

    [HttpGet("pull/dict")]
    public async Task<IActionResult> PullDict([FromQuery] DateTime since)
    {
        var result = await _db.Dicts
            .Where(x => x.Modification_Time > since )
            .ToListAsync();
        return Ok(result);
    }
    [HttpPost("push/topic")]
    public async Task<IActionResult> PushTopic([FromBody] List<Topic> items)
        => await PushGeneric(_db.Topics, items);

    [HttpGet("pull/topic")]
    public async Task<IActionResult> PullTopic([FromQuery] DateTime since)
    {
        var result = await _db.Topics
            .Where(x => x.Modification_Time > since)
            .ToListAsync();
        return Ok(result);
    }

    // аналогично PushTopic / PullTopic

    private async Task<IActionResult> PushGeneric<T>(DbSet<T> set, List<T> items)
        where T : class, ISyncTables
    {
        foreach (var incoming in items)
        {
            var existing = await set.FindAsync(incoming.DBID, incoming.Id);

            if (existing is null)
            {
                set.Add(incoming);
            }
            else if (incoming.Modification_Time > existing.Modification_Time)
            {
                _db.Entry(existing).CurrentValues.SetValues(incoming);
            }
        }

        await _db.SaveChangesAsync();
        return Ok(new { applied = items.Count });
    }
}