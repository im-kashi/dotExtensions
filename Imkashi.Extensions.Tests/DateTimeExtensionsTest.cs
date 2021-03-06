// <copyright file="DateTimeExtensionsTest.cs">Copyright ©  2016</copyright>

using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imkashi.Extensions.Tests {

    public partial class DateTimeExtensionsTest {

        [TestMethod]
        public void BeginningOfMonth_Test() {
            new[] {
                new { Value = new DateTime(2016, 8, 13), Expected = new DateTime(2016, 8, 1) },
            }
            .ForEach(item => BeginningOfMonth(item.Value).Is(item.Expected));
        }

        [TestMethod]
        public void DaysInMonth_Test() {
            new[] {
                new { Value = new DateTime(2016, 8, 13), Expected = 31 },
                new { Value = new DateTime(2016, 2, 13), Expected = 29 },
                new { Value = new DateTime(2015, 2, 13), Expected = 28 },
            }
            .ForEach(item => DaysInMonth(item.Value).Is(item.Expected));
        }

        [TestMethod]
        public void EndOfMonth_Test() {
            new[] {
                new { Value = new DateTime(2016, 8, 13), Expected = new DateTime(2016, 8, 31) },
                new { Value = new DateTime(2016, 2, 13), Expected = new DateTime(2016, 2, 29) },
                new { Value = new DateTime(2015, 2, 13), Expected = new DateTime(2015, 2, 28) },
            }
            .ForEach(item => EndOfMonth(item.Value).Is(item.Expected));
        }

        [TestMethod]
        public void LeftInMonth_Test() {
            new[] {
                new { Value = new DateTime(2016, 8, 31), Expected = TimeSpan.FromDays(1) },
                new { Value = new DateTime(2016, 8, 31, 18, 0, 0), Expected = TimeSpan.FromHours(6) },
            }
            .ForEach(item => LeftInMonth(item.Value).Is(item.Expected));
        }
    }

    [TestClass]
    [PexClass(typeof(DateTimeExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DateTimeExtensionsTest {

        [PexMethod]
        public DateTime BeginningOfMonth(DateTime dt) {
            DateTime result = DateTimeExtensions.BeginningOfMonth(dt);
            return result;
            // TODO: アサーションを メソッド DateTimeExtensionsTest.BeginningOfMonth(DateTime) に追加します
        }

        [PexMethod]
        public int DaysInMonth(DateTime dt) {
            int result = DateTimeExtensions.DaysInMonth(dt);
            return result;
            // TODO: アサーションを メソッド DateTimeExtensionsTest.DaysInMonth(DateTime) に追加します
        }

        [PexMethod]
        public DateTime EndOfMonth(DateTime dt) {
            DateTime result = DateTimeExtensions.EndOfMonth(dt);
            return result;
            // TODO: アサーションを メソッド DateTimeExtensionsTest.EndOfMonth(DateTime) に追加します
        }

        [PexMethod]
        public TimeSpan LeftInMonth(DateTime dt) {
            TimeSpan result = DateTimeExtensions.LeftInMonth(dt);
            return result;
            // TODO: アサーションを メソッド DateTimeExtensionsTest.LeftInMonth(DateTime) に追加します
        }

        [PexMethod]
        public DateTime Truncate(DateTime dt, DateTimePart part) {
            DateTime result = DateTimeExtensions.Truncate(dt, part);
            return result;
            // TODO: アサーションを メソッド DateTimeExtensionsTest.Truncate(DateTime, DateTimePart) に追加します
        }
    }
}