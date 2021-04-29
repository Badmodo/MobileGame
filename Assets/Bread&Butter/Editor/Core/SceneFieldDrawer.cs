using UnityEngine;
using UnityEditor;

namespace BreadAndButter
{
    [CustomPropertyDrawer(typeof(SceneFieldsAttribute))]
    public class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            EditorGUI.BeginProperty(_position, _label, _property);

            //load the scene currently in expector
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(_property.stringValue);

            //check if anything has changed in the scene
            EditorGUI.BeginChangeCheck();

            // draw the scene fields as an object field with the set sceneasset type
            var newScene = EditorGUI.ObjectField(_position, _label, oldScene, typeof(SceneAsset), false) as SceneAsset;

            //did anything actully change in the inspector
            if(EditorGUI.EndChangeCheck())
            {
                //  set string value to the path of the scene
                string path = AssetDatabase.GetAssetPath(newScene);
                _property.stringValue = path;
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}
