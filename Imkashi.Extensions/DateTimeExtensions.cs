using System;
using System.Diagnostics.Contracts;

namespace Imkashi.Extensions {

    public static class DateTimeExtensions {

        /// <summary>
        /// 月初を返します。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime BeginningOfMonth(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// 月末を返します。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }

        /// <summary>
        /// 当月の日数を返します。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime dt) {
            Contract.Ensures(Contract.Result<int>() >= dt.Day);
            Contract.Ensures(Contract.Result<int>() <= 31);

            var days = DateTime.DaysInMonth(dt.Year, dt.Month);
            Contract.Assume(days >= dt.Day);
            return days;
        }

        ///// <summary>
        ///// 当月の残日数を返します。
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public static int DaysLeftInMonth(this DateTime dt) {
        //    Contract.Ensures(Contract.Result<int>() >= 0);
        //    Contract.Ensures(Contract.Result<int>() <= 31);

        //    return dt.DaysInMonth() - dt.Day + 1;
        //}

        /// <summary>
        /// 当月の残時間を返します。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan LeftInMonth(this DateTime dt) {
            Contract.Ensures(Contract.Result<TimeSpan>() > TimeSpan.Zero);
            Contract.Ensures(Contract.Result<TimeSpan>() <= TimeSpan.FromDays(31));

            var result = dt.BeginningOfMonth().AddMonths(1) - dt;
            Contract.Assume(result > TimeSpan.Zero);
            Contract.Assume(result <= TimeSpan.FromDays(31));
            return result;
        }

        /// <summary>
        /// 指定した DateTimePart 以下の部分を 0 又は 1 にリセットします。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        public static DateTime Truncate(this DateTime dt, DateTimePart part) {
            switch (part) {
                case DateTimePart.Year:
                    return new DateTime(1, 1, 1);

                case DateTimePart.Month:
                    return new DateTime(dt.Year, 1, 1);

                case DateTimePart.Day:
                    return new DateTime(dt.Year, dt.Month, 1);

                case DateTimePart.Hour:
                    return new DateTime(dt.Year, dt.Month, dt.Day);

                case DateTimePart.Minute:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0);

                case DateTimePart.Second:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);

                case DateTimePart.Millisecond:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);

                default:
                    throw new ArgumentOutOfRangeException(nameof(part), part, null);
            }
        }
    }
}