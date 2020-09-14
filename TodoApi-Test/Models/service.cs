using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi_Test.Models;

namespace TodoApi_Test.Models
{
    public class Service: IService
    {
        private readonly TodoContext _context;

        public Service(TodoContext context)
        {
            _context = context;
        }
        public void Create(TodoItem item)
        {
            if(item ==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.TodoItems.Add(item);
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }
        public TodoItem GetById(long id)
        {
            return _context.TodoItems.Find(id);
        }
        public void Update(TodoItem item)
        {
            
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
    public interface IService
    {
        bool SaveChanges();
        IEnumerable<TodoItem> GetAll();
        TodoItem GetById(long id);
        void Create(TodoItem item);
        void Update(TodoItem item);

    }
}