using UnityEngine;

namespace Voxalis.Toolkit.Diagnostics
{
    /// <summary>
    /// Clock.
    /// </summary>
    public static class Clock
    {
        /// <summary>
        /// Duration.
        /// </summary>
        public enum Duration
        {
            Milliseconds,
            Seconds,
            Minutes,
            Hours,
            Days,
            Ticks,
        }

        /// <summary>
        /// Measure the specified callback and duration.
        /// </summary>
        /// <returns>The measure.</returns>
        /// <param name="callback">Callback.</param>
        /// <param name="duration">Duration.</param>
        public static double Measure(System.Action callback, Duration duration = Duration.Milliseconds)
        {
            var time = default(double);
            var clock = new System.Diagnostics.Stopwatch();

            lock (clock)
            {
                clock.Reset();
                clock.Start();
            }

            callback();

            lock (clock)
            {
                clock.Stop();

                switch (duration)
                {
                    case Duration.Milliseconds: time = clock.Elapsed.TotalMilliseconds; break;
                    case Duration.Seconds: time = clock.Elapsed.TotalSeconds; break;
                    case Duration.Minutes: time = clock.Elapsed.TotalMinutes; break;
                    case Duration.Hours: time = clock.Elapsed.TotalHours; break;
                    case Duration.Days: time = clock.Elapsed.TotalDays; break;
                    case Duration.Ticks: time = Mathf.RoundToInt(clock.Elapsed.Ticks); break;
                }
            }

            return time;
        }

        /// <summary>
        /// Measure the specified iterations, callback and duration.
        /// </summary>
        /// <returns>The measure.</returns>
        /// <param name="iterations">Iterations.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="duration">Duration.</param>
        public static double[] Measure(int iterations, System.Action callback, Duration duration = Duration.Milliseconds)
        {
            var clock = new System.Diagnostics.Stopwatch();

            double min = double.MaxValue;
            double max = 0;
            double total = 0;

            callback(); // Prevents JIT compilation time

            for (var i = 0; i < iterations; i++)
            {

                clock.Reset();
                clock.Start();

                callback();

                clock.Stop();

                double time = 0;

                switch (duration)
                {
                    case Duration.Milliseconds: time = clock.Elapsed.TotalMilliseconds; break;
                    case Duration.Seconds: time = clock.Elapsed.TotalSeconds; break;
                    case Duration.Minutes: time = clock.Elapsed.TotalMinutes; break;
                    case Duration.Hours: time = clock.Elapsed.TotalHours; break;
                    case Duration.Days: time = clock.Elapsed.TotalDays; break;
                    case Duration.Ticks: time = clock.Elapsed.Ticks; break;
                }

                total += time;

                if (time > max)
                {
                    max = time;
                }
                if (time < min)
                {
                    min = time;
                }
            }

            return new double[3]
            {
                min,max, total / iterations
            };
        }

        /// <summary>
        /// Converts the duration to string.
        /// </summary>
        /// <returns>The duration to string.</returns>
        /// <param name="duration">Duration.</param>
        public static string ConvertDurationToString(Duration duration)
        {
            switch (duration)
            {
                case Duration.Milliseconds: return "ms";
                case Duration.Seconds: return "s";
                case Duration.Minutes: return "m";
                case Duration.Hours: return "h";
                case Duration.Days: return "d";
                case Duration.Ticks: return "t";
            }
            return "";
        }

        /// <summary>
        /// Measures to string.
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="label">Label.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="duration">Duration.</param>
        public static string MeasureToStr(string label, System.Action callback, Duration duration = Duration.Milliseconds)
        {
            return $"{label} # "
                + Measure(callback, duration)
                + ConvertDurationToString(duration);
        }

        /// <summary>
        /// Log the specified label, callback and duration.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="duration">Duration.</param>
        public static void Log(string label, System.Action callback, Duration duration = Duration.Milliseconds)
        => Debug.Log(MeasureToStr(label, callback, duration));
    }

}
