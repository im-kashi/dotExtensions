using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="MathExtensionsTest.Round.g.cs">Copyright ©  2016</copyright>
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
    public partial class MathExtensionsTest {

[TestMethod]
[PexGeneratedBy(typeof(MathExtensionsTest))]
public void Round422()
{
    decimal d;
    d = this.Round(default(decimal), 0, MidpointRounding.AwayFromZero);
}

[TestMethod]
[PexGeneratedBy(typeof(MathExtensionsTest))]
public void Round594()
{
    decimal d;
    d = this.Round(default(decimal), 0, MidpointRounding.ToEven);
}

[TestMethod]
[PexGeneratedBy(typeof(MathExtensionsTest))]
[ExpectedException(typeof(ArgumentException))]
public void RoundThrowsArgumentException19601()
{
    decimal d;
    d = this.Round(default(decimal), 0, (MidpointRounding)2);
}
    }
}
