#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

namespace Voxalis.Toolkit.EditorHelpers
{
    /// <summary>
    /// String selector property drawer.
    /// </summary>
    [CustomPropertyDrawer(typeof(StringSelector))]
    public class StringSelectorPropertyDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var StringSelector = attribute as StringSelector;
            var list = StringSelector.List;

            if (property.propertyType == SerializedPropertyType.String)
            {
                int index = Mathf.Max(0, Array.IndexOf(list, property.stringValue));
                index = EditorGUI.Popup(position, property.displayName, index, list);
                property.stringValue = list[index]?.Trim().Replace("None", "");
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, list);
            }
            else
            {
                base.OnGUI(position, property, label);
            }
        }
    }
}

#endif
