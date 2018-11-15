using System;
using UnityEngine;

namespace Voxalis.Toolkit.EditorHelpers
{
    /// <summary>
    /// String selector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class StringSelector : PropertyAttribute
    {
        /// <summary>
        /// Get string list.
        /// </summary>
        public delegate string[] GetStringList();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.EditorHelpers.StringSelector"/> class.
        /// </summary>
        /// <param name="list">List.</param>
        public StringSelector(params string[] list)
        {
            List = list;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.EditorHelpers.StringSelector"/> class.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="methodName">Method name.</param>
        public StringSelector(Type type, string methodName)
        {
            var method = type.GetMethod(methodName);
            if (method != null)
                List = method.Invoke(null, null) as string[];
            else
                Debug.LogError("NO SUCH METHOD " + methodName + " FOR " + type);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        public string[] List
        {
            get;
            private set;
        }
    }

}
