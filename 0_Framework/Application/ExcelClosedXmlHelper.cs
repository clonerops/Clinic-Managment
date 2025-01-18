using ClosedXML.Excel;

namespace _0_Framework.Application
{
    public static class ExcelClosedXmlHelper
    {
        public static byte[] GenrateExcelClosedXml<T>(List<T> data, string sheetName, List<string> columns, Dictionary<string, string> columnHeaders)
        {

            byte[] excelFile = null;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);
                    var properties = typeof(T).GetProperties();

                    var filterProperties = properties.Where(x => columns.Contains(x.Name)).ToList();

                    for (var i = 0; i < filterProperties.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = columnHeaders[filterProperties[i].Name];
                    }


                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < filterProperties.Count; j++)
                        {
                            var cellValue = filterProperties[j].GetValue(data[i])?.ToString();
                            worksheet.Cell(i + 2, j + 1).Value = cellValue ?? string.Empty;
                        }
                    }

                    var headerRange = worksheet.Range(1, 1, 1, filterProperties.Count);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin; worksheet.Columns().AdjustToContents();
                    worksheet.RightToLeft = true;

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream); excelFile = stream.ToArray();
                    }

                }

            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return excelFile;
        }

    }
}
