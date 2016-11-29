
using System.Collections.Generic;
using System.Linq;
using FinalProject_RyanWall.Models;
using System.Data.Entity;

namespace FinalProject_RyanWall.Data
{
    public class EfRepository : IRepository
    {
         private readonly ToDoDBContext _todocontext = new ToDoDBContext();

        public List<ToDoList> GetAllList()
        {
            return _todocontext.ToDoLists.ToList();
        }

        public void AddListItem(ToDoList List)
        {
            //foreach (var pet in List.Pets)
            //{
            //    _usercontext.Users.Attach(List);
            //}

            _todocontext.ToDoLists.Add(List);
            _todocontext.SaveChanges();
        }

        public ToDoList GetListItem(int id)
        {
            return _todocontext.ToDoLists.Find(id);
        }

        public void UpdateListItem(ToDoList List)
        {
            _todocontext.Entry(List).State = EntityState.Modified;
            _todocontext.SaveChanges();
        }

        public void RemoveListItem(ToDoList List)
        {
            _todocontext.ToDoLists.Remove(List);
            _todocontext.SaveChanges();
        }
    }
}