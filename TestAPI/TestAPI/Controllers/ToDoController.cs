using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoDTO;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;
using TestAPI.Services.ToDoService.Interfaces;

namespace TestAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        
         private readonly ITODoService _toDoService;

        public ToDoController(ITODoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("GetAll")]
       
        public async Task<ActionResult<ResponseModel>> GetAllAsync([FromQuery]RequestModel model)
        {
            var result =  await _toDoService.GetAllAsync(model);
            if(!result.MissionIsDone)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseModel>> GetById(int Id)
        {
            var result = await _toDoService.GetByIdAsync(Id);

            if (!result.MissionIsDone)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ResponseModel>> CreateAsync(CreateToDo  createToDo)
        {
            var result = await _toDoService.AddAsync(createToDo);

            if (!result.MissionIsDone)
            {
                return BadRequest(result);
            }
            return Ok(result);

            
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<ResponseModel>> UpdateAsync(int Id, UpdateToDo updateToDo)
        {
            var result =  await _toDoService.UpdateAsync(Id, updateToDo);

            if (!result.MissionIsDone)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<ResponseModel>> DeleteAsync(int Id)
        {
            var result =  await _toDoService.DeleteAsync(Id);

            if (!result.MissionIsDone)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



    }
}
