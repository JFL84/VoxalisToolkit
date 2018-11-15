#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Voxalis.Toolkit.EditorHelpers
{
    /// <summary>
    /// Read only property drawer.
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnly))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Gets the height of the property.
        /// </summary>
        /// <returns>The property height.</returns>
        /// <param name="property">Property.</param>
        /// <param name="label">Label.</param>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        => EditorGUI.GetPropertyHeight(property, label, true);

        /// <summary>
        /// Ons the GUI.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <param name="property">Property.</param>
        /// <param name="label">Label.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}

#endif