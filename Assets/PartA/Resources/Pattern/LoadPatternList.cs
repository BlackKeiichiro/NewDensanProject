using UnityEngine;
using System;
using System.IO;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


public class LoadPatternList : ScriptableObject{
	public int [][][] data;
	public string checksign = "K";
	string path = "jar:file://" + Application.dataPath + "/Assets/PartA/Resources/Pattern/patternlist.xlsx";

	private LoadPatternList(){
		using (FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read))
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
						}
					}	
					rowelements[rowindex] = cellelements;
				}
				sheetelements[sheetindex] = rowelements;
			}
			data = sheetelements;
		}
		if(data.Length > 0){
			checksign = "No";
		}
	}

}