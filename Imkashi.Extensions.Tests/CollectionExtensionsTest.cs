// <copyright file="CollectionExtensionsTest.cs">Copyright ©  2016</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imkashi.Extensions.Tests {

    public partial class CollectionExtensionsTest {

        [TestMethod]
        public void IsNullOrEmpty_Test() {
            new[] {
                new { Value = (object[])Enumerable.Range(1, 100).Cast<object>().ToArray(), Expected = false },
                new { Value = new object[1], Expected = false },
                new { Value = new object[0], Expected = true },
                new { Value = (object[])null, Expected = true },
            }
            .ForEach(item => {
                IsNullOrEmpty(item.Value).Is(item.Expected);
                IsNullOrEmpty01(item.Value).Is(item.Expected);
            });
        }
    }

    [TestClass]
    [PexClass(typeof(CollectionExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CollectionExtensionsTest {

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool IsNullOrEmpty<T>(ICollection<T> source) {
            bool result = CollectionExtensions.IsNullOrEmpty<T>(source);
            return result;
            // TODO: アサーションを メソッド CollectionExtensionsTest.IsNullOrEmpty(ICollection`1<!!0>) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool IsNullOrEmpty01<T>(IReadOnlyCollection<T> source) {
            bool result = CollectionExtensions.IsNullOrEmpty<T>(source);
            return result;
            // TODO: アサーションを メソッド CollectionExtensionsTest.IsNullOrEmpty01(IReadOnlyCollection`1<!!0>) に追加します
        }
    }
}