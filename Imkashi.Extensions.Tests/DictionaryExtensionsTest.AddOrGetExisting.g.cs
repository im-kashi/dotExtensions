using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
public void AddOrGetExistingThrowsArgumentNullException293()
{
    int i;
    i = this.AddOrGetExisting<int, int>((IDictionary<int, int>)null, 0, 0);
}
    }
}
