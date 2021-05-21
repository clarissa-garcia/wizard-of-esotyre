using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public enum StirDirection{
    CLOCKWISE,
    COUNTERCLOCKWISE, 
}


public class Stir :  RecipeComponent
{
    public StirDirection direction = StirDirection.CLOCKWISE;

    public int count = 1; 

    public RecipeComponent ShowComponent()
    {
        EditorGUILayout.BeginVertical();
        direction = (StirDirection)EditorGUILayout.EnumPopup(direction); 


        EditorGUILayout.BeginHorizontal();
        count = EditorGUILayout.IntField("Count:", count);
        if(GUILayout.Button("-", GUILayout.Width(20)))
            count--; 
        if(GUILayout.Button("+",  GUILayout.Width(20)))
            count++; 
        if(count < 1) count = 1; 
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical(); 

        return null; 
    }
}
