using UnityEngine;
using UnityEditor;

namespace BreadAndButter
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagDrawer : PropertyDrawer
    {
        //the function that renders the property into the inspector
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            //start drawing this spacific intance of the tag property
            EditorGUI.BeginProperty(_position, _label, _property);

            bool isNotSet = string.IsNullOrEmpty(_property.stringValue);

            _property.stringValue = EditorGUI.TagField(_position, _label, 
                isNotSet ? (_property.serializedObject.targetObject as Component).gameObject.tag : _property.stringValue);

            EditorGUI.EndProperty();
        }

        //get the verticale space a single property will take in the inspector
        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}