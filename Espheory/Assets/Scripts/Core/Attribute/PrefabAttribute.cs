using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Eos.Core.Attribute
{
#if UNITY_EDITOR

    public class PrefabAttribute : PropertyAttribute
    {
    }
#endif

    [CustomPropertyDrawer(typeof(PrefabAttribute))]
    public class PrefabPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            if (property.objectReferenceValue != null)
            {
                var assetPath = AssetDatabase.GetAssetPath(property.objectReferenceValue);
                if (!string.IsNullOrEmpty(assetPath) && !assetPath.StartsWith("Assets"))
                {
                    property.objectReferenceValue = null;
                }
            }

            EditorGUI.ObjectField(position, property, label);

            EditorGUI.EndProperty();
        }
    }
}