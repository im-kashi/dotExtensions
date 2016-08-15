using System;
using System.Diagnostics.Contracts;

namespace Imkashi.Extensions {

    public static class StringExtensions {

        /// <summary>
        /// 指定された文字列が null 又は空文字列であるかどうかを示します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value) {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指定された文字列が null、空文字列、又は空白文字だけで構成されているかどうかを示します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value) {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 文字列を切り詰めます。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="ellipsis"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength, string ellipsis = "...") {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (maxLength < 0) throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, null);
            Contract.Ensures(Contract.Result<string>() != null);

            if (value.Length <= maxLength) { return value; }

            return value.Substring(0, maxLength) + ellipsis;
        }
    }
}