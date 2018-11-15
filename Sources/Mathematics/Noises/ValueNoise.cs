//
// MIT License
// 
// Copyright(c) 2017 Justin Hawkins
//
// https://github.com/Scrawk/Marching-Cubes/tree/master/Assets/ProceduralNoise/Noise
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
using UnityEngine;

namespace Voxalis.Toolkit.Mathematics.Noises
{

    /// <summary>
    /// Simple noise implementation by interpolating random values.
    /// Works same as Perlin noise but uses the values instead of gradients.
    /// Perlin noise uses gradients as it makes better noise but this still
    ///  looks good and might be a little faster.
    /// </summary>
    public class ValueNoise : Noise
    {

        private PermutationTable Perm { get; set; }

        public ValueNoise(int seed, float frequency, float amplitude = 1.0f)
        {

            Frequency = frequency;
            Amplitude = amplitude;
            Offset = Vector3.zero;

            Perm = new PermutationTable(1024, 255, seed);

        }

        /// <summary>
        /// Update the seed.
        /// </summary>
        public override void UpdateSeed(int seed)
        {
            Perm.Build(seed);
        }

        /// <summary>
        /// Sample the noise in 1 dimension.
        /// </summary>
        public override float Sample1D(float x)
        {
            x = (x + Offset.x) * Frequency;

            int ix0;
            float fx0;
            float s, n0, n1;

            ix0 = (int)Mathf.Floor(x);     // Integer part of x
            fx0 = x - ix0;                // Fractional part of x

            s = FADE(fx0);

            n0 = Perm[ix0];
            n1 = Perm[ix0 + 1];

            // rescale from 0 to 255 to -1 to 1.
            float n = LERP(s, n0, n1) * Perm.Inverse;
            n = n * 2.0f - 1.0f;

            return n * Amplitude;
        }

        /// <summary>
        /// Sample the noise in 2 dimensions.
        /// </summary>
        public override float Sample2D(float x, float y)
        {
            x = (x + Offset.x) * Frequency;
            y = (y + Offset.y) * Frequency;

            int ix0, iy0;
            float fx0, fy0, s, t, nx0, nx1, n0, n1;

            ix0 = (int)Mathf.Floor(x);   // Integer part of x
            iy0 = (int)Mathf.Floor(y);   // Integer part of y

            fx0 = x - ix0;              // Fractional part of x
            fy0 = y - iy0;              // Fractional part of y

            t = FADE(fy0);
            s = FADE(fx0);

            nx0 = Perm[ix0, iy0];
            nx1 = Perm[ix0, iy0 + 1];

            n0 = LERP(t, nx0, nx1);

            nx0 = Perm[ix0 + 1, iy0];
            nx1 = Perm[ix0 + 1, iy0 + 1];

            n1 = LERP(t, nx0, nx1);

            // rescale from 0 to 255 to -1 to 1.
            float n = LERP(s, n0, n1) * Perm.Inverse;
            n = n * 2.0f - 1.0f;

            return n * Amplitude;
        }

        /// <summary>
        /// Sample the noise in 3 dimensions.
        /// </summary>
        public override float Sample3D(float x, float y, float z)
        {

            x = (x + Offset.x) * Frequency;
            y = (y + Offset.y) * Frequency;
            z = (z + Offset.z) * Frequency;

            int ix0, iy0, iz0;
            float fx0, fy0, fz0;
            float s, t, r;
            float nxy0, nxy1, nx0, nx1, n0, n1;

            ix0 = (int)Mathf.Floor(x);   // Integer part of x
            iy0 = (int)Mathf.Floor(y);   // Integer part of y
            iz0 = (int)Mathf.Floor(z);   // Integer part of z
            fx0 = x - ix0;              // Fractional part of x
            fy0 = y - iy0;              // Fractional part of y
            fz0 = z - iz0;              // Fractional part of z

            r = FADE(fz0);
            t = FADE(fy0);
            s = FADE(fx0);

            nxy0 = Perm[ix0, iy0, iz0];
            nxy1 = Perm[ix0, iy0, iz0 + 1];
            nx0 = LERP(r, nxy0, nxy1);

            nxy0 = Perm[ix0, iy0 + 1, iz0];
            nxy1 = Perm[ix0, iy0 + 1, iz0 + 1];
            nx1 = LERP(r, nxy0, nxy1);

            n0 = LERP(t, nx0, nx1);

            nxy0 = Perm[ix0 + 1, iy0, iz0];
            nxy1 = Perm[ix0 + 1, iy0, iz0 + 1];
            nx0 = LERP(r, nxy0, nxy1);

            nxy0 = Perm[ix0 + 1, iy0 + 1, iz0];
            nxy1 = Perm[ix0 + 1, iy0 + 1, iz0 + 1];
            nx1 = LERP(r, nxy0, nxy1);

            n1 = LERP(t, nx0, nx1);

            // rescale from 0 to 255 to -1 to 1.
            float n = LERP(s, n0, n1) * Perm.Inverse;
            n = n * 2.0f - 1.0f;

            return n * Amplitude;
        }

        private float FADE(float t) { return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f); }

        private float LERP(float t, float a, float b) { return a + t * (b - a); }

    }

}





