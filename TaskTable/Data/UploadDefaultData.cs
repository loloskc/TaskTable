using TaskTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Data
{
    public class UploadDefaultData
    {
        private readonly ApplicationDbContext _context;

        public UploadDefaultData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UploadStatusName()
        {
            var list = _context.Statuses.ToList();
            if (list.Count <= 0)
            {
                var status1 = new Status()
                {
                    StatusId = 1,
                    StatusName = "Создана"
                };
                var status2 = new Status()
                {
                    StatusId = 2,
                    StatusName = "В рабоет"
                };
                var status3 = new Status()
                {
                    StatusId = 3,
                    StatusName = "Завершена"
                };
                _context.Statuses.Add(status1);
                _context.Statuses.Add(status2);
                _context.Statuses.Add(status3);

                _context.SaveChanges();
            }

            
            
        }


    }
}
