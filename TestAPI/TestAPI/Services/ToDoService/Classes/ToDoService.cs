using AutoMapper;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoDTO;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;
using TestAPI.Services.ToDoService.Interfaces;
using TestAPI.Models.CustomModels;

namespace TestAPI.Services.ToDoService.Classes
{
    public class ToDoService : ITODoService
    {
        private readonly IRepository<ToDoItem> _repository;
        private readonly IMapper _mapper;

        public ToDoService(IRepository<ToDoItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<ResponseModel> GetAllAsync(RequestModel model)
        {
            var responseModel = new ResponseModel();
            var toDos = await _repository.GetAllAsync(model);

            if (toDos != null)
            {
                responseModel.Items = toDos;
                responseModel.Massege = " All itemes Returned";
                responseModel.MissionIsDone = true;

                return responseModel;
            }

            responseModel.Massege = "There is no items to return";
            responseModel.MissionIsDone = false;
            return responseModel;


        }

        public async Task<ResponseModel> GetByIdAsync(int Id)
        {
            var responseModel = new ResponseModel();
            var toDo = await _repository.GetByIdAsync(Id);

            if (toDo != null)
            {
                responseModel.Items = new List<ToDoItem> { toDo };
                responseModel.Massege = " Item is rturned";
                responseModel.MissionIsDone = true;

                return responseModel;
            }

            responseModel.Massege = " 0 item  return";
            responseModel.MissionIsDone = false;
            return responseModel;

        }

        public async Task<ResponseModel> AddAsync(CreateToDo entity)
        {
            var responseModel = new ResponseModel();

            var toDo = _mapper.Map<ToDoItem>(entity);
            var createdIteme = await _repository.AddAsync(toDo);

            if (createdIteme != null)
            {
                responseModel.Items = new List<ToDoItem> { toDo };
                responseModel.Massege = " Item is created";
                responseModel.MissionIsDone = true;

                return responseModel;
            }

            responseModel.Massege = " Item not created";
            responseModel.MissionIsDone = false;
            return responseModel;
        }

        public async Task<ResponseModel> DeleteAsync(int Id)
        {
            var responseModel = new ResponseModel();


            var deletedItem = await _repository.DeleteAsync(Id);

            if (deletedItem != null)
            {
                responseModel.Items = new List<ToDoItem> { deletedItem };
                responseModel.Massege = " Item is deleted";
                responseModel.MissionIsDone = true;

                return responseModel;
            }

            responseModel.Massege = " Item not deleted";
            responseModel.MissionIsDone = false;
            return responseModel;
        }

        public async Task<ResponseModel> UpdateAsync(int Id, UpdateToDo entity)
        {
            var responseModel = new ResponseModel();

            var toDo = _mapper.Map<ToDoItem>(entity);
            var updatedItem = await _repository.UpdateAsync(Id, toDo);

            if (updatedItem != null)
            {
                responseModel.Items = new List<ToDoItem> { updatedItem };
                responseModel.Massege = " Item is Updated";
                responseModel.MissionIsDone = true;

                return responseModel;
            }

            responseModel.Massege = " Item not Updated";
            responseModel.MissionIsDone = false;
            return responseModel;
        }
    }
 

    }

