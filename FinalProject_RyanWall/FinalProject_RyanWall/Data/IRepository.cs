using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_RyanWall.Models;

namespace FinalProject_RyanWall.Data
{
    public interface IRepository
    {

        List<ToDoList> GetAllList();
        void AddListItem(ToDoList List);
        ToDoList GetListItem(int id);
        void UpdateListItem(ToDoList id);
        void RemoveListItem(ToDoList id);
    }
        
}