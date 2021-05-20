using UnityEngine;
using UnityEditor;

public abstract class BaseRecipeComponentDrawer : PropertyDrawer, IPolymorphicPropertyDrawerInstance<RecipeComponent>{
    
    protected static readonly float SINGLE_PROPERTY_HEIGHT = EditorGUIUtility.singleLineHeight;

    protected bool foldout; 
    public void OnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
    {
        Rect nameRect = new Rect(position.xMin, position.yMin, position.width, SINGLE_PROPERTY_HEIGHT);

        GUIContent componentType = new GUIContent(propertyObj.targetObject.GetType().Name);
        SerializedProperty nameProperty = propertyObj.FindProperty("type");
        //EditorGUILayout.LabelField(componentType);
 
        float remainingHeight = position.height - SINGLE_PROPERTY_HEIGHT;
        Rect remainingRect = new Rect(position.xMin, nameRect.yMax, position.width, remainingHeight);
        DoOnGUI(remainingRect, propertyObj, label);
    }
 
    protected abstract void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label);

    public virtual float GetPropertyHeight(SerializedObject propertyObj, GUIContent label)
    {
        return SINGLE_PROPERTY_HEIGHT * 2f;
    }
}