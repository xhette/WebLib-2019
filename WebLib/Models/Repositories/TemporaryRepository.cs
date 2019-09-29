using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories;

namespace WebLib.Models
{
    public class TemporaryRepository
    {
        private int undo;
        private int redo;
        private List<TemporaryModel> TempJournal;

        public TemporaryRepository()
        {
            this.undo = 0;
            this.redo = 0;
            this.TempJournal = new List<TemporaryModel>();

            string query = String.Format("select * from _TempJournal");
            DataSet journalData = DbContext.DbConnection(query);

            foreach (DataRow row in journalData.Tables[0].Rows)
            {
                TempJournal.Add(new TemporaryModel
                {
                    Id = row.Field<int>("id"),
                    TableName = row.Field<string>("table_name"),
                    OperationName = row.Field<string>("operation_name"),
                    OperationDate = row.Field<DateTime>("operation_time"),
                    ColumnId = row.Field<int>("column_id")
                });
            }
        }
    }
}
