using UnityEngine;
using Voxalis.Toolkit.Mathematics;

namespace Voxalis.Toolkit.Rendering
{
    /// <summary>
    /// Cube mesh.
    /// </summary>
    public static class CubeMesh
    {
        /// <summary>
        /// The vertices.
        /// </summary>
        private static readonly Vector3[] _Vertices = {
            new Vector3( 0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f,-0.5f, 0.5f),
            new Vector3( 0.5f,-0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f,-0.5f),
            new Vector3( 0.5f, 0.5f,-0.5f),
            new Vector3( 0.5f,-0.5f,-0.5f),
            new Vector3(-0.5f,-0.5f,-0.5f),
        };

        /// <summary>
        /// The triangles.
        /// </summary>
        private static readonly int[][] _Triangles = {
            new int[] { 0, 1, 2, 3 },
            new int[] { 5, 0, 3, 6 },
            new int[] { 4, 5, 6, 7 },
            new int[] { 1, 4, 7, 2 },
            new int[] { 5, 4 ,1, 0 },
            new int[] { 3, 2, 7, 6 },
        };

        /// <summary>
        /// Adds to mesh data.
        /// </summary>
        /// <param name="meshData">Mesh data.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        public static void AddToMeshData(MeshData meshData, Direction direction, Vector3 center, float size)
        {
            var index = (int)direction;
            var count = meshData.Count;

            meshData.Vertices.AddRange(new Vector3[] {
                (_Vertices[_Triangles[index][0]] * size) + center,
                (_Vertices[_Triangles[index][1]] * size) + center,
                (_Vertices[_Triangles[index][2]] * size) + center,
                (_Vertices[_Triangles[index][3]] * size) + center,
            });

            meshData.Triangles.AddRange(new int[] {
                count + 0, count + 1, count + 2, count + 0, count + 2, count + 3,
            });

            meshData.UV.AddRange(new Vector2[]
            {
                new Vector2(0, 0) * size,
                new Vector2(1, 0) * size,
                new Vector2(1, 1) * size,
                new Vector2(0, 1) * size,
            });
        }

        /// <summary>
        /// Adds to mesh data.
        /// </summary>
        /// <param name="meshData">Mesh data.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        /// <param name="color">Color.</param>
        public static void AddToMeshData(MeshData meshData, Direction direction, Vector3 center, float size, Color color)
        {
            var index = (int)direction;
            var count = meshData.Count;

            meshData.Vertices.AddRange(new Vector3[] {
                (_Vertices[_Triangles[index][0]] * size) + center,
                (_Vertices[_Triangles[index][1]] * size) + center,
                (_Vertices[_Triangles[index][2]] * size) + center,
                (_Vertices[_Triangles[index][3]] * size) + center,
            });

            meshData.Triangles.AddRange(new int[] {
                count + 0, count + 1, count + 2, count + 0, count + 2, count + 3,
            });

            meshData.Colors.AddRange(new Color[] { color, color, color, color });
        }

        /// <summary>
        /// Adds to mesh data.
        /// </summary>
        /// <param name="meshData">Mesh data.</param>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        public static void AddToMeshData(MeshData meshData, Vector3 center, float size)
        {
            foreach (var dir in DirectionHelper.Cross)
            {
                AddToMeshData(meshData, dir, center, size);
            }
        }

        /// <summary>
        /// Adds to mesh data.
        /// </summary>
        /// <param name="meshData">Mesh data.</param>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        /// <param name="color">Color.</param>
        public static void AddToMeshData(MeshData meshData, Vector3 center, float size, Color color)
        {
            foreach (var dir in DirectionHelper.Cross)
            {
                AddToMeshData(meshData, dir, center, size, color);
            }
        }

        /// <summary>
        /// To mesh data.
        /// </summary>
        /// <returns>The mesh data.</returns>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        public static MeshData ToMeshData(Vector3 center, float size)
        {
            var meshData = new MeshData();
            AddToMeshData(meshData, center, size);
            return meshData;
        }

        /// <summary>
        /// To mesh data.
        /// </summary>
        /// <returns>The mesh data.</returns>
        /// <param name="center">Center.</param>
        /// <param name="size">Size.</param>
        /// <param name="color">Color.</param>
        public static MeshData ToMeshData(Vector3 center, float size, Color color)
        {
            var meshData = new MeshData();
            AddToMeshData(meshData, center, size, color);
            return meshData;
        }
    }
}
