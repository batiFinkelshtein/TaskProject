using todoList.Models;
namespace todoList.Interfaces;

public interface Iuser
{
    List<task> GetAllTasks();
     task GetTaskById(int id);
     int AddTask(task newtask);
 
    bool UpdateTask(int id, task newtask);
    
    bool DeleteTask(int id);
     User GetMyUser();

}