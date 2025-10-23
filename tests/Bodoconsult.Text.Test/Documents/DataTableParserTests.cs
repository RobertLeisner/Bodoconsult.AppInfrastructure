// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
internal class DataTableParserTests
{
    [Test]
    public void Ctor_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        var dt = DataHelper.GetDataTable();

        // Act  
        var dtp = new DataTableParser(dt);

        // Assert
        Assert.That(dtp.DataTable, Is.Not.Null);
        Assert.That(dtp.Table, Is.Not.Null);
        Assert.That(dtp.Table.Columns, Is.Not.Null);
    }

    [Test]
    public void ParseColumns_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        var dt = DataHelper.GetDataTable();

        var dtp = new DataTableParser(dt);

        // Act  
        dtp.ParseColumns();

        // Assert
        Assert.That(dtp.Table.Columns.Count, Is.Not.EqualTo(0));
    }

    [Test]
    public void ParseRows_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        var dt = DataHelper.GetDataTable();

        var dtp = new DataTableParser(dt);
        dtp.ParseColumns();

        // Act  
        dtp.ParseRows();

        // Assert
        Assert.That(dtp.Table.Columns.Count, Is.Not.EqualTo(0));

        var sb = new StringBuilder();
        dtp.Table.ToLdmlString(sb, string.Empty);
        Debug.Print(sb.ToString());
    }

}