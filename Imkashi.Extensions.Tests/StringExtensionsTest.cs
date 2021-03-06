// <copyright file="StringExtensionsTest.cs">Copyright ©  2016</copyright>

using System;
using Imkashi.Extensions;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imkashi.Extensions.Tests
{
    [TestClass]
    [PexClass(typeof(StringExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class StringExtensionsTest
    {

        [PexMethod]
        public bool IsNullOrEmpty(string value) {
            bool result = StringExtensions.IsNullOrEmpty(value);
            return result;
            // TODO: アサーションを メソッド StringExtensionsTest.IsNullOrEmpty(String) に追加します
        }

        [PexMethod]
        public bool IsNullOrWhiteSpace(string value) {
            bool result = StringExtensions.IsNullOrWhiteSpace(value);
            return result;
            // TODO: アサーションを メソッド StringExtensionsTest.IsNullOrWhiteSpace(String) に追加します
        }

        [PexMethod]
        public string Truncate(
            string value,
            int maxLength,
            string ellipsis
        ) {
            string result = StringExtensions.Truncate(value, maxLength, ellipsis);
            return result;
            // TODO: アサーションを メソッド StringExtensionsTest.Truncate(String, Int32, String) に追加します
        }
    }
}
