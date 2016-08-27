using UnityEngine;
using UnityEditor;
using System.Collections;

public class HierarchySortaAlpha : BaseHierarchySort
{
	public override int Compare(GameObject lhs, GameObject rhs)
	{
		if(lhs == rhs) return 0;		//if same, exit
		if(lhs == null) return -1;      //if null, exit
		if (rhs == null) return 1;      //if null, exit

		return EditorUtility.NaturalCompare(lhs.name, rhs.name);
	}
}
