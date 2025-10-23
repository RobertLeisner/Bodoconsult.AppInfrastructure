// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using Bodoconsult.Text.Documents;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents.Inlines;

[TestFixture]
internal class LineBreakTests
{

    [Test]
    public void AddBlock_Span_ThrowsArgumentException()
    {
        // Arrange 
        var lb = new LineBreak();

        var span = new Span();

        // Act  
        Assert.Throws<ArgumentException>(() =>
        {
            lb.AddInline(span);
        });

        // Assert
        Assert.That(lb.ChildInlines.Count, Is.EqualTo(0));
    }

    // ToDo: Add test for Bold, Italic, ... 
}