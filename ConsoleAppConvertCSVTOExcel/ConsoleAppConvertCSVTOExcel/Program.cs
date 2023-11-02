using OfficeOpenXml;
using Spire.Xls;
using Spire.Xls.Collections;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ConvertCsvToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\NILAM\OneDrive\Desktop\Test CSV files\new";
            string outputFilePath = @"C:\Users\NILAM\OneDrive\Desktop\CSVToExcel.xlsx";

            ConvertCsvToExcel(folderPath, outputFilePath);


            //test();
            //Create an instance of Workbook class
            //Workbook workbook = new Workbook();
            //string[] fileEntries = Directory.GetFiles(@"C:\Users\NILAM\OneDrive\Desktop\Test CSV files");
            //int i = 0;
            //workbook.CreateEmptySheets(3);

            //foreach (string fileName in fileEntries)
            //{
            //    //Load a CSV file
            //    workbook.LoadFromFile(fileName, ",");

            //    //Get the first worksheet

            //    Worksheet sheet = workbook.Worksheets[i];

            //    //Worksheet sheet = workbook.Worksheets.Add("Test " + i + 1);
            //    //sheet.Range[1, 1].Value = "Sheet " + (i + 1);

            //    //Access the used range in the worksheet
            //    CellRange usedRange = sheet.AllocatedRange;
            //    //Ignore errors when saving numbers in the range as text
            //    usedRange.IgnoreErrorOptions = IgnoreErrorType.NumberAsText;

            //    //Autofit columns and rows
            //    usedRange.AutoFitColumns();
            //    usedRange.AutoFitRows();

            //    i++;
            //}
            ////Save the result file
            //workbook.SaveToFile(@"C:\Users\NILAM\OneDrive\Desktop\CSVToExcel.xlsx", ExcelVersion.Version2016);
        }

        //static void test()
        //{
        //    //Create a Workbook instance
        //    Workbook workbook = new Workbook();

        //    //Add 3 worksheets 
        //    string[] fileEntries = Directory.GetFiles(@"C:\Users\NILAM\OneDrive\Desktop\Test CSV files");
        //    workbook.CreateEmptySheets(fileEntries.Count());

        //    //Loop through the worksheets
        //    for (int i = 0; i < workbook.Worksheets.Count; i++)
        //    {
        //        Worksheet sheet = workbook.Worksheets[i];
        //        sheet.Name = fileEntries[i].Split('\\').Last().Split('.')[0];
                 

        //        CellRange usedRange = sheet.AllocatedRange;
        //        //Ignore errors when saving numbers in the range as text
        //        usedRange.IgnoreErrorOptions = IgnoreErrorType.NumberAsText;

        //        //Autofit columns and rows
        //        usedRange.AutoFitColumns();
        //        usedRange.AutoFitRows();
        //    }

        //    //Save the result file
        //    workbook.SaveToFile(@"C:\Users\NILAM\OneDrive\Desktop\CSVToExcel.xlsx", ExcelVersion.Version2016);
        //}

        static void ConvertCsvToExcel(string folderPath, string outputFilePath)
        {
            var csvFiles = Directory.GetFiles(folderPath, "*.DAT");
            if (csvFiles.Length == 0)
            {
                Console.WriteLine("No CSV files found in the specified folder.");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                foreach (var csvFile in csvFiles)
                {
                    var worksheetName = Path.GetFileNameWithoutExtension(csvFile);
                    var worksheet = package.Workbook.Worksheets.Add(worksheetName);

                    using (var reader = new StreamReader(csvFile))
                    {
                        int row = 1;
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            for (int col = 0; col < values.Length; col++)
                            {
                                worksheet.Cells.Style.Numberformat.Format = "@";
                                worksheet.Cells[row, col + 1].Value = values[col];
                            }

                            row++;
                        }
                    }
                }

                // Save the Excel package to the output file
                package.SaveAs(new FileInfo(outputFilePath));
            }
        }

    }
}