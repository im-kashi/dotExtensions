using System;
using System.Diagnostics.Contracts;

namespace Imkashi.Extensions {

    public static class ObjectExtensions {

        /// <summary>
        /// 指定された型にキャストを試みます。
        /// キャストできなければ null を返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T As<T>(this object value) where T : class {
            return value as T;
        }

        #region To

        /// <summary>
        /// 指定された基本型に変換します。
        /// 変換規則は Convert.ChangeType メソッドに倣います。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this object value, IFormatProvider provider = null) {
            var result = Convert.ChangeType(value, typeof(T), provider);
            return result == null ? default(T) : (T)result;
        }

        /// <summary>
        /// 指定された基本型に変換します。
        /// 変換規則は Convert.ChangeType メソッドに倣います。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static object To(this object value, Type conversionType, IFormatProvider provider = null) {
            if (conversionType == null) throw new ArgumentNullException(nameof(conversionType));
            Contract.EndContractBlock();

            if (value == null) { return Activator.CreateInstance(conversionType); }

            return Convert.ChangeType(value, conversionType, provider);
        }

        #endregion To

        #region ToOrDefault

        /// <summary>
        /// 指定された基本型に変換します。
        /// 変換規則は Convert.ChangeType メソッドに倣います。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T ToOrDefault<T>(this object value, T defaultValue = default(T), IFormatProvider provider = null) {
            if (value == null) { return defaultValue; }

            var result = ChangeTypeOrDefault(value, typeof(T), defaultValue, provider);
            return result == null ? defaultValue : (T)result;
        }

        /// <summary>
        /// 指定された基本型に変換します。
        /// 変換規則は Convert.ChangeType メソッドに倣います。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static object ToOrDefault(this object value, Type conversionType, object defaultValue = null, IFormatProvider provider = null) {
            if (conversionType == null) throw new ArgumentNullException(nameof(conversionType));
            Contract.EndContractBlock();

            return ChangeTypeOrDefault(value, conversionType, defaultValue, provider);
        }

        #endregion ToOrDefault

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        private static object ChangeTypeOrDefault(object value, Type conversionType, object defaultValue, IFormatProvider provider) {
            var typeCode = Type.GetTypeCode(conversionType);

            if (value == null) {
                switch (typeCode) {
                    case TypeCode.Empty:
                    case TypeCode.String:
                    case TypeCode.Object:
                        return defaultValue;

                    default:
                        break;
                }
            }

            var v = value as IConvertible;
            if (v == null)
                throw new InvalidCastException();

            switch (typeCode) {
                case TypeCode.Boolean:
                    return v.ToBoolean(provider);

                case TypeCode.Char:
                    return v.ToChar(provider);

                case TypeCode.SByte:
                    return v.ToSByte(provider);

                case TypeCode.Byte:
                    return v.ToByte(provider);

                case TypeCode.Int16:
                    return v.ToInt16(provider);

                case TypeCode.UInt16:
                    return v.ToUInt16(provider);

                case TypeCode.Int32:
                    return v.ToInt32(provider);

                case TypeCode.UInt32:
                    return v.ToUInt32(provider);

                case TypeCode.Int64:
                    return v.ToInt64(provider);

                case TypeCode.UInt64:
                    return v.ToUInt64(provider);

                case TypeCode.Single:
                    return v.ToSingle(provider);

                case TypeCode.Double:
                    return v.ToDouble(provider);

                case TypeCode.Decimal:
                    return v.ToDecimal(provider);

                case TypeCode.DateTime:
                    return v.ToDateTime(provider);

                case TypeCode.String:
                    return v.ToString(provider);

                case TypeCode.Object:
                    return value;

                case TypeCode.DBNull:
                    throw new InvalidCastException();

                case TypeCode.Empty:
                    throw new InvalidCastException();

                default:
                    throw new ArgumentException(null, nameof(conversionType));
            }
        }
    }
}