using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Enchantment", menuName = "wizard-of-esotyre/Enchantment", order = 0)]
public class Enchantment : ScriptableObject, RecipeComponent {
    public string[] syllables;

    private void OnEnable() {
        syllables = new string[3];
    }

    public RecipeComponent ShowComponent(){
        int syllableSize; 

        EditorGUILayout.BeginHorizontal();

        syllableSize = EditorGUILayout.IntField("Size", syllables.Length); // Change Array size

        if(GUILayout.Button("-", GUILayout.Width(20)))
            syllableSize--; 
        if(GUILayout.Button("+",  GUILayout.Width(20)))
            syllableSize++; 

        if(syllableSize < 0) 
            syllableSize = 0; 

        EditorGUILayout.EndHorizontal();

        if(syllableSize != syllables.Length){
            string[] tmp = new string[syllableSize];
            
            for(int i = 0; i < syllableSize && i < syllables.Length; i++){
                tmp[i] = syllables[i];
            }

            syllables = tmp; 
        }

        for(int i = 0; i < syllables.Length; i++){
            syllables[i] = EditorGUILayout.TextField("Syllable " + i + ":",syllables[i]);
        }

        return null; 
    }
}
