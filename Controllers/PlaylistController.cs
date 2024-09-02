using Microsoft.AspNetCore.Mvc;
using MongoDB.Services;
using MongoDB.Models;

namespace MongoDB.Controllers;
// We will have to define the endpoint within the controller and do the work within our service.

// The class PlaylistController extends Controller

// Path for accessing the different endpoint functions for this particular controller class
[ApiController]
[Route("api/[controller]")]
public class PlaylistController: Controller {
    private readonly MongoDBService _mongoDBService;
    // private readonly variable for the MongoDBService to access it locally within this particular controller class  
    
    // constructor method - we will pass in that mongoDBService which will be handled for us
    public PlaylistController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    // defining the endpoints

    // returns a Task because it's async
    [HttpGet]
    public async Task<List<Playlist>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist) {
        await _mongoDBService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new { id = playlist.Id } , playlist);
    }

    // Put is common for update operations 
    // We want to find which document we want to update
    // options - in the body, query parameter, route parameter, etc.

    // Add a new item to the existing playlist
    // Specify the id passed in from the user - from that route parameter
    // Accept a payload from the body - that's going to contain the actual movieId

    // route parameter
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {
        await _mongoDBService.AddToPlaylistAsync(id, movieId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}