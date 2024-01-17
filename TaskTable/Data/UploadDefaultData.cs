using TaskTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Data
{
    public class UploadDefaultData
    {
        public void UploadStatusName()
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
        }

    }
}
