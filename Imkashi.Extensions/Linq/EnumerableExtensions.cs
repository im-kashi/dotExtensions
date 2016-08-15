using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Imkashi.Extensions {

    public static class EnumerableExtensions {

        /// <summary>
        /// シーケンスの各要素に対して action を実行し、要素をそのまま返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Action<T> action) {
            if (source == null) throw new ArgumentNullException(paramName: nameof(source));
            if (action == null) throw new ArgumentNullException(paramName: nameof(action));
            Contract.Ensures(Contract.Result<IEnumerable<T>>() != null);

            foreach (var item in source) {
                action(item);
                yield return item;
            }
        }

        /// <summary>
        /// シーケンスの各要素に対して action を実行します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            if (source == null) throw new ArgumentNullException(paramName: nameof(source));
            if (action == null) throw new ArgumentNullException(paramName: nameof(action));
            Contract.EndContractBlock();

            foreach (var item in source) {
                action(item);
            }
        }

        /// <summary>
        /// シーケンスをランダムな並び順にソートします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> source) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            Contract.Ensures(Contract.Result<IEnumerable<T>>() != null);

            return source.OrderBy(_x => Guid.NewGuid());
        }

        /// <summary>
        /// シーケンスを指定されたサイズのチャンクに分割します。
        /// http://codereview.stackexchange.com/questions/72201/split-a-list-into-equal-parts-that-using-linq-in-a-way-that-has-good-performance/72202#72202
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (chunkSize <= 0) throw new ArgumentOutOfRangeException(nameof(chunkSize), chunkSize, null);
            Contract.Ensures(Contract.Result<IEnumerable<IEnumerable<T>>>() != null);

            // パフォーマンスで負けた。。。
            //return source
            //    .Select((_value, _index) => new { _value, _index })
            //    .GroupBy(_e => _e._index / chunkSize, _e => _e._value)
            //    ;

            // 早い！
            var chunk = new List<T>(chunkSize);
            foreach (var item in source) {
                chunk.Add(item);
                if (chunk.Count == chunkSize) {
                    yield return chunk.ToArray();
                    chunk.Clear();
                }
            }
            if (chunk.Count > 0) {
                yield return chunk;
            }
        }

        /// <summary>
        /// 値のセットを表すオブジェクトを生成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ISet<T> ToSet<T>(this IEnumerable<T> source) {
            Contract.Requires(source != null);
            Contract.Ensures(Contract.Result<ISet<T>>() != null);

            return new HashSet<T>(source);
        }
    }
}