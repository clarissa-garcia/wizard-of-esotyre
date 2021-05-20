using UnityEditor;

[CustomPropertyDrawer(typeof(RecipeComponent), true)]
public class RecipePolymorphicComponentDrawer : APolymorphicPropertyDrawer<RecipeComponent, BaseRecipeComponentDrawer> {
    protected override void DoInitPropertyMappings()
    {
        // Register all the child drawers
        RegisterPropertyDrawer(typeof(ItemComponent), new ItemComponentDrawer());
        RegisterPropertyDrawer(typeof(StirComponent), new StirComponentDrawer());
        RegisterPropertyDrawer(typeof(EnchantmentComponent), new EnchantmentComponentDrawer());
    }
}
 
// public abstract class BaseRecipeComponentDrawer : PropertyDrawer, IPolymorphicPropertyDrawerInstance<RecipeComponent>
// {
//     private const string ANIMAL_PROPERTY_NAME = nameof(AAnimal.Name);
 
//     protected static readonly float SINGLE_PROPERTY_HEIGHT = EditorGUIUtility.singleLineHeight;
 
//     public void OnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
//     {
//         Rect nameRect = new Rect(position.xMin, position.yMin, position.width, SINGLE_PROPERTY_HEIGHT);
 
//         // Again being lazy with not caching this for simplicity of the example :)
//         GUIContent animalType = new GUIContent(propertyObj.targetObject.GetType().Name);
 
//         SerializedProperty nameProperty = propertyObj.FindProperty(ANIMAL_PROPERTY_NAME);
//         EditorGUI.PropertyField(nameRect, nameProperty, animalType, true);
 
//         float remainingHeight = position.height - SINGLE_PROPERTY_HEIGHT;
//         Rect remainingRect = new Rect(position.xMin, nameRect.yMax, position.width, remainingHeight);
//         DoOnGUI(remainingRect, propertyObj, label);
//     }
 
//     protected abstract void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label);
 
//     public virtual float GetPropertyHeight(SerializedObject propertyObj, GUIContent label)
//     {
//         // I'm being lazy with not doing this properly per PropertyDrawer override ;)
//         return SINGLE_PROPERTY_HEIGHT * 2f;
//     }
// }
 
// public class LionPropertyDrawer : BaseAnimalPropertyDrawer
// {
//     private const string NUM_TIMES_ROARED_PROPERTY_NAME = nameof(Lion.NumRoars);
 
//     protected override void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
//     {
//         Rect nameRect = new Rect(position.xMin, position.yMin, position.width, SINGLE_PROPERTY_HEIGHT);
//         SerializedProperty numTimesRoaredProperty = propertyObj.FindProperty(NUM_TIMES_ROARED_PROPERTY_NAME);
//         EditorGUI.PropertyField(nameRect, numTimesRoaredProperty, true);
//     }
// }
 
// public class ElephantPropertyDrawer : BaseAnimalPropertyDrawer
// {
//     private const string IS_SCARED_OF_MICE_PROPERTY_NAME = nameof(Elephant.IsScaredOfMice);
 
//     protected override void DoOnGUI(Rect position, SerializedObject propertyObj, GUIContent label)
//     {
//         Rect nameRect = new Rect(position.xMin, position.yMin, position.width, SINGLE_PROPERTY_HEIGHT);
//         SerializedProperty isScaredOfMiceProperty = propertyObj.FindProperty(IS_SCARED_OF_MICE_PROPERTY_NAME);
//         EditorGUI.PropertyField(nameRect, isScaredOfMiceProperty, true);
//     }
// }