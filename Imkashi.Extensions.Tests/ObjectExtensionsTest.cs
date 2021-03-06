// <copyright file="ObjectExtensionsTest.cs">Copyright ©  2016</copyright>

using System;
using Imkashi.Extensions;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imkashi.Extensions.Tests
{
    [TestClass]
    [PexClass(typeof(ObjectExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ObjectExtensionsTest
    {

        [PexGenericArguments(typeof(object))]
        [PexMethod]
        public T As<T>(object value)
            where T : class {
            T result = ObjectExtensions.As<T>(value);
            return result;
            // TODO: アサーションを メソッド ObjectExtensionsTest.As(Object) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        [PexAllowedException(typeof(InvalidCastException))]
        [PexAllowedException(typeof(FormatException))]
        [PexAllowedException(typeof(OverflowException))]
        public T To<T>(object value, IFormatProvider provider) {
            T result = ObjectExtensions.To<T>(value, provider);
            return result;
            // TODO: アサーションを メソッド ObjectExtensionsTest.To(Object, IFormatProvider) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        [PexAllowedException(typeof(InvalidCastException))]
        [PexAllowedException(typeof(OverflowException))]
        [PexAllowedException(typeof(FormatException))]
        public T ToOrDefault<T>(
            object value,
            T defaultValue,
            IFormatProvider provider
        ) {
            T result = ObjectExtensions.ToOrDefault<T>(value, defaultValue, provider);
            return result;
            // TODO: アサーションを メソッド ObjectExtensionsTest.ToOrDefault(Object, !!0, IFormatProvider) に追加します
        }
    }
}
