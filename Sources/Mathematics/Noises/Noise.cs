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
    /// Abstract class for generating noise.
    /// </summary>
    public abstract class Noise : INoise
    {

        /// <summary>
        /// The frequency of the fractal.
        /// </summary>
        public float Frequency { get; set; }

        /// <summary>
        /// The amplitude of the fractal.
        /// </summary>
        public float Amplitude { get; set; }

        /// <summary>
        /// The offset applied to each dimension.
        /// </summary>
        public Vector3 Offset { get; set; }

        /// <summary>
        /// Create a noise object.
        /// </summary>
        public Noise()
        {

        }

        /// <summary>
        /// Sample the noise in 1 dimension.
        /// </summary>
        public abstract float Sample1D(float x);

        /// <summary>
        /// Sample the noise in 2 dimensions.
        /// </summary>
        public abstract float Sample2D(float x, float y);

        /// <summary>
        /// Sample the noise in 3 dimensions.
        /// </summary>
        public abstract float Sample3D(float x, float y, float z);

        /// <summary>
        /// Update the seed.
        /// </summary>
        public abstract void UpdateSeed(int seed);

    }

}
