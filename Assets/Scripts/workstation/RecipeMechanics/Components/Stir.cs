using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public enum StirDirection{
    CLOCKWISE,
    COUNTERCLOCKWISE, 
}

[System.Serializable]
[CreateAssetMenu(fileName = "Stir", menuName = "Recipe System/Component/Stir", order = 0)]
public class Stir : ScriptableObject, RecipeComponent
{
    public StirDirection direction = StirDirection.CLOCKWISE;

    public int count = 1; 

    public RecipeComponent ShowComponent()
    {
        EditorGUILayout.BeginHorizontal();

        direction = (StirDirection)EditorGUILayout.EnumPopup(direction); 

        //count = EditorGUILayout.IntField("Count:", count);

        if(GUILayout.Button("-", GUILayout.Width(20)))
            count--; 
        if(GUILayout.Button("+",  GUILayout.Width(20)))
            count++; 
        if(count < 1) count = 1; 

        EditorGUILayout.EndHorizontal(); 

        return null; 
    }
}
