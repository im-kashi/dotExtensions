using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
// <copyright file="CollectionExtensionsTest.IsNullOrEmpty.g.cs">Copyright ©  2016</copyright>
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
    public partial class CollectionExtensionsTest {

[TestMethod]
[PexGeneratedBy(typeof(CollectionExtensionsTest))]
public void IsNullOrEmpty71()
{
    bool b;
    int[] ints = new int[0];
    b = this.IsNullOrEmpty<int>((ICollection<int>)ints);
}

[TestMethod]
[PexGeneratedBy(typeof(CollectionExtensionsTest))]
public void IsNullOrEmpty292()
{
    bool b;
    b = this.IsNullOrEmpty<int>((ICollection<int>)null);
}
    }
}
