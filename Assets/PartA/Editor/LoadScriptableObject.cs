using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class LoadScriptableObject : MonoBehaviour{
	// Use this for initializationx
	[MenuItem("Assets/LoadCreateScriptableObject")]
	public static void CreateLoadScriptableObject(){
		string filepath = AssetDatabase.GetAssetPath(Selection.activeObject);
		string createpath = AssetDatabase.GenerateUniqueAssetPath("Assets/PartA/Resources/Pattern/" + Selection.activeObject.name +".asset");
		ExcelData exceldata = ScriptableObject.CreateInstance<ExcelData>();
		//List<_Row> _sheet_list = new List<_Row>();
		using (FileStream fs = new FileStream(filepath,FileMode.Open,FileAccess.Read))
		{
			IWorkbook workbook = new XSSFWorkbook(fs);
			int sheetnumber = workbook.NumberOfSheets;
			int [][][] sheetelements = new int[sheetnumber][][];
			exceldata.data = new int[sheetnumber][][];
			for(int sheetindex = 0;sheetindex < sheetnumber;++sheetindex){
				ISheet _isheet = workbook.GetSheetAt(sheetindex);
				int lastrownum = _isheet.LastRowNum;
				int [][] rowelements = new int[lastrownum + 1][];
				_Row localrow = new _Row();
				for(int rowindex = _isheet.FirstRowNum;rowindex <= lastrownum;++rowindex){
					IRow row = _isheet.GetRow(rowindex);
					if(row == null)continue;
					int lastcellnum = row.LastCellNum;
					int[] cellelements = new int[lastcellnum + 1];
					_Cell localcell = new _Cell();
					for(int cellindex = row.FirstCellNum;cellindex < lastcellnum;++cellindex){
						ICell cell = row.GetCell(cellindex);
						if(cell != null){
							//cellelements[cellindex] = Convert.ToInt32(cell.ToString());
							localcell.cell[cellindex] = Convert.ToInt32(cell.ToString());
						}
					}
					localrow.row.Add(localcell);
					rowelements[rowindex] = cellelements;
				}
				exceldata.sheet.Add(localrow);
				sheetelements[sheetindex] = rowelements;
			}

			//exceldata.data.CopyTo(sheetelements,0);
			//exceldata.data = (int[][][])sheetelements.Clone();
			foreach(_Row cells in  exceldata.sheet){
				foreach(_Cell test in cells.row){
					for(int i = 0;i < 5;i++)
					Debug.Log(test.cell[i]);
				}
			}
			//exceldata.data = sheetelements;
			exceldata.check = "Exist";
			exceldata.hideFlags = HideFlags.NotEditable;
			EditorUtility.SetDirty(exceldata);
			AssetDatabase.CreateAsset(exceldata,createpath);
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
		}
	}
}