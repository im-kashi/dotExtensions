using System.Collections.Generic;

namespace Imkashi.Extensions {

    public static class CollectionExtensions {

        /// <summary>
        /// コレクションが null 又は空要素であるかどうかを示します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source) {
            return source == null || source.Count == 0;
        }

        /// <summary>
        /// コレクションが null 又は空要素であるかどうかを示します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> source) {
            return source == null || source.Count == 0;
        }
    }
}