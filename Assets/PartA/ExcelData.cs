using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class ExcelData : ScriptableObject{
	//public List<_Row> sheet = new List<_Row>();
	public int[][][] data;
	public string check = "Nothing";
	public List<_Row> sheet = new List<_Row>(); 
}
	
[System.Serializable]
public class _Row{
	public List<_Cell> row = new List<_Cell>();
}
[System.Serializable]
public class _Cell{
	public int[] cell = new int[5];
}