// <copyright file="EnumerableExtensionsTest.cs">Copyright ©  2016</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imkashi.Extensions.Tests {

    public partial class EnumerableExtensionsTest {

        [TestMethod]
        public void Select_Test() {
            new[] {
                new { Value = new[] { new UriBuilder("https://bing.com/index"), new UriBuilder("https://google.co.jp/index") }, Value2 = (Action<UriBuilder>)(b => b.Path += "_xxx"), Expected = new[] { new UriBuilder("https://bing.com/index_xxx"), new UriBuilder("https://google.co.jp/index_xxx") } },
            }
            .ForEach(item => Select(item.Value, item.Value2).ToArray().IsStructuralEqual(item.Expected));

            new[] {
                new { Value = new[] { new[] { 1 }, new[] { 2 }, new[] { 3 } }, Value2 = (Action<int[]>)(v => v[0] += 10), Expected = new[] { new[] { 11 }, new[] { 12 }, new[] { 13 } } },
                new { Value = new[] { new[] { 1 }, new[] { 2 }, new[] { 3 } }, Value2 = (Action<int[]>)(v => v[0] = 0), Expected = new[] { new[] { 0 }, new[] { 0 }, new[] { 0 } } },
            }
            .ForEach(item => Select(item.Value, item.Value2).ToArray().IsStructuralEqual(item.Expected));

            new[] {
                new { Value = new[] { 1, 2, 3 }, Value2 = (Action<int>)(v => v += 10), Expected = new[] { 1, 2, 3 } },
            }
            .ForEach(item => Select(item.Value, item.Value2).ToArray().IsStructuralEqual(item.Expected));
        }

        [TestMethod]
        public void ForEach_Test() {
            Assert.Fail();
        }

        [TestMethod]
        public void OrderByRandom_Test() {
            Assert.Fail();
        }

        [TestMethod]
        public void Chunk_Test() {
            Assert.Fail();
        }

        [TestMethod]
        public void ToSet_Test() {
            Assert.Fail();
        }
    }

    [TestClass]
    [PexClass(typeof(EnumerableExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EnumerableExtensionsTest {

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerable<T> Select<T>(IEnumerable<T> source, Action<T> action) {
            IEnumerable<T> result = EnumerableExtensions.Select<T>(source, action);
            return result;
            // TODO: アサーションを メソッド EnumerableExtensionsTest.Select(IEnumerable`1<!!0>, Action`1<!!0>) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void ForEach<T>(IEnumerable<T> source, Action<T> action) {
            EnumerableExtensions.ForEach<T>(source, action);
            // TODO: アサーションを メソッド EnumerableExtensionsTest.ForEach(IEnumerable`1<!!0>, Action`1<!!0>) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerable<T> OrderByRandom<T>(IEnumerable<T> source) {
            IEnumerable<T> result = EnumerableExtensions.OrderByRandom<T>(source);
            return result;
            // TODO: アサーションを メソッド EnumerableExtensionsTest.OrderByRandom(IEnumerable`1<!!0>) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerable<IEnumerable<T>> Chunk<T>(IEnumerable<T> source, int chunkSize) {
            IEnumerable<IEnumerable<T>> result = EnumerableExtensions.Chunk<T>(source, chunkSize);
            return result;
            // TODO: アサーションを メソッド EnumerableExtensionsTest.Chunk(IEnumerable`1<!!0>, Int32) に追加します
        }

        [PexGenericArguments(typeof(int))]
        [PexAllowedException(typeof(ArgumentNullException))]
        public ISet<T> ToSet<T>(IEnumerable<T> source) {
            ISet<T> result = EnumerableExtensions.ToSet<T>(source);
            return result;
            // TODO: アサーションを メソッド EnumerableExtensionsTest.ToSet(IEnumerable`1<!!0>) に追加します
        }
    }
}