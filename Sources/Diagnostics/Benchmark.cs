using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Voxalis.Toolkit.Diagnostics
{
    /// <summary>
    /// Benchmark.
    /// </summary>
    public class Benchmark
    {
        /// <summary>
        /// Sort by.
        /// </summary>
        public enum SortBy
        {
            None = -1,
            Min = 0,
            Max = 1,
            Average = 2
        }

        /// <summary>
        /// The iterations.
        /// </summary>
        private readonly int Iterations;

        /// <summary>
        /// The duration.
        /// </summary>
        private Clock.Duration Duration = Clock.Duration.Milliseconds;

        /// <summary>
        /// The labels.
        /// </summary>
        private readonly List<String> Labels = new List<string>();

        /// <summary>
        /// The callbacks.
        /// </summary>
        private readonly List<Action> Callbacks = new List<Action>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Voxalis.Toolkit.Diagnostics.Benchmark"/> class.
        /// </summary>
        /// <param name="iterations">Iterations.</param>
        public Benchmark(int iterations = 1)
        => Iterations = iterations;

        /// <summary>
        /// Sets the duration measure.
        /// </summary>
        /// <param name="duration">Duration.</param>
        public void SetDurationMeasure(Clock.Duration duration)
        {
            Duration = duration;
        }

        /// <summary>
        /// Add the specified label and callback.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="callback">Callback.</param>
        public void Add(String label, Action callback)
        {
            Labels.Add(label);
            Callbacks.Add(callback);
        }

        /// <summary>
        /// Result.
        /// </summary>
        private struct Result
        {
            public String label;
            public double[] score;
        }

        /// <summary>
        /// Process this instance.
        /// </summary>
        public void Process(SortBy sortBy = SortBy.None)
        {
            var cbcounts = Callbacks.Count;

            var results = new List<Result>();

            if (cbcounts == 0)
            {
                Debug.Log("Please, add some tests :-)");
                return;
            }

            for (var i = 0; i < cbcounts; i++)
            {
                results.Add(new Result
                {
                    label = Labels[i],
                    score = Clock.Measure(Iterations, Callbacks[i], Duration)
                });
            }

            if (sortBy != SortBy.None)
            {
                results = results.OrderBy(r => r.score[(int)sortBy]).ToList();
            }

            var ext = Clock.ConvertDurationToString(Duration);

            for (var i = 0; i < cbcounts; i++)
            {
                var r = results[i];
                var s = $"{r.label} # ";

                switch (sortBy)
                {
                    case SortBy.Min:
                    case SortBy.None:
                        s += $"[ Min: {r.score[0]}{ext} ]";
                        s += $"[ Max: {r.score[1]}{ext} ]";
                        s += $"[ Average: {r.score[2]}{ext} ]";
                        break;
                    case SortBy.Max:
                        s += $"[ Max: {r.score[1]}{ext} ]";
                        s += $"[ Min: {r.score[0]}{ext} ]";
                        s += $"[ Average: {r.score[2]}{ext} ]";
                        break;
                    case SortBy.Average:
                        s += $"[ Average: {r.score[2]}{ext} ]";
                        s += $"[ Min: {r.score[0]}{ext} ]";
                        s += $"[ Max: {r.score[1]}{ext} ]";
                        break;
                }

                Debug.Log(s);
            }
        }
    }
}
