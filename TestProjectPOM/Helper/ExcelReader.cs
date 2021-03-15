using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPOM.Helper
{
    public class ExcelReader
    {
        public IEnumerable<object[]> readExcelData(string sheetName, int col1, int col2)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Demo.xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                int rowCount = excelWorksheet.Dimension.End.Row;
                for (int i = 2; i < rowCount; i++)
                {
                    yield return new object[]
                    {
                        excelWorksheet.Cells[i,col1].Value?.ToString().Trim(),
                        excelWorksheet.Cells[i,col2].Value?.ToString().Trim()
                    };
                }
            };
        }
    }
}
