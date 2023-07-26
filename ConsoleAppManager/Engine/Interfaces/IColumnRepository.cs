using System.Collections.Generic;
using TaskManagementEngine.Models;

namespace TaskManagementEngine.Interfaces
{
    public interface IColumnRepository
    {
        void AddColumn(Column column);
        Column GetColumnByName(string columnName);
        IEnumerable<Column> GetAllColumns();
    }
}
