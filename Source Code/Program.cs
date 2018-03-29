using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using excel = Microsoft.Office.Interop.Excel;
using PrimeNumberGenerater;
using System.Text.RegularExpressions;
using System.IO;

namespace PrimeNumberTestDrivenusingSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("||***Welcome to Test Driven Prime Number Generator***||");
            try
            {
                if (File.Exists(@"C:\PrimeNumberTestDrivenusingSelenium\TestCase_Input.xlsx"))
                {
                    excel.Application x1Appl = new excel.Application();
                    excel.Workbook x1WorkBook = x1Appl.Workbooks.Open(@"C:\PrimeNumberTestDrivenusingSelenium\TestCase_Input.xlsx");
                    excel._Worksheet x1WorkSheet = x1WorkBook.Sheets[1];
                    excel.Range x1Range = x1WorkSheet.UsedRange;
                    PrimeNumber objPrimeNumber = new PrimeNumber();
                    for (int i = 2; i <= Convert.ToInt32(x1Range.Rows.Cells[8, 3].value) + 1; i++)
                    {
                        if (CheckPrimeNumber(x1Range.Rows.Cells[i, 2].Text, x1Range.Rows.Cells[i, 3].Text) == x1Range.Rows.Cells[i, 4].Text)
                        {
                            x1Range.Rows.Cells[i, 5].value = "PASS";
                            x1Range.Rows.Cells[i, 6].value = CheckPrimeNumber(x1Range.Rows.Cells[i, 2].Text, x1Range.Rows.Cells[i, 3].Text);
                        }
                        else
                        {
                            x1Range.Rows.Cells[i, 5].value = "FAIL";
                            x1Range.Rows.Cells[i, 6].value = CheckPrimeNumber(x1Range.Rows.Cells[i, 2].Text, x1Range.Rows.Cells[i, 3].Text);
                        }
                    }
                    x1Appl.DisplayAlerts = false;
                    x1WorkBook.SaveAs(string.Format(@"C:\PrimeNumberTestDrivenusingSelenium\TestCase_Result_{0:MM-dd-yyyy_hh-mm-ss-tt}.xlsx", DateTime.Now));
                    x1WorkBook.Close(0, 0, 0);
                    x1Appl.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(x1Appl);
                    Console.WriteLine(string.Format("Test execution completed.Please refer the file TestCase_Result_{0:MM-dd-yyyy_hh-mm-ss-tt}.xlsx", DateTime.Now));
                }
                else
                    Console.WriteLine("TestCase_Input.xlxs file not exists");
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Concat("Exception: ",ex.Data,".Please contact admin"));
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        static string CheckPrimeNumber(string startNumber, string endNumber)
        {
            if (Regex.IsMatch(startNumber, @"^[0-9]+$") && Regex.IsMatch(endNumber, @"^[0-9]+$"))
            {
                PrimeNumber obj = new PrimeNumber();
                List<int> result = obj.generate(Convert.ToInt32(startNumber), Convert.ToInt32(endNumber));
                if (result.Count == 0)
                    return "No Prime Numbers";
                else
                    return string.Join(",", result);
            }
            else
            {
                return "Invalid input";
            }
        }
    }
}
