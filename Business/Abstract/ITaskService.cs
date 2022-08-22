using Business.MessagesContent.Models;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Abstract
{
   public interface ITaskService
    {
        void Add(Taskk task);
        void Delete(Taskk task);
        void Update(Taskk task);
        List<Taskk> GetAll();
        Taskk GetById(int id);
    }
}
