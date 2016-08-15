using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Imkashi.Extensions {

    public static class DictionaryExtensions {

        /// <summary>
        /// Dictionary オブジェクトからキーに対応する値を返します。
        /// キーが存在しなければ既定値を返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue)) {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            Contract.Requires(key != null);

            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        /// <summary>
        /// Dictionary オブジェクトからキーに対応する値を返します。
        /// キーが存在しなければ既定値を返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValueProvider"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> defaultValueProvider) {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (defaultValueProvider == null) throw new ArgumentNullException(nameof(defaultValueProvider));
            Contract.Requires(key != null);

            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValueProvider(key);
        }

        /// <summary>
        /// キーが存在しない場合に限り、Dictionary オブジェクトに値を追加します。
        /// キーが存在すれば既存の値を返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue AddOrGetExisting<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, TValue value) {
            if (self == null) throw new ArgumentNullException(nameof(self));
            Contract.Requires(key != null);

            TValue existingValue;
            if (self.TryGetValue(key, out existingValue)) { return existingValue; }

            self[key] = value;
            return value;
        }

        /// <summary>
        /// キーが存在しない場合に限り、Dictionary オブジェクトに値を追加します。
        /// キーが存在すれば既存の値を返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="valueProvider"></param>
        /// <returns></returns>
        public static TValue AddOrGetExisting<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, Func<TKey, TValue> valueProvider) {
            if (self == null) throw new ArgumentNullException(nameof(self));
            if (valueProvider == null) throw new ArgumentNullException(nameof(valueProvider));
            Contract.Requires(key != null);

            TValue existingValue;
            if (self.TryGetValue(key, out existingValue)) { return existingValue; }

            var value = valueProvider(key);
            self[key] = value;
            return value;
        }
    }
}