using Eos.Editor.Attribute;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace Eos.Editor.Drawer
{
    [CustomPropertyDrawer(typeof(PrefabAttribute))]
    public class PrefabDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 確保屬性是一個 GameObject
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue,
                    typeof(GameObject), false);
                EditorGUI.EndProperty();

                // 檢查是否為 Prefab
                if (property.objectReferenceValue != null)
                {
                    GameObject gameObject = property.objectReferenceValue as GameObject;
                    if (PrefabUtility.GetPrefabAssetType(gameObject) != PrefabAssetType.NotAPrefab)
                    {
                        // 是 Prefab，允許保留
                    }
                    else
                    {
                        // 不是 Prefab，清除選擇
                        property.objectReferenceValue = null;
                    }
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use PrefabAttribute with GameObject.");
            }
        }
    }
}

#endif