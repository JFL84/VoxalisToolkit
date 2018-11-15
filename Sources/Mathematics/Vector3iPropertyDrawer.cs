#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Voxalis.Toolkit.Mathematics
{
    /// <summary>
    /// Vector3i property drawer.
    /// </summary>
    [CustomPropertyDrawer(typeof(Vector3i))]
    internal class Vector3iPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Ons the GUI.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <param name="property">Property.</param>
        /// <param name="label">Label.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            EditorGUI.indentLevel = 0;

            EditorGUIUtility.labelWidth = 13f;

            var width = (position.width / 3);

            Rect xRect = new Rect(position.x, position.y, width - 2, position.height);
            Rect yRect = new Rect(position.x + width, position.y, width - 2, position.height);
            Rect zRect = new Rect(position.x + (width * 2), position.y, width, position.height);

            EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), new GUIContent("X"));
            EditorGUI.PropertyField(yRect, property.FindPropertyRelative("Y"), new GUIContent("Y"));
            EditorGUI.PropertyField(zRect, property.FindPropertyRelative("Z"), new GUIContent("Z"));

            EditorGUI.EndProperty();
        }
    }
}

#endif
