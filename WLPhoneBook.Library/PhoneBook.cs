using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WLPhoneBook.Library
{
    public class PhoneBook
    {
        public string[] Header { get; }
        public List<PhoneBookRecord> Records { get; } = new List<PhoneBookRecord>();

        public PhoneBook()
        {
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo("phonebook.xlsx")))
            {
                ExcelWorkbook workbook = xlPackage.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.Where(w => w.Name == "phonebook").Single();
                ExcelTable table = worksheet.Tables.Where(t => t.Name == "phonebook_table").Single();
                Header = table.Columns.Select(c => c.Name).ToArray();

                int totalRows = worksheet.Dimension.End.Row;
                int totalColumns = worksheet.Dimension.End.Column;

                for (int i = 2; i <= totalRows; i++)
                {
                    Records.Add(new PhoneBookRecord(
                        worksheet.Cells[i, 1].Text,
                        worksheet.Cells[i, 2].Text,
                        worksheet.Cells[i, 3].Text,
                        worksheet.Cells[i, 4].Text,
                        worksheet.Cells[i, 5].Text,
                        worksheet.Cells[i, 6].Text,
                        worksheet.Cells[i, 7].Text
                    ));
                }
            }
        }

        public List<PhoneBookRecord> SearchRecords(string searchText)
        {
            var records = from r in Records
                          where r.Building.ToLower().Contains(searchText.ToLower())
                          || r.Section.ToLower().Contains(searchText.ToLower())
                          || r.Subsection.ToLower().Contains(searchText.ToLower())
                          || r.Position.ToLower().Contains(searchText.ToLower())
                          || r.Name.ToLower().Contains(searchText.ToLower())
                          || r.Description.ToLower().Contains(searchText.ToLower())
                          || r.PhoneNumber.ToLower().Contains(searchText.ToLower())
                          select r;
            return records.ToList();
        }
    }
}
