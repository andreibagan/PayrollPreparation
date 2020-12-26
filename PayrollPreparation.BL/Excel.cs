using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollPreparation.BL
{
    public class Excel
    {
        //string path = "";
        //_Application excel = new _Excel.Application();
        //Workbook wb;
        //Worksheet ws;

        //public void DrawBorder(string start, string end)
        //{
        //    Range last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
        //    Range rangeX = ws.get_Range(start, end);
        //    Borders xborders = rangeX.Borders;
        //    xborders.LineStyle = XlLineStyle.xlContinuous;
        //    xborders.Weight = 2d;
        //}

        //public void Merge(string start, string end)
        //{
        //    Range rangeX = ws.get_Range(start, end);
        //    rangeX.Merge();
        //}

        //public Excel(string path, int Sheet)
        //{
        //    this.path = path;
        //    wb = excel.Workbooks.Open(path);
        //    ws = wb.Worksheets[Sheet];
        //}

        //public string ReadCell(int i, int j)
        //{
        //    if (ws.Cells[i, j].Value2 != null)
        //    {
        //        return ws.Cells[i, j].Value;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        //public void WriteToCell(int i, int j, string s)
        //{
        //    ws.Cells[i, j].Value2 = s;
        //}

        //public void DrawCell(int i, int j, System.Drawing.Color color)
        //{
        //    ws.Cells[i, j].Interior.Color = color;
        //}

        //public void AddFormula(int i, int j)
        //{
        //    ws.Cells[i, j].Formula = "=SUM(F" + i + ":Q" + i + ")";
        //}



        //public void Save()
        //{
        //    wb.Save();
        //}

        //public void SaveAs(string path)
        //{
        //    wb.SaveAs(path);
        //}

        //public void Close()
        //{
        //    wb.Close();
        //}
    }
}
