using System;
using UnityEngine;

namespace Voxalis.Toolkit.Mathematics
{
    /// <summary>
    /// Vector3i.
    /// </summary>
    [Serializable]
    public struct Vector3i : IEquatable<Vector3i>
    {
        #region Attributes

        /// <summary>
        /// The x.
        /// </summary>
        [SerializeField] public int X;

        /// <summary>
        /// The y.
        /// </summary>
        [SerializeField] public int Y;

        /// <summary>
        /// The z.
        /// </summary>
        [SerializeField] public int Z;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="v">V.</param>
        public Vector3i(Vector3i v) : this(v.X, v.Y, v.Z)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="value">Value.</param>
        public Vector3i(int value) : this(value, value, value)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public Vector3i(float x, float y, float z)
        {
            X = Mathf.CeilToInt(x);
            Y = Mathf.CeilToInt(y);
            Z = Mathf.CeilToInt(z);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="direction">Direction.</param>
        public Vector3i(Direction direction)
        {
            X = Y = Z = 0;

            switch (direction)
            {
                case Direction.Left: X = -1; break;
                case Direction.Right: X = 1; break;
                case Direction.Top: Y = 1; break;
                case Direction.Bottom: Y = -1; break;
                case Direction.Front: Z = 1; break;
                case Direction.Back: Z = -1; break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="v">V.</param>
        public Vector3i(Vector3 v) : this(v.x, v.y, v.z)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> struct.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="rows">Rows.</param>
        public Vector3i(int index, Vector3i rows)
        {
            Z = index / (rows.X * rows.Y);
            Y = (index - Z * rows.X * rows.Y) / rows.X;
            X = index - rows.X * (Y + rows.Y * Z);
        }

        #endregion

        #region Copy & clone

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>The clone.</returns>
        public Vector3i Clone() => new Vector3i(this);

        /// <summary>
        /// Copy the specified v.
        /// </summary>
        /// <param name="v">V.</param>
        public void Copy(Vector3i v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        #endregion

        #region Set

        /// <summary>
        /// Sets the x.
        /// </summary>
        /// <returns>The x.</returns>
        /// <param name="value">Value.</param>
        public Vector3i SetX(int value)
        {
            X = value;
            return this;
        }

        /// <summary>
        /// Sets the y.
        /// </summary>
        /// <returns>The y.</returns>
        /// <param name="value">Value.</param>
        public Vector3i SetY(int value)
        {
            Y = value;
            return this;
        }

        /// <summary>
        /// Sets the z.
        /// </summary>
        /// <returns>The z.</returns>
        /// <param name="value">Value.</param>
        public Vector3i SetZ(int value)
        {
            Z = value;
            return this;
        }

        #endregion

        #region Count

        /// <summary>
        /// Count this instance.
        /// </summary>
        /// <returns>The count.</returns>
        public int Count => X * Y * Z;

        #endregion

        #region Contains

        /// <summary>
        /// Contains the specified x, y and z.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        public bool Contains(int x, int y, int z)
        => x >= 0 && x < X && y >= 0 && y < Y && z >= 0 && z < Z;

        /// <summary>
        /// Contains the specified v.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="v">V.</param>
        public bool Contains(Vector3i v)
        => Contains(v.X, v.Y, v.Z);

        #endregion

        #region Equals

        /// <summary>
        /// Equals the specified v1 and v2.
        /// </summary>
        /// <returns>The equals.</returns>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static bool Equals(Vector3i v1, Vector3i v2)
        => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static bool operator ==(Vector3i v1, Vector3i v2)
        => Equals(v1, v2);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static bool operator !=(Vector3i v1, Vector3i v2)
        => !Equals(v1, v2);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        => obj is Vector3i && Equals((Vector3i)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Voxalis.Toolkit.Mathematics.Vector3i"/> is equal to the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.
        /// </summary>
        /// <param name="coord">The <see cref="Voxalis.Toolkit.Mathematics.Vector3i"/> to compare with the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Voxalis.Toolkit.Mathematics.Vector3i"/> is equal to the current
        /// <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Vector3i coord)
        => Equals(this, coord);

        /// <summary>
        /// Serves as a hash function for a <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        => X.GetHashCode() ^ Y.GetHashCode() * 27644437 ^ Z.GetHashCode() * 1073676287;

        #endregion

        #region Sum

        /// <summary>
        /// Sum the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Sum(Vector3i v1, Vector3i v2)
        => new Vector3i(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator +(Vector3i v1, Vector3i v2)
        => Sum(v1, v2);

        /// <summary>
        /// Sum the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Sum(Vector3i v1, int v2)
        => new Vector3i(v1.X + v2, v1.Y + v2, v1.Z + v2);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator +(Vector3i v1, int v2)
        => Sum(v1, v2);

        /// <summary>
        /// Sum the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Sum(Vector3i v1, Vector3 v2)
        => Sum(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator +(Vector3i v1, Vector3 v2)
        => Sum(v1, v2);

        /// <summary>
        /// Sum the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Sum(Vector3i v1, Direction v2)
        => Sum(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator +(Vector3i v1, Direction v2)
        => Sum(v1, v2);

        #endregion

        #region Substract

        /// <summary>
        /// Substract the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Substract(Vector3i v1, Vector3i v2)
        => new Vector3i(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator -(Vector3i v1, Vector3i v2)
        => Substract(v1, v2);

        /// <summary>
        /// Substract the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Substract(Vector3i v1, int v2)
        => new Vector3i(v1.X - v2, v1.Y - v2, v1.Z - v2);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator -(Vector3i v1, int v2)
        => Substract(v1, v2);

        /// <summary>
        /// Substract the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Substract(Vector3i v1, Vector3 v2)
        => Substract(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator -(Vector3i v1, Vector3 v2)
        => Substract(v1, v2);

        /// <summary>
        /// Substract the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Substract(Vector3i v1, Direction v2)
        => Substract(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator -(Vector3i v1, Direction v2)
        => Substract(v1, v2);

        #endregion

        #region Multiply

        /// <summary>
        /// Multiply the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Multiply(Vector3i v1, Vector3i v2)
        => new Vector3i(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator *(Vector3i v1, Vector3i v2)
        => Multiply(v1, v2);

        /// <summary>
        /// Multiply the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Multiply(Vector3i v1, int v2)
        => new Vector3i(v1.X * v2, v1.Y * v2, v1.Z * v2);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator *(Vector3i v1, int v2)
        => Multiply(v1, v2);

        /// <summary>
        /// Multiply the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Multiply(Vector3i v1, Vector3 v2)
        => Multiply(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator *(Vector3i v1, Vector3 v2)
        => Multiply(v1, v2);

        /// <summary>
        /// Multiply the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Multiply(Vector3i v1, Direction v2)
        => Multiply(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator *(Vector3i v1, Direction v2)
        => Multiply(v1, v2);

        #endregion

        #region Divide

        /// <summary>
        /// Divide the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Divide(Vector3i v1, Vector3i v2)
        => new Vector3i(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator /(Vector3i v1, Vector3i v2)
        => Divide(v1, v2);

        /// <summary>
        /// Divide the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Divide(Vector3i v1, int v2)
        => new Vector3i(v1.X / v2, v1.Y / v2, v1.Z / v2);

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator /(Vector3i v1, int v2)
        => Divide(v1, v2);

        /// <summary>
        /// Divide the specified v1 and v2.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i Divide(Vector3i v1, Vector3 v2)
        => Divide(v1, new Vector3i(v2));

        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static Vector3i operator /(Vector3i v1, Vector3 v2)
        => Divide(v1, v2);

        #endregion

        #region Modulo

        /// <summary>
        /// Modulo the specified coord and value.
        /// </summary>
        /// <param name="coord">Coordinate.</param>
        /// <param name="value">Value.</param>
        public static Vector3i Modulo(Vector3i coord, int value)
        => new Vector3i(
            (coord.X % value + value) % value,
            (coord.Y % value + value) % value,
            (coord.Z % value + value) % value
        );

        /// <summary>
        /// Modulo the specified coord and other.
        /// </summary>
        /// <param name="coord">Coordinate.</param>
        /// <param name="other">Other.</param>
        public static Vector3i Modulo(Vector3i coord, Vector3i other)
        => new Vector3i(
            (coord.X % other.X + other.X) % other.X,
            (coord.Y % other.Y + other.Y) % other.Y,
            (coord.Z % other.Z + other.Z) % other.Z
        );

        /// <param name="coord">Coordinate.</param>
        /// <param name="value">Value.</param>
        public static Vector3i operator %(Vector3i coord, int value)
        => Modulo(coord, value);

        /// <summary>
        /// Modulo the specified coord, value and direction.
        /// </summary>
        /// <param name="coord">Coordinate.</param>
        /// <param name="value">Value.</param>
        /// <param name="direction">Direction.</param>
        public static Vector3i Modulo(Vector3i coord, int value, Direction direction)
        {
            var x = coord.X;
            var y = coord.Y;
            var z = coord.Z;

            switch (direction)
            {
                case Direction.Right:
                case Direction.Left: x = (x % value + value) % value; break;
                case Direction.Top:
                case Direction.Bottom: y = (y % value + value) % value; break;
                case Direction.Front:
                case Direction.Back: z = (z % value + value) % value; break;
            }

            return new Vector3i(x, y, z);
        }

        /// <summary>
        /// Modulo the specified coord, value and direction.
        /// </summary>
        /// <param name="coord">Coordinate.</param>
        /// <param name="value">Value.</param>
        /// <param name="direction">Direction.</param>
        public static Vector3i Modulo(Vector3i coord, Vector3i value, Direction direction)
        {
            var x = coord.X;
            var y = coord.Y;
            var z = coord.Z;

            switch (direction)
            {
                case Direction.Right:
                case Direction.Left: x = (x % value.X + value.X) % value.X; break;
                case Direction.Top:
                case Direction.Bottom: y = (y % value.Y + value.Y) % value.Y; break;
                case Direction.Front:
                case Direction.Back: z = (z % value.Z + value.Z) % value.Z; break;
            }

            return new Vector3i(x, y, z);
        }

        /// <summary>
        /// Modulo the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public Vector3i Modulo(int value)
        => Modulo(this, value);

        /// <summary>
        /// Modulo the specified coord.
        /// </summary>
        /// <param name="coord">Coordinate.</param>
        public Vector3i Modulo(Vector3i coord)
        => Modulo(this, coord);

        /// <summary>
        /// Modulo the specified value and direction.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="direction">Direction.</param>
        public Vector3i Modulo(int value, Direction direction)
        => Modulo(this, value, direction);

        /// <summary>
        /// Modulo the specified value and direction.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="direction">Direction.</param>
        public Vector3i Modulo(Vector3i value, Direction direction)
        => Modulo(this, value, direction);

        #endregion

        #region Distance

        /// <summary>
        /// Distance the specified v1 and v2.
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        public static float Distance(Vector3i v1, Vector3i v2)
        => Vector3.Distance(v1.ToVector3(), v2.ToVector3());

        /// <summary>
        /// Distance the specified other.
        /// </summary>
        /// <param name="other">Other.</param>
        public float Distance(Vector3i other)
        => Distance(this, other);

        #endregion

        #region Export

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Voxalis.Toolkit.Mathematics.Vector3i"/>.</returns>
        public override string ToString()
        => X + " " + Y + " " + Z;

        /// <summary>
        /// Tos the vector3.
        /// </summary>
        /// <returns>The vector3.</returns>
        public Vector3 ToVector3()
        => new Vector3(X, Y, Z);

        /// <summary>
        /// Tos the index.
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="coord">Coordinate.</param>
        /// <param name="rows">Rows.</param>
        public static int ToIndex(Vector3i coord, Vector3i rows)
        => coord.X + rows.X * (coord.Y + rows.Y * coord.Z);

        /// <summary>
        /// Tos the index.
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        /// <param name="w">The width.</param>
        /// <param name="h">The height.</param>
        public static int ToIndex(int x, int y, int z, int w, int h)
        => x + w * (y + h * z);

        /// <summary>
        /// Tos the index.
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="rows">Rows.</param>
        public int ToIndex(Vector3i rows)
        => ToIndex(this, rows);

        /// <summary>
        /// Tos the array.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="vec">Vec.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[] ToArray<T>(Vector3i vec)
        => new T[vec.Count];

        /// <summary>
        /// Tos the array.
        /// </summary>
        /// <returns>The array.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T[] ToArray<T>()
        => ToArray<T>(this);

        /// <summary>
        /// Tos the array3.
        /// </summary>
        /// <returns>The array3.</returns>
        /// <param name="vec">Vec.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[,,] ToArray3<T>(Vector3i vec)
        => new T[vec.X, vec.Y, vec.Z];

        /// <summary>
        /// Tos the array3.
        /// </summary>
        /// <returns>The array3.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T[,,] ToArray3<T>()
        => ToArray3<T>(this);

        /// <summary>
        /// Tos the array jagged.
        /// </summary>
        /// <returns>The array jagged.</returns>
        /// <param name="vec">Vec.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[][][] ToArrayJagged<T>(Vector3i vec)
        {
            var array = new T[vec.X][][];

            for (var i = 0; i < vec.X; i++)
            {
                array[i] = new T[vec.Y][];

                for (var j = 0; j < vec.Y; j++)
                {
                    array[i][j] = new T[vec.Z];
                }
            }

            return array;
        }

        /// <summary>
        /// Tos the array jagged.
        /// </summary>
        /// <returns>The array jagged.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T[][][] ToArrayJagged<T>()
        => ToArrayJagged<T>(this);

        #endregion
    }
}
