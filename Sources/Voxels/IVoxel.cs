using System;

namespace Voxalis.Toolkit.Voxels
{
    /// <summary>
    /// Voxel.
    /// </summary>
    public interface IVoxel : IEquatable<IVoxel>
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        uint Type { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Voxalis.Toolkit.Voxels.IVoxel"/> is emtpy.
        /// </summary>
        /// <value><c>true</c> if is emtpy; otherwise, <c>false</c>.</value>
        bool IsEmtpy { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Voxalis.Toolkit.Voxels.IVoxel"/> is filled.
        /// </summary>
        /// <value><c>true</c> if is filled; otherwise, <c>false</c>.</value>
        bool IsFilled { get; }
    }
}
