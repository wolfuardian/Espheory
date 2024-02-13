using UnityEditor;
using UnityEngine;

namespace Eos.Core.Attribute.ReadOnlyAttribute.Editor
{
    /// <summary>
    /// ReadOnly 屬性的自訂繪製器
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var previousGUIState = GUI.enabled;

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = previousGUIState;
        }
    }
}