// <copyright file="MathExtensionsTest.cs">Copyright ©  2016</copyright>

using System;
using Imkashi.Extensions;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imkashi.Extensions.Tests
{
    [TestClass]
    [PexClass(typeof(MathExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MathExtensionsTest
    {

        [PexMethod]
        [PexAllowedException(typeof(OverflowException))]
        public sbyte Abs(sbyte value) {
            sbyte result = MathExtensions.Abs(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Abs(SByte) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(OverflowException))]
        public short Abs01(short value) {
            short result = MathExtensions.Abs(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Abs01(Int16) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(OverflowException))]
        public int Abs02(int value) {
            int result = MathExtensions.Abs(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Abs02(Int32) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(OverflowException))]
        public long Abs03(long value) {
            long result = MathExtensions.Abs(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Abs03(Int64) に追加します
        }

        [PexMethod]
        public decimal Abs04(decimal value) {
            decimal result = MathExtensions.Abs(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Abs04(Decimal) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(ArgumentException))]
        [PexAllowedException(typeof(ArgumentOutOfRangeException))]
        public decimal Round(
            decimal value,
            int decimals,
            MidpointRounding mode
        ) {
            decimal result = MathExtensions.Round(value, decimals, mode);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Round(Decimal, Int32, MidpointRounding) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(ArgumentException))]
        [PexAllowedException(typeof(ArgumentOutOfRangeException))]
        public double Round01(
            double value,
            int digits,
            MidpointRounding mode
        ) {
            double result = MathExtensions.Round(value, digits, mode);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Round01(Double, Int32, MidpointRounding) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(ArgumentException))]
        [PexAllowedException(typeof(ArgumentOutOfRangeException))]
        public double Round02(
            float value,
            int digits,
            MidpointRounding mode
        ) {
            double result = MathExtensions.Round(value, digits, mode);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Round02(Single, Int32, MidpointRounding) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(ArithmeticException))]
        public int Sign05(double value) {
            int result = MathExtensions.Sign(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Sign05(Double) に追加します
        }

        [PexMethod]
        [PexAllowedException(typeof(ArithmeticException))]
        public int Sign06(float value) {
            int result = MathExtensions.Sign(value);
            return result;
            // TODO: アサーションを メソッド MathExtensionsTest.Sign06(Single) に追加します
        }
    }
}
