using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Data;
using TaskTable.Models;

namespace TaskTable.Repository
{
    public class MyTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public MyTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(MyTask myTask)
        {
            _context.Add(myTask);
            return Save();
        }

        public bool Delete(MyTask myTask)
        {
            _context.Remove(myTask);
            return Save();
        }

        public bool Update(MyTask myTask)
        {
            _context.Update(myTask);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
