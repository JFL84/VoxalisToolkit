using System.Collections.Generic;
using UnityEngine;

namespace Voxalis.Toolkit.Rendering
{
    /// <summary>
    /// Mesh data.
    /// </summary>
    public class MeshData
    {
        #region Attributes

        /// <summary>
        /// The vertices.
        /// </summary>
        public List<Vector3> Vertices = new List<Vector3>();

        /// <summary>
        /// The triangles.
        /// </summary>
        public List<int> Triangles = new List<int>();

        /// <summary>
        /// The uv.
        /// </summary>
        public List<Vector2> UV = new List<Vector2>();

        /// <summary>
        /// The colors.
        /// </summary>
        public List<Color> Colors = new List<Color>();

        #endregion

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => Vertices.Count;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Voxalis.Toolkit.Rendering.MeshData"/> is empty.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty => Vertices.Count == 0;

        /// <summary>
        /// Clear this instance.
        /// </summary>
        /// <returns>The clear.</returns>
        public MeshData Clear()
        {
            Vertices.Clear();
            Triangles.Clear();
            UV.Clear();
            Colors.Clear();
            return this;
        }

        /// <summary>
        /// Copy the specified meshData.
        /// </summary>
        /// <returns>The copy.</returns>
        /// <param name="meshData">Mesh data.</param>
        public MeshData Copy(MeshData meshData)
        {
            Clear();
            Vertices.AddRange(meshData.Vertices);
            Triangles.AddRange(meshData.Triangles);
            UV.AddRange(meshData.UV);
            Colors.AddRange(meshData.Colors);
            return this;
        }

        /// <summary>
        /// Merge the specified meshData.
        /// </summary>
        /// <returns>The merge.</returns>
        /// <param name="meshData">Mesh data.</param>
        public MeshData Merge(MeshData meshData)
        {
            var offset = Vertices.Count;

            for (int i = 0, imax = meshData.Triangles.Count; i < imax; i++)
            {
                Triangles.Add(offset + meshData.Triangles[i]);
            }

            Vertices.AddRange(meshData.Vertices);
            UV.AddRange(meshData.UV);
            Colors.AddRange(meshData.Colors);

            return this;
        }

        /// <summary>
        /// Tos the mesh.
        /// </summary>
        /// <returns>The mesh.</returns>
        public Mesh ToMesh()
        {
            Mesh mesh = new Mesh
            {
                vertices = Vertices.ToArray(),
                triangles = Triangles.ToArray(),
                uv = UV.ToArray(),
                colors = Colors.ToArray()
            };
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            return mesh;
        }

        /// <summary>
        /// To game object.
        /// </summary>
        /// <returns>The game object.</returns>
        /// <param name="name">Name.</param>
        /// <param name="parent">Parent.</param>
        /// <param name="material">Material.</param>
        public GameObject ToGameObject(string name, Transform parent = null, Material material = null)
        {
            var go = new GameObject(name);
            go.transform.parent = parent;
            go.AddComponent<MeshFilter>().mesh = ToMesh();
            go.AddComponent<MeshRenderer>().material = material;
            return go;
        }

        /// <summary>
        /// To game object with mesh collider.
        /// </summary>
        /// <returns>The game object with mesh collider.</returns>
        /// <param name="name">Name.</param>
        /// <param name="parent">Parent.</param>
        /// <param name="material">Material.</param>
        public GameObject ToGameObjectWithMeshCollider(string name, Transform parent = null, Material material = null)
        {
            var go = ToGameObject(name, parent, material);
            var mc = go.AddComponent<MeshCollider>();
            mc.sharedMesh = null;
            mc.sharedMesh = go.GetComponent<MeshFilter>().mesh;
            return go;
        }
    }
}
