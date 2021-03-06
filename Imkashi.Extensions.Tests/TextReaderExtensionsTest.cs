using System.IO;
using System.Collections.Generic;
// <copyright file="TextReaderExtensionsTest.cs">Copyright ©  2016</copyright>

using System;
using Imkashi.Extensions;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imkashi.Extensions.Tests
{
    [TestClass]
    [PexClass(typeof(TextReaderExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TextReaderExtensionsTest
    {

        [PexMethod]
        public IEnumerable<string> ReadLines(TextReader reader) {
            IEnumerable<string> result = TextReaderExtensions.ReadLines(reader);
            return result;
            // TODO: アサーションを メソッド TextReaderExtensionsTest.ReadLines(TextReader) に追加します
        }
    }
}
