using System;
using System.Diagnostics.Contracts;

namespace Imkashi.Extensions {

    public static class MathExtensions {

        #region Abs

        [CLSCompliant(false)]
        public static sbyte Abs(this sbyte value) {
            Contract.Requires(value != sbyte.MinValue);
            return Math.Abs(value);
        }

        public static short Abs(this short value) {
            Contract.Requires(value != short.MinValue);
            return Math.Abs(value);
        }

        public static int Abs(this int value) {
            Contract.Requires(value != int.MinValue);
            return Math.Abs(value);
        }

        public static long Abs(this long value) {
            Contract.Requires(value != long.MinValue);
            return Math.Abs(value);
        }

        public static decimal Abs(this decimal value) {
            return Math.Abs(value);
        }

        public static double Abs(this double value) {
            return Math.Abs(value);
        }

        public static float Abs(this float value) {
            return Math.Abs(value);
        }

        #endregion Abs

        #region Floor

        public static decimal Floor(this decimal value) {
            return Math.Floor(value);
        }

        public static double Floor(this double value) {
            return Math.Floor(value);
        }

        public static double Floor(this float value) {
            return Math.Floor(value);
        }

        #endregion Floor

        #region Ceiling

        public static decimal Ceiling(this decimal value) {
            return Math.Ceiling(value);
        }

        public static double Ceiling(this double value) {
            return Math.Ceiling(value);
        }

        public static double Ceiling(this float value) {
            return Math.Ceiling(value);
        }

        #endregion Ceiling

        #region Pow

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
        public static double Pow(this double x, double y) {
            return Math.Pow(x, y);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
        public static double Pow(this float x, double y) {
            return Math.Pow(x, y);
        }

        #endregion Pow

        #region Round

        public static decimal Round(this decimal value, int decimals = 0, MidpointRounding mode = MidpointRounding.ToEven) {
            Contract.Requires(decimals >= 0 && decimals <= 28);
            Contract.Requires(Enum.IsDefined(typeof(MidpointRounding), mode));

            return Math.Round(value, decimals, mode);
        }

        public static double Round(this double value, int digits = 0, MidpointRounding mode = MidpointRounding.ToEven) {
            Contract.Requires(digits >= 0 && digits <= 15);
            Contract.Requires(Enum.IsDefined(typeof(MidpointRounding), mode));

            return Math.Round(value, digits, mode);
        }

        public static double Round(this float value, int digits = 0, MidpointRounding mode = MidpointRounding.ToEven) {
            Contract.Requires(digits >= 0 && digits <= 15);
            Contract.Requires(Enum.IsDefined(typeof(MidpointRounding), mode));

            return Math.Round(value, digits, mode);
        }

        #endregion Round

        #region Sign

        [CLSCompliant(false)]
        public static int Sign(this sbyte value) {
            return Math.Sign(value);
        }

        public static int Sign(this short value) {
            return Math.Sign(value);
        }

        public static int Sign(this int value) {
            return Math.Sign(value);
        }

        public static int Sign(this long value) {
            return Math.Sign(value);
        }

        public static int Sign(this decimal value) {
            return Math.Sign(value);
        }

        public static int Sign(this double value) {
            Contract.Requires(double.IsNaN(value) == false);
            return Math.Sign(value);
        }

        public static int Sign(this float value) {
            Contract.Requires(float.IsNaN(value) == false);
            return Math.Sign(value);
        }

        #endregion Sign

        #region Truncate

        public static decimal Truncate(this decimal value) {
            return Math.Truncate(value);
        }

        public static double Truncate(this double value) {
            return Math.Truncate(value);
        }

        public static double Truncate(this float value) {
            return Math.Truncate(value);
        }

        #endregion Truncate

        #region Sqrt

        public static double Sqrt(this double value) {
            return Math.Sqrt(value);
        }

        public static double Sqrt(this float value) {
            return Math.Sqrt(value);
        }

        #endregion Sqrt
    }
}