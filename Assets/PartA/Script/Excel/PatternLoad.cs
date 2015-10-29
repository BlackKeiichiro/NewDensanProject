using UnityEngine;
using System;
using System.IO;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Excel{
public static class PatternLoad{
		public static int[][][] ReadExcelPattern(string filepath){
			using (FileStream fs = new FileStream(filepath,FileMode.Open,FileAccess.Read))
			{
				IWorkbook workbook = new XSSFWorkbook(fs);
				int sheetnumber = workbook.NumberOfSheets;
				int [][][] sheetelements = new int[sheetnumber][][];
				for(int sheetindex = 0;sheetindex < sheetnumber;++sheetindex){
					ISheet _isheet = workbook.GetSheetAt(sheetindex);
					int lastrownum = _isheet.LastRowNum;
					int [][] rowelements = new int[lastrownum+1][];
					for(int rowindex = _isheet.FirstRowNum;rowindex <= lastrownum;++rowindex){
						IRow row = _isheet.GetRow(rowindex);
						if(row == null)continue;
						int lastcellnum = row.LastCellNum;
						int[] cellelements = new int[lastcellnum+1];
						for(int cellindex = row.FirstCellNum;cellindex < lastcellnum;++cellindex){
							ICell cell = row.GetCell(cellindex);
							if(cell != null){
								cellelements[cellindex] = Convert.ToInt32(cell.ToString());
								Debug.Log(cellelements[cellindex]);
							}
						}	
						rowelements[rowindex] = cellelements;
					}
					sheetelements[sheetindex] = rowelements;
				}
				return sheetelements;
			}
		}
	}
}