using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Imkashi.Extensions {

    public static class TypeExtensions {

        /// <summary>
        ///カスタム属性の一覧を返します。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this Type type, bool inherit = false) where TAttribute : Attribute {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.Ensures(Contract.Result<IEnumerable<TAttribute>>() != null);

            return type.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>();
        }

        /// <summary>
        /// 基底クラスの一覧を返します。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="withSelf"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetBaseTypes(this Type type, bool withSelf = false) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.Ensures(Contract.Result<IEnumerable<Type>>() != null);

            if (withSelf) { yield return type; }

            Type baseType = type;
            while ((baseType = baseType.BaseType) != null) {
                yield return baseType;
            }
        }
    }
}