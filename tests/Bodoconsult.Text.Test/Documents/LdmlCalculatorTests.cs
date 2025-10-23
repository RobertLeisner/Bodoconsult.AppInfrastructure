// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
public class LdmlCalculatorTests
{
    [Test]
    public void Ctor_ValidDocument_PropsSetCorrectly()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();

        // Act  
        var lc = new LdmlCalculator(doc);

        // Assert
        Assert.That(lc.Document, Is.Not.Null);
        Assert.That(lc.Figures, Is.Not.Null);
        Assert.That(lc.FigureCounter, Is.EqualTo(0));
        Assert.That(lc.Equations, Is.Not.Null);
        Assert.That(lc.EquationCounter, Is.EqualTo(0));
        Assert.That(lc.ToeItems, Is.Not.Null);
        Assert.That(lc.TofItems, Is.Not.Null);

        PrintDoc(doc);

    }

    [Test]
    public void EnumerateAllItemsForToe_ValidDocument_EquationsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        // Act  
        lc.EnumerateAllItemsForToe();

        // Assert
        Assert.That(lc.Document, Is.Not.Null);
        Assert.That(lc.Equations.Count, Is.Not.EqualTo(0));
        Assert.That(lc.EquationCounter, Is.Not.EqualTo(0));

        var eq = lc.Equations[0];

        Assert.That(eq.CurrentPrefix.Length, Is.Not.EqualTo(0));
        Assert.That(eq.TagName.Length, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareAllItemsForToe_ValidDocument_EquationsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForToe();

        // Act  
        lc.PrepareAllItemsForToe();

        // Assert
        Assert.That(lc.ToeItems.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void EnumerateAllItemsForTof_ValidDocument_FiguresLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        // Act  
        lc.EnumerateAllItemsForTof();

        // Assert
        Assert.That(lc.Document, Is.Not.Null);
        Assert.That(lc.Figures.Count, Is.Not.EqualTo(0));
        Assert.That(lc.FigureCounter, Is.Not.EqualTo(0));

        var eq = lc.Figures[0];

        Assert.That(eq.CurrentPrefix.Length, Is.Not.EqualTo(0));
        Assert.That(eq.TagName.Length, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void EnumerateAllItemsForTot_ValidDocument_FiguresLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        // Act  
        lc.EnumerateAllItemsForTot();

        // Assert
        Assert.That(lc.Document, Is.Not.Null);
        Assert.That(lc.Tables.Count, Is.Not.EqualTo(0));
        Assert.That(lc.TableCounter, Is.Not.EqualTo(0));

        var eq = lc.Tables[0];

        Assert.That(eq.CurrentPrefix.Length, Is.Not.EqualTo(0));
        Assert.That(eq.TagName.Length, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareAllItemsForTof_ValidDocument_FiguresLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForTof();

        // Act  
        lc.PrepareAllItemsForTof();

        // Assert
        Assert.That(lc.TofItems.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareAllItemsForToc_ValidDocument_TocLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForToc();

        // Act  
        lc.PrepareAllItemsForToc();

        // Assert
        Assert.That(lc.TocItems.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
        
    }

    [Test]
    public void PrepareAllItemsForTot_ValidDocument_FiguresLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForTot();

        // Act  
        lc.PrepareAllItemsForTot();

        // Assert
        Assert.That(lc.TotItems.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareTotSection_ValidDocument_ItemsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForTot();

        lc.PrepareAllItemsForTot();

        // Act  
        lc.PrepareTotSection();

        // Assert
        Assert.That(doc.TotSection.ChildBlocks.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareTofSection_ValidDocument_ItemsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForTof();

        lc.PrepareAllItemsForTof();

        // Act  
        lc.PrepareTofSection();

        // Assert
        Assert.That(doc.TofSection.ChildBlocks.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareTocSection_ValidDocument_ItemsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForToc();

        lc.PrepareAllItemsForToc();

        // Act  
        lc.PrepareTocSection();

        // Assert
        Assert.That(doc.TocSection.ChildBlocks.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    [Test]
    public void PrepareToeSection_ValidDocument_ItemsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        lc.EnumerateAllItemsForToe();

        lc.PrepareAllItemsForToe();

        // Act  
        lc.PrepareToeSection();

        // Assert
        Assert.That(doc.ToeSection.ChildBlocks.Count, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

    private void PrintDoc(Document doc)
    {
        if (!Debugger.IsAttached)
        {
            return;
        }

        var sb = new StringBuilder();
        doc.ToLdmlString(sb, string.Empty);
        Debug.Print(sb.ToString());
    }

    [Test]
    public void EnumerateAllItemsForToc_ValidDocument_HeadingsLoaded()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        var lc = new LdmlCalculator(doc);

        // Act  
        lc.EnumerateAllItemsForToc();

        // Assert
        Assert.That(lc.Document, Is.Not.Null);
        Assert.That(lc.Headings.Count, Is.Not.EqualTo(0));
        //Assert.That(lc.Counter, Is.Not.EqualTo(0));

        var eq = lc.Headings[0];

        Assert.That(eq.CurrentPrefix.Length, Is.Not.EqualTo(0));
        Assert.That(eq.TagName.Length, Is.Not.EqualTo(0));

        PrintDoc(doc);
    }

}