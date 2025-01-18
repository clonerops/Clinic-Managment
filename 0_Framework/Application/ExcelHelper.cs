using OfficeOpenXml;

namespace _0_Framework.Application
{
    public static class ExcelHelper
    {
        public static byte[] GenrateExcel<T>(List<T> data, string sheetName, List<string> columns, Dictionary<string, string> columnHeaders)
        {

            byte[] excelFile = null;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                var properties = typeof(T).GetProperties();

                var filterProperties = properties.Where(x => columns.Contains(x.Name)).ToList();

                for(var i = 0; i<filterProperties.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = filterProperties[i].Name;
                }

                for (int i = 0; i < filterProperties.Count; i++) 
                { 
                    worksheet.Cells[1, i + 1].Value = columnHeaders[filterProperties[i].Name]; 
                }

                for (int i = 0; i < data.Count; i++) 
                { 
                    for (int j = 0; j < filterProperties.Count; j++) 
                    {
                        worksheet.Cells[i + 2, j + 1].Value = filterProperties[j].GetValue(data[i]); 
                    } 
                }

                using (var range = worksheet.Cells[1, 1, 1, filterProperties.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                worksheet.Cells.AutoFitColumns();
                worksheet.View.RightToLeft = true;

                excelFile = package.GetAsByteArray();
                return excelFile;

            }
        }
    }
}
