// <copyright file="DictionaryExtensionsTest.cs">Copyright ©  2016</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Imkashi.Extensions.Tests {

    public partial class DictionaryExtensionsTest {

        [TestMethod]
        public void GetOrDefault_Test() {
            new[] {
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullName", Value3 = "Default FullName 1", Expected = "暁美ほむら" },
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullNam_", Value3 = "Default FullName 2", Expected = "Default FullName 2" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = "Default FullName 3", Expected = "Default FullName 3" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = "", Expected = "" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (string)null, Expected = (string)null },
            }
            .ForEach(item => GetOrDefault(item.Value, item.Value2, item.Value3).Is(item.Expected));
        }

        [TestMethod]
        public void GetOrDefault01_Test() {
            new[] {
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullName", Value3 = (Func<string, string>)(key => "Default FullName 1"), Expected = "暁美ほむら" },
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullNam_", Value3 = (Func<string, string>)(key => "Default FullName 2"), Expected = "Default FullName 2" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => "Default FullName 3"), Expected = "Default FullName 3" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => ""), Expected = "" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => null), Expected = (string)null },
            }
            .ForEach(item => GetOrDefault01(item.Value, item.Value2, item.Value3).Is(item.Expected));
        }

        [TestMethod]
        public void AddOrGetExisting_Test() {
            new[] {
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullName", Value3 = "Default FullName 1", Expected = "暁美ほむら" },
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullNam_", Value3 = "Default FullName 2", Expected = "Default FullName 2" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = "Default FullName 3", Expected = "Default FullName 3" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = "", Expected = "" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (string)null, Expected = (string)null },
            }
            .ForEach(item => {
                AddOrGetExisting(item.Value, item.Value2, item.Value3).Is(item.Expected);
                item.Value[item.Value2].Is(item.Expected);
            });
        }

        [TestMethod]
        public void AddOrGetExisting01_Test() {
            new[] {
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullName", Value3 = (Func<string, string>)(key => "Default FullName 1"), Expected = "暁美ほむら" },
                new { Value = new Dictionary<string, string> { ["FullName"] = "暁美ほむら" }, Value2 = "FullNam_", Value3 = (Func<string, string>)(key => "Default FullName 2"), Expected = "Default FullName 2" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => "Default FullName 3"), Expected = "Default FullName 3" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => ""), Expected = "" },
                new { Value = new Dictionary<string, string> {}, Value2 = "FullName", Value3 = (Func<string, string>)(key => null), Expected = (string)null },
            }
            .ForEach(item => {
                AddOrGetExisting01(item.Value, item.Value2, item.Value3).Is(item.Expected);
                item.Value[item.Value2].Is(item.Expected);
            });
        }
    }

    [TestClass]
    [PexClass(typeof(DictionaryExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DictionaryExtensionsTest {

        [PexGenericArguments(typeof(int), typeof(int))]
        [PexMethod]
        public TValue GetOrDefault<TKey, TValue>(
            IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue
        ) {
            TValue result = DictionaryExtensions.GetOrDefault<TKey, TValue>(dictionary, key, defaultValue);
            return result;
            // TODO: アサーションを メソッド DictionaryExtensionsTest.GetOrDefault(IReadOnlyDictionary`2<!!0,!!1>, !!0, !!1) に追加します
        }

        [PexGenericArguments(typeof(int), typeof(int))]
        [PexMethod]
        public TValue GetOrDefault01<TKey, TValue>(
            IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> defaultValueProvider
        ) {
            TValue result
               = DictionaryExtensions.GetOrDefault<TKey, TValue>(dictionary, key, defaultValueProvider);
            return result;
            // TODO: アサーションを メソッド DictionaryExtensionsTest.GetOrDefault01(IReadOnlyDictionary`2<!!0,!!1>, !!0, Func`2<!!0,!!1>) に追加します
        }

        [PexGenericArguments(typeof(int), typeof(int))]
        [PexMethod]
        public TValue AddOrGetExisting<TKey, TValue>(
            IDictionary<TKey, TValue> self,
            TKey key,
            TValue value
        ) {
            TValue result = DictionaryExtensions.AddOrGetExisting<TKey, TValue>(self, key, value);
            return result;
            // TODO: アサーションを メソッド DictionaryExtensionsTest.AddOrGetExisting(IDictionary`2<!!0,!!1>, !!0, !!1) に追加します
        }

        [PexGenericArguments(typeof(int), typeof(int))]
        [PexMethod]
        public TValue AddOrGetExisting01<TKey, TValue>(
            IDictionary<TKey, TValue> self,
            TKey key,
            Func<TKey, TValue> valueProvider
        ) {
            TValue result = DictionaryExtensions.AddOrGetExisting<TKey, TValue>(self, key, valueProvider);
            return result;
            // TODO: アサーションを メソッド DictionaryExtensionsTest.AddOrGetExisting(IDictionary`2<!!0,!!1>, !!0, Func`2<!!0,!!1>) に追加します
        }
    }
}