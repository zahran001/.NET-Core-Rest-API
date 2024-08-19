using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Services;
using MongoDB.Models;

namespace MongoDB.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController: Controller {
    private readonly MongoDBService _mongoDBService;
    
    public PlaylistController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    // returns a Task because it's async
    [HttpGet]
    public async Task<List<Playlist>> Get() {}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist) {}

    // route parameters
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {}

}