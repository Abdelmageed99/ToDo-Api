using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;

namespace TestAPI.Models.CustomModels
{
    public class ResponseModel
    {
        public string Massege { get; set; }

        public List<ToDoItem>? Items { get; set; }   

        public bool MissionIsDone { get; set; }
    }
}
