// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Test.TestData;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
internal class DocumentFactoryBaseTests
{

    [Test]
    public void Ctor_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 

        // Act  
        var report = new TestReportFactory();

        // Assert
        Assert.That(report.Document, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Null);
    }

    [Test]
    public void CreateNewSection_ValidSetup_SectionCreatedAndLoaded()
    {
        // Arrange 
        var report = new TestReportFactory();

        // Act  
        report.CreateNewSection("Body");

        // Assert
        Assert.That(report.Document, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);
    }

    [Test]
    public void LoadDocumentMetaData_ValidSetup_MetaDataLoaded()
    {
        // Arrange 
        var report = new TestReportFactory();
        var metaData = new DocumentMetaData();

        // Act  
        report.LoadDocumentMetaData(metaData);

        // Assert
        Assert.That(report.DocumentMetaData, Is.Not.Null);
        Assert.That(report.DocumentMetaData, Is.EqualTo(metaData));
    }

    [Test]
    public void LoadStyleset_ValidSetup_StyleSetLoaded()
    {
        // Arrange 
        var report = new TestReportFactory();
        var styleset = StylesetHelper.CreateDefaultStyleset();

        // Act  
        report.LoadStyleset(styleset);

        // Assert
        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.Styleset, Is.EqualTo(styleset));
    }

    [Test]
    public void PrepareTheDocument_ValidSetup_MetadataAndStyleSetLoadedBodySectionCreated()
    {
        // Arrange 
        var report = new TestReportFactory();

        // Act  
        report.PrepareTheDocument();

        // Assert
        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(report.Document.ChildBlocks.Count, Is.EqualTo(3));
        Assert.That(report.Document.ChildBlocks[0].GetType(), Is.EqualTo(typeof(DocumentMetaData)));
        Assert.That(report.Document.ChildBlocks[1].GetType(), Is.EqualTo(typeof(Styleset)));
        Assert.That(report.Document.ChildBlocks[2].GetType(), Is.EqualTo(typeof(Section)));
    }

    [Test]
    public void AddHeading_Level1_Heading1Added()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddHeading(HeadingLevel.Level1, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Heading1)));
    }

    [Test]
    public void AddHeading_Level2_Heading2Added()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddHeading(HeadingLevel.Level2, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Heading2)));
    }

    [Test]
    public void AddHeading_Level3_Heading3Added()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddHeading(HeadingLevel.Level3, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Heading3)));
    }

    [Test]
    public void AddHeading_Level4_Heading4Added()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddHeading(HeadingLevel.Level4, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Heading4)));
    }

    [Test]
    public void AddHeading_Level5_Heading5Added()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddHeading(HeadingLevel.Level5, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Heading5)));
    }

    [Test]
    public void AddParagraph_Paragraph_ParagraphAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Paragraph, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Paragraph)));
    }

    [Test]
    public void AddParagraph_Citation_CitationAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Citation, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Citation)));
    }

    [Test]
    public void AddParagraph_Code_CodeAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Code, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Code)));
    }

    [Test]
    public void AddParagraph_Center_CenterAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.ParagraphCenter, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(ParagraphCenter)));
    }

    [Test]
    public void AddParagraph_Right_RightAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.ParagraphRight, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(ParagraphRight)));
    }

    [Test]
    public void AddParagraph_Justify_JustifyAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.ParagraphJustify, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(ParagraphJustify)));
    }



    [Test]
    public void AddParagraph_Info_InfoAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Info, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Info)));
    }

    [Test]
    public void AddParagraph_Error_ErrorAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Error, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Error)));
    }

    [Test]
    public void AddParagraph_Warning_WarningAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Warning, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Warning)));
    }

    [Test]
    public void AddParagraph_Titel_TitelAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.Title, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Title)));
    }

    [Test]
    public void AddParagraph_Subtitel_SubtitelAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.SubTitle, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(Subtitle)));
    }

    [Test]
    public void AddParagraph_SectionTitel_SectionTitelAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.SectionTitle, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(SectionTitle)));
    }

    [Test]
    public void AddParagraph_SectionSubtitel_SectionSubtitelAdded()
    {
        // Arrange 
        var report = new TestReportFactory();
        report.PrepareTheDocument();

        // Act  
        report.AddParagraph(ParagraphType.SectionSubtitle, "Blubb");

        // Assert
        var section = report.Document.ChildBlocks[2] as Section;
        Assert.That(section, Is.Not.Null);

        Assert.That(report.Styleset, Is.Not.Null);
        Assert.That(report.CurrentSection, Is.Not.Null);

        Assert.That(section.ChildBlocks.Count, Is.EqualTo(1));
        Assert.That(section.ChildBlocks[0].GetType(), Is.EqualTo(typeof(SectionSubtitle)));
    }


}