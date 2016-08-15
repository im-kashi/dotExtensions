using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="MathExtensionsTest.Abs03.g.cs">Copyright ©  2016</copyright>
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
public void Abs03199()
{
    long l;
    l = this.Abs03(-9223372036854775807L);
}

[TestMethod]
[PexGeneratedBy(typeof(MathExtensionsTest))]
[ExpectedException(typeof(OverflowException))]
public void Abs03ThrowsOverflowException95301()
{
    long l;
    l = this.Abs03(long.MinValue);
}
    }
}
