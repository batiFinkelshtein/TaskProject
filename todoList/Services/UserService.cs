using todoList.Models;
using todoList.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Text.Json;
namespace todoList.Services;
public class UserService : Iuser
{
    List<User> users { get; }
    private string fileName = "User.json";
    public userServices()
    {
        this.fileName = Path.Combine(/*webHost.ContentRootPath,*/ "Data", "User.json");

        using (var jsonFile = File.OpenText(fileName))
        {
#pragma warning disable CS8601 
            users = JsonSerializer.Deserialize<List<User>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
#pragma warning restore CS8601 
        }
    }
    private void saveToFile()
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(users));
    }

    public List<User> GetAll() => users;

    public UserService GetById(int id)
    {

        return users.FirstOrDefault(u => u.Id == id);

    }

    public int Add(User newUser)
    {
        if (users.Count == 0)

        {
            newUser.Id = 1;
        }
        else
        {
            newUser.Id = users.Max(u => u.Id) + 1;

        }

        users.Add(newTask);
        saveToFile();
        return newUser.Id;
    }

    public bool Update(int id, User newUser)
    {
        if (id != newUser.Id)
            return false;

        var existingUser = GetById(id);
        if (existingUser == null)
            return false;

        var index = users.IndexOf(existingUser);
        if (index == -1)
            return false;

        users[index] = newUser;
        saveToFile();
        return true;
    }


    public bool Delete(int id)
    {
        var existingUser = GetById(id);
        if (existingTask == null)
            return false;

        var index = tasks.IndexOf(existingTask);
        if (index == -1)
            return false;

        tasks.RemoveAt(index);
        saveToFile();
        return true;
    }
    public int Count => tasks.Count();


}

public static class TaskUtils
{
    public static void AddTask(this IServiceCollection services)
    {
        services.AddSingleton<ITaskService, todoListServices>();
    }
}




