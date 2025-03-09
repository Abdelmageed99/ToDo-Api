using AutoMapper;
using TestAPI.Models;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoDTO;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;


namespace TestAPI.Helpers.AutoMapper
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<CreateToDo, ToDoItem>();

            CreateMap<UpdateToDo, ToDoItem>();
                
        }

    }
}
