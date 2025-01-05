using Microsoft.AspNetCore.Mvc;
using MoeedsRussianNovelLibrary.Models;
using MoeedsRussianNovelLibrary.Services;

namespace MoeedsRussianNovelLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovelsController : ControllerBase
    {
        private readonly INovelService _novelService;

        public NovelsController(INovelService novelService)
        {
            _novelService = novelService;
        }

        // GET: api/novels
        [HttpGet]
        public ActionResult<IEnumerable<Novel>> Get()
        {
            return Ok(_novelService.GetAllNovels());
        }

        // GET: api/novels/5
        [HttpGet("{id}")]
        public ActionResult<Novel> Get(int id)
        {
            var novel = _novelService.GetNovelById(id);
            if (novel == null) return NotFound();
            return Ok(novel);
        }

        // POST: api/novels
        [HttpPost]
        public ActionResult<Novel> Post([FromBody] Novel novel)
        {
            var createdNovel = _novelService.CreateNovel(novel);
            return CreatedAtAction(nameof(Get), new { id = createdNovel.Id }, createdNovel);
        }

        // PUT: api/novels/5
        [HttpPut("{id}")]
        public ActionResult<Novel> Put(int id, [FromBody] Novel novel)
        {
            var updatedNovel = _novelService.UpdateNovel(id, novel);
            if (updatedNovel == null) return NotFound();
            return Ok(updatedNovel);
        }

        // DELETE: api/novels/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _novelService.DeleteNovel(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
