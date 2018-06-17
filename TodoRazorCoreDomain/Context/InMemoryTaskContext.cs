using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoRazorCoreDomain.Models;

namespace TodoRazorCoreDomain.Context
{
    public class InMemoryTaskContext : ITaskContext
    {
        List<Task> taskList = new List<Task>();
        private int idCounter = 1;
        //returns a range of tasks. this is usefull for pagination
        public IEnumerable<Task> GetRange(int take, int skip)
        {
            return taskList.GetRange(skip, take);
            //return taskList.GetRange(skip, take).OrderBy(a => a.TaskPriority);
        }
        //returns one task filtered by given ID
        public Task Get(int id)
        {           
            return taskList.Find(x => x.Id.Equals(id));
        }
        //deletes task by given ID
        public void Delete(int id)
        {
            taskList.Remove(taskList.Find(x => x.Id.Equals(id)));
        }
        //adds task and returns ID
        public int AddNewTask(Task task)
        {
            task.Id = idCounter++;
            taskList.Add(task);
            return task.Id;
        }
        //updates task and returns ID
        public int Update(Task task)
        {
            var taskModel = Get(task.Id);
            if (taskModel == null)
                throw new Exception($"There is no task with id {task.Id}");
            taskModel.Title = task.Title;
            taskModel.Description = task.Description;
            taskModel.StartDate = task.StartDate;
            taskModel.EndDate = task.EndDate;
            taskModel.TaskPriority = task.TaskPriority;
            taskModel.TaskStatus = task.TaskStatus;
            return task.Id;
        }
    }

}
