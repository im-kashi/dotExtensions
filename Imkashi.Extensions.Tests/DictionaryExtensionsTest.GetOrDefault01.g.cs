using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
// <copyright file="DictionaryExtensionsTest.GetOrDefault01.g.cs">Copyright ©  2016</copyright>
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
    public partial class DictionaryExtensionsTest {

[TestMethod]
[PexGeneratedBy(typeof(DictionaryExtensionsTest))]
[ExpectedException(typeof(ArgumentNullException))]
public void GetOrDefault01ThrowsArgumentNullException834()
{
    int i;
    i = this.GetOrDefault01<int, int>
            ((IReadOnlyDictionary<int, int>)null, 0, (Func<int, int>)null);
}

[TestMethod]
[PexGeneratedBy(typeof(DictionaryExtensionsTest))]
[ExpectedException(typeof(ArgumentNullException))]
public void GetOrDefaultThrowsArgumentNullException411()
{
    int i;
    i = this.GetOrDefault<int, int>((IReadOnlyDictionary<int, int>)null, 0, 0);
}
    }
}
