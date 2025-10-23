// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Pdf.Extensions;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Pdf.Test;

[TestFixture]
public class DataTableExtensionsTests
{

    [Test]
    public void ToPdfTable_ValidDataTable_PdfTableCreated()
    {
        // Arrange 
        var dt = DataHelper.GetSmallDataTable();

        // Act  
        var result = dt.ToPdfTable();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(dt.Columns.Count));
        Assert.That(result.Rows.Count, Is.EqualTo(dt.Rows.Count));

        foreach (var row in result.Rows)
        {
            Assert.That(row.Cells.Count, Is.EqualTo(dt.Columns.Count));
        }
    }

}