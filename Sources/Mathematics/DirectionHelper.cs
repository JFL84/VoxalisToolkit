using UnityEngine;

namespace Voxalis.Toolkit.Mathematics
{
    /// <summary>
    /// Direction helper.
    /// </summary>
    public static class DirectionHelper
    {
        /// <summary>
        /// The number of cross directions.
        /// </summary>
        public static readonly int CrossCount = 6;

        /// <summary>
        /// The cross directions.
        /// </summary>
        public static readonly Direction[] Cross =
        {
            Direction.Left,
            Direction.Right,
            Direction.Top,
            Direction.Bottom,
            Direction.Front,
            Direction.Back,
        };

        /// <summary>
        /// The number of flat directions.
        /// </summary>
        public static readonly int FlatCount = 6;

        /// <summary>
        /// The flat directions.
        /// </summary>
        public static readonly Direction[] FlatDirections =
        {
            Direction.Left,
            Direction.Right,
            Direction.Front,
            Direction.Back,
        };

        /// <summary>
        /// Opposite direction.
        /// </summary>
        /// <returns>The direction.</returns>
        /// <param name="direction">Direction.</param>
        public static Direction GetOpposite(Direction direction)
        {
            if (direction == Direction.Front) return Direction.Back;
            if (direction == Direction.Back) return Direction.Front;
            if (direction == Direction.Left) return Direction.Right;
            if (direction == Direction.Right) return Direction.Left;
            if (direction == Direction.Top) return Direction.Bottom;
            return Direction.Top;
        }

        /// <summary>
        /// Tos the vector3.
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="direction">Direction.</param>
        public static Vector3 ToVector3(Direction direction)
        {
            switch (direction)
            {
                case Direction.Front: return Vector3.forward;
                case Direction.Back: return Vector3.back;
                case Direction.Left: return Vector3.left;
                case Direction.Right: return Vector3.right;
                case Direction.Top: return Vector3.up;
                case Direction.Bottom: return Vector3.down;
            }
            return Vector3.zero;
        }
    }
}
