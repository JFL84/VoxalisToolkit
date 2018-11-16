using Voxalis.Toolkit.Mathematics;

namespace Voxalis.Toolkit.Voxels
{
    public class VoxelBuffer
    {
        public readonly Vector3i Rows;

        public readonly uint[,,] Voxels;

        public VoxelBuffer(Vector3i rows)
        {
            Rows = rows;
            Voxels = Rows.ToArray3<uint>();
        }

        public VoxelBuffer(int rows) : this(new Vector3i(rows))
        { }
    }
}