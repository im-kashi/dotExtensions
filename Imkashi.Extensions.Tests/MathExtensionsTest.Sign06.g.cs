using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="MathExtensionsTest.Sign06.g.cs">Copyright ©  2016</copyright>
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
public void Sign06732()
{
    int i;
    i = this.Sign06((float)0);
}

[TestMethod]
[PexGeneratedBy(typeof(MathExtensionsTest))]
[ExpectedException(typeof(ArithmeticException))]
public void Sign06ThrowsArithmeticException29701()
{
    int i;
    i = this.Sign06((float)double.NaN);
}
    }
}
