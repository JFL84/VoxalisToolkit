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
using System;
using UnityEngine;

namespace Voxalis.Toolkit.Mathematics.Noises
{
    /// <summary>
    /// A concrete class for generating fractal noise.
    /// </summary>
    public class FractalNoise
    {
        /// <summary>
        /// The number of octaves in the fractal.
        /// </summary>
        public int Octaves { get; set; }

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
        /// The rate at which the amplitude changes.
        /// </summary>
        public float Lacunarity { get; set; }

        /// <summary>
        /// The rate at which the frequency changes.
        /// </summary>
        public float Gain { get; set; }

        /// <summary>
        /// The noises to sample from to generate the fractal.
        /// </summary>
        public INoise[] Noises { get; set; }

        /// <summary>
        /// The amplitudes for each octave.
        /// </summary>
        public float[] Amplitudes { get; set; }

        /// <summary>
        /// The frequencies for each octave.
        /// </summary>
        public float[] Frequencies { get; set; }

        public FractalNoise(INoise noise, int octaves, float frequency, float amplitude = 1.0f)
        {

            Octaves = octaves;
            Frequency = frequency;
            Amplitude = amplitude;
            Offset = Vector3.zero;
            Lacunarity = 2.0f;
            Gain = 0.5f;

            UpdateTable(new INoise[] { noise });
        }

        public FractalNoise(INoise[] noises, int octaves, float frequency, float amplitude = 1.0f)
        {

            Octaves = octaves;
            Frequency = frequency;
            Amplitude = amplitude;
            Offset = Vector3.zero;
            Lacunarity = 2.0f;
            Gain = 0.5f;

            UpdateTable(noises);
        }

        /// <summary>
        /// Calculates the amplitudes and frequencies tables for each octave
        /// based on the fractal settings. The tables are used so individual 
        /// octaves can be sampled. Must be called when object is first created
        /// and when ever the settings are changed.
        /// </summary>
        public virtual void UpdateTable()
        {
            UpdateTable(Noises);
        }

        protected virtual void UpdateTable(INoise[] noises)
        {
            Amplitudes = new float[Octaves];
            Frequencies = new float[Octaves];
            Noises = new INoise[Octaves];

            int numNoises = noises.Length;

            float amp = 0.5f;
            float frq = Frequency;
            for (int i = 0; i < Octaves; i++)
            {
                Noises[i] = noises[Math.Min(i, numNoises - 1)];
                Frequencies[i] = frq;
                Amplitudes[i] = amp;
                amp *= Gain;
                frq *= Lacunarity;
            }

        }

        /// <summary>
        /// Returns the noise value from a octave in a 1D fractal.
        /// </summary>
        /// <param name="i">The octave to sample.</param>
        /// <param name="x">A value on the x axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Octave1D(int i, float x)
        {
            if (i >= Octaves) return 0.0f;
            if (Noises[i] == null) return 0.0f;

            x = x + Offset.x;

            float frq = Frequencies[i];
            return Noises[i].Sample1D(x * frq) * Amplitudes[i] * Amplitude;
        }

        /// <summary>
        /// Returns the noise value from a octave in a 2D fractal.
        /// </summary>
        /// <param name="i">The octave to sample.</param>
        /// <param name="x">A value on the x axis.</param>
        /// <param name="y">A value on the y axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Octave2D(int i, float x, float y)
        {
            if (i >= Octaves) return 0.0f;
            if (Noises[i] == null) return 0.0f;

            x = x + Offset.x;
            y = y + Offset.y;

            float frq = Frequencies[i];
            return Noises[i].Sample2D(x * frq, y * frq) * Amplitudes[i] * Amplitude;
        }

        /// <summary>
        /// Returns the noise value from a octave in a 3D fractal.
        /// </summary>
        /// <param name="i">The octave to sample.</param>
        /// <param name="x">A value on the x axis.</param>
        /// <param name="y">A value on the y axis.</param>
        /// <param name="z">A value on the z axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Octave3D(int i, float x, float y, float z)
        {
            if (i >= Octaves) return 0.0f;
            if (Noises[i] == null) return 0.0f;

            x = x + Offset.x;
            y = y + Offset.y;
            z = z + Offset.z;

            float frq = Frequencies[i];
            return Noises[i].Sample3D(x * frq, y * frq, z * frq) * Amplitudes[i] * Amplitude;
        }

        /// <summary>
        /// Samples a 1D fractal.
        /// </summary>
        /// <param name="x">A value on the x axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Sample1D(float x)
        {
            x = x + Offset.x;

            float sum = 0, frq;
            for (int i = 0; i < Octaves; i++)
            {
                frq = Frequencies[i];

                if (Noises[i] != null)
                    sum += Noises[i].Sample1D(x * frq) * Amplitudes[i];
            }
            return sum * Amplitude;
        }

        /// <summary>
        /// Samples a 2D fractal.
        /// </summary>
        /// <param name="x">A value on the x axis.</param>
        /// <param name="y">A value on the y axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Sample2D(float x, float y)
        {
            x = x + Offset.x;
            y = y + Offset.y;

            float sum = 0, frq;
            for (int i = 0; i < Octaves; i++)
            {
                frq = Frequencies[i];

                if (Noises[i] != null)
                    sum += Noises[i].Sample2D(x * frq, y * frq) * Amplitudes[i];
            }
            return sum * Amplitude;
        }

        /// <summary>
        /// Samples a 3D fractal.
        /// </summary>
        /// <param name="x">A value on the x axis.</param>
        /// <param name="y">A value on the y axis.</param>
        /// <param name="z">A value on the z axis.</param>
        /// <returns>A noise value between -Amp and Amp.</returns>
        public virtual float Sample3D(float x, float y, float z)
        {
            x = x + Offset.x;
            y = y + Offset.y;
            z = z + Offset.z;

            float sum = 0, frq;
            for (int i = 0; i < Octaves; i++)
            {
                frq = Frequencies[i];

                if (Noises[i] != null)
                    sum += Noises[i].Sample3D(x * frq, y * frq, z * frq) * Amplitudes[i];
            }
            return sum * Amplitude;
        }

    }

}














