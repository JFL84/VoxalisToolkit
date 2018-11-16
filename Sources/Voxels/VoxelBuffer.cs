using Voxalis.Toolkit.Mathematics;

namespace Voxalis.Toolkit.Voxels
{
    /// <summary>
    /// Voxel buffer.
    /// </summary>
    public class VoxelBuffer
    {
        /// <summary>
        /// The rows.
        /// </summary>
        public readonly Vector3i Rows;

        /// <summary>
        /// The voxels.
        /// </summary>
        public readonly IVoxel[,,] Voxels;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Voxels.VoxelBuffer"/> class.
        /// </summary>
        /// <param name="rows">Rows.</param>
        public VoxelBuffer(Vector3i rows)
        {
            Rows = rows;
            Voxels = Rows.ToArray3<IVoxel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Voxels.VoxelBuffer"/> class.
        /// </summary>
        /// <param name="rows">Rows.</param>
        public VoxelBuffer(int rows) : this(new Vector3i(rows))
        { }
    }
}