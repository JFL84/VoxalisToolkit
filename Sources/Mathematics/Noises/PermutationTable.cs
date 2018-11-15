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

namespace Voxalis.Toolkit.Mathematics.Noises
{
    internal class PermutationTable
    {

        public int Size { get; private set; }

        public int Seed { get; private set; }

        public int Max { get; private set; }

        public float Inverse { get; private set; }

        private int Wrap;

        private int[] Table;

        internal PermutationTable(int size, int max, int seed)
        {
            Size = size;
            Wrap = Size - 1;
            Max = Math.Max(1, max);
            Inverse = 1.0f / Max;
            Build(seed);
        }

        internal void Build(int seed)
        {
            if (Seed == seed && Table != null) return;

            Seed = seed;
            Table = new int[Size];

            System.Random rnd = new System.Random(Seed);

            for (int i = 0; i < Size; i++)
            {
                Table[i] = rnd.Next();
            }
        }

        internal int this[int i]
        {
            get
            {
                return Table[i & Wrap] & Max;
            }
        }

        internal int this[int i, int j]
        {
            get
            {
                return Table[(j + Table[i & Wrap]) & Wrap] & Max;
            }
        }

        internal int this[int i, int j, int k]
        {
            get
            {
                return Table[(k + Table[(j + Table[i & Wrap]) & Wrap]) & Wrap] & Max;
            }
        }

    }
}
