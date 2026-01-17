using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyViewerV2.Utils
{
    public class ExcelUtils
    {
        public static DateTime ParseExcelDate(OfficeOpenXml.ExcelRange cell)
        {
            if (cell == null || cell.Value == null)
                return DateTime.Now;

            if (cell.Value is DateTime dt)
                return dt;

            if (DateTime.TryParse(cell.Text, out DateTime parsed))
                return parsed;

            return DateTime.Now;
        }
    }
}
