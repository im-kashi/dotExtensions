using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="StringExtensionsTest.IsNullOrWhiteSpace.g.cs">Copyright ©  2016</copyright>
// <auto-generated>
// このファイルには自動的に生成されたテストが含まれています。
// このファイルを手動で変更しないでください。
// 
// このファイルの内容が古くなった場合には削除することができます。
// たとえば、コンパイルが不要になった場合などです。
// </auto-generated>
using System;

namespace Imkashi.Extensions.Tests
{
    public partial class StringExtensionsTest {

[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void IsNullOrWhiteSpace642()
{
    bool b;
    b = this.IsNullOrWhiteSpace((string)null);
}

[TestMethod]
[PexGeneratedBy(typeof(StringExtensionsTest))]
public void IsNullOrWhiteSpace55()
{
    bool b;
    b = this.IsNullOrWhiteSpace("ĀĀ\0\0");
}
    }
}
