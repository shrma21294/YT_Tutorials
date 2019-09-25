using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UIMenus : MonoBehaviour
{
    [MenuItem("UI System/UI Tools/Create UI Group")]
    public static void CreateUIGroup(){
    	GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/UI_GRP.prefab");

    	if(uiGroup)
    	{
    			GameObject createdGroup = (GameObject)Instantiate(uiGroup);
    			createdGroup.name = "UI_GRP";
    	}else
    	{
    		EditorUtility.DisplayDialog("UI Tools Warning", "Cannot find UI group prefab", "OK");
    	}
    }
}
