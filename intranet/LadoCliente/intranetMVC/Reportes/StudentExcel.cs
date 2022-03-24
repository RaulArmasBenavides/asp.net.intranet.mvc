using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using intranetMVC.WCFCliente;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace intranetMVC.Reportes
{
    public class StudentExcel
    {
        int rowIndex = 2;
        ExcelRange cell;
        ExcelFill fill;
        Border border;


        public StudentExcel()
        { }

        public byte[] GenerateExcel(List<Alumno> alumnos)
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("Student.xlsx")))
            {
                excelPackage.Workbook.Properties.Author = "RMAB";
                excelPackage.Workbook.Properties.Title = "Intranet";
                var sheet = excelPackage.Workbook.Worksheets.Add("Student Excel");
                sheet.Name = "Reporte de Alumnos";
                sheet.Column(2).Width = 10;
                sheet.Column(3).Width = 30;
                sheet.Column(4).Width = 20;


                #region Report header 

                sheet.Cells[rowIndex, 2, rowIndex, 4].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "Nombre";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 20;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;

                sheet.Cells[rowIndex, 2, rowIndex, 4].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "Apellido";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 20;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;
                #endregion


                #region  Table header 


                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "#";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Azure);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 3];
                cell.Value = "Nombre";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Azure);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;



                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "Apellido";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Azure);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "DNI";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Azure);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "Usuario";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Azure);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                rowIndex = rowIndex + 1;
                #endregion

                #region   TableBody 
                int serialNumber = 1;
                if (alumnos.Count > 1)
                {

                    foreach (Alumno al in alumnos)
                    {

                        cell = sheet.Cells[rowIndex, 2];
                        cell.Value = serialNumber;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.Azure);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        cell = sheet.Cells[rowIndex, 3];
                        cell.Value = al.NomAlumno;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.Azure);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 4];
                        cell.Value = al.ApePatAlumno;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.Azure);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = al.DNI;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.Azure);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        cell = sheet.Cells[rowIndex, 6];
                        cell.Value = al.CodigoAlu;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.Aqua);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        rowIndex++;
                        serialNumber++;
                    }


                }
                #endregion





                return excelPackage.GetAsByteArray();
            }
        }
    }
}