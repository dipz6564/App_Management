using System.Collections.Generic;
using System.Linq;
using TaskManagementEngine.Interfaces;
using TaskManagementEngine.Models;

namespace TaskManagementEngine.Repositories
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly List<Column> _columns;

        public ColumnRepository()
        {
            _columns = new List<Column>();
        }

        public void AddColumn(Column column)
        {
            column.Id = _columns.Count > 0 ? _columns.Max(c => c.Id) + 1 : 1;
            _columns.Add(column);
        }

        public Column GetColumnByName(string columnName)
        {
            return _columns.FirstOrDefault(c => c.Name == columnName);
        }

        public IEnumerable<Column> GetAllColumns()
        {
            return _columns;
        }
    }
}
