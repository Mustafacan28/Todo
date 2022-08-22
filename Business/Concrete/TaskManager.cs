
using Business.Abstract;
using Business.MessagesContent.Models;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal; 
        }

        public void  Add(Taskk task)
        {

            task.StartDate = DateTime.Now;
            task.Status = false;
              _taskDal.Add(task);
        }

        public void Delete(Taskk task)
        {
            _taskDal.Delete(task);  
        }

        public List<Taskk> GetAll()
        {
           return _taskDal.GetAll();
        }

        public Taskk GetById(int id)
        {
            return _taskDal.Get(x=>x.Id == id); 
        }

        public void Update(Taskk task)
        {
           
            _taskDal.Update(task);
        }
    }
}
