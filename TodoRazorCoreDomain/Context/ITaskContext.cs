using System;
using System.Collections.Generic;
using System.Text;
using TodoRazorCoreDomain.Models;

namespace TodoRazorCoreDomain.Context
{
    public interface ITaskContext
    {
        //returns a range of tasks. this is usefull for pagination
        IEnumerable<Task> GetRange(int take, int skip = 0);
        //returns one task filtered by given ID
        Task Get(int id);
        //deletes task by given ID
        void Delete(int id);
        //adds task and returns ID
        int AddNewTask(Task task);
        //updates task and returns ID
        int Update(Task task);
    }
}
