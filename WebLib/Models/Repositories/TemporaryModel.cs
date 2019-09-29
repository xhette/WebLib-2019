using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class TemporaryModel
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public string OperationName { get; set; }

        public DateTime OperationDate { get; set; }

        public int ColumnId { get; set; } 
    }
}
