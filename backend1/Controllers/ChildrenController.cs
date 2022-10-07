using backend1.Models;
using backend1.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend1.Controllers
{
    [Route("api/children")]
    public class ChildrenController: Controller
    {
        //getChildren
        //inscribeChild
        private IChildService _childService;
        
        public ChildrenController(IChildService childService)
        {
            _childService = childService;            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildModel>>> GetChildrenAsync()
        {            
            try
            {
                var children = await _childService.GetChildrenAsync();
                return Ok(children);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happened.");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ChildModel>> CreateChildAsync([FromBody] ChildModel child)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var newChild = await _childService.CreateChildAsync(child);
                return Created($"/api/children/{newChild.Id}", newChild);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happened.");
            }
        }
    }
}
