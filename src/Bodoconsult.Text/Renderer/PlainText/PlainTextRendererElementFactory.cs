// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// <see cref="ITextRendererElementFactory"/> implementation for plain text rendering
/// </summary>
public class PlainTextRendererElementFactory : ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of an <see cref="ITextRendererElement"/> for a given <see cref="TextElement"/>
    /// </summary>
    /// <param name="textElement">Given text element</param>
    /// <returns>Instance of an <see cref="ITextRendererElement"/></returns>
    public ITextRendererElement CreateInstance(DocumentElement textElement)
    {
        // Base elements
        if (textElement is Document document)
        {
            return new DocumentPlainTextRendererElement(document);
        }

        if (textElement is DocumentMetaData documentMetaData)
        {
            return new DocumentMetaDataPlainTextRendererElement(documentMetaData);
        }

        if (textElement is Styleset styleset)
        {
            return new StylesetPlainTextRendererElement(styleset);
        }

        if (textElement is Section section)
        {
            return new SectionPlainTextRendererElement(section);
        }

        if (textElement is TocSection tocSection)
        {
            return new TocSectionPlainTextRendererElement(tocSection);
        }

        if (textElement is ToeSection toeSection)
        {
            return new ToeSectionPlainTextRendererElement(toeSection);
        }

        if (textElement is TofSection tofSection)
        {
            return new TofSectionPlainTextRendererElement(tofSection);
        }

        if (textElement is TotSection totSection)
        {
            return new TotSectionPlainTextRendererElement(totSection);
        }

        // ParagraphBase based elements

        if (textElement is Citation citation)
        {
            return new CitationPlainTextRendererElement(citation);
        }

        if (textElement is Code code)
        {
            return new CodePlainTextRendererElement(code);
        }

        if (textElement is Cell cell)
        {
            return new CellPlainTextRendererElement(cell);
        }

        if (textElement is Column column)
        {
            return new ColumnPlainTextRendererElement(column);
        }

        if (textElement is DefinitionList definitionList)
        {
            return new DefinitionListPlainTextRendererElement(definitionList);
        }

        if (textElement is DefinitionListTerm definitionListTerm)
        {
            return new DefinitionListTermPlainTextRendererElement(definitionListTerm);
        }

        if (textElement is DefinitionListItem definitionListItem)
        {
            return new DefinitionListItemPlainTextRendererElement(definitionListItem);
        }

        if (textElement is Equation equation)
        {
            return new EquationPlainTextRendererElement(equation);
        }

        if (textElement is Error error)
        {
            return new ErrorPlainTextRendererElement(error);
        }

        if (textElement is Figure figure)
        {
            return new FigurePlainTextRendererElement(figure);
        }

        if (textElement is Heading1 heading1)
        {
            return new Heading1PlainTextRendererElement(heading1);
        }

        if (textElement is Heading2 heading2)
        {
            return new Heading2PlainTextRendererElement(heading2);
        }

        if (textElement is Heading3 heading3)
        {
            return new Heading3PlainTextRendererElement(heading3);
        }

        if (textElement is Heading4 heading4)
        {
            return new Heading4PlainTextRendererElement(heading4);
        }

        if (textElement is Heading5 heading5)
        {
            return new Heading5PlainTextRendererElement(heading5);
        }

        if (textElement is Image image)
        {
            return new ImagePlainTextRendererElement(image);
        }

        if (textElement is Info info)
        {
            return new InfoPlainTextRendererElement(info);
        }

        if (textElement is List list)
        {
            return new ListPlainTextRendererElement(list);
        }

        if (textElement is ListItem listItem)
        {
            return new ListItemPlainTextRendererElement(listItem);
        }

        if (textElement is Paragraph paragraph)
        {
            return new ParagraphPlainTextRendererElement(paragraph);
        }

        if (textElement is ParagraphCenter paragraphCenter)
        {
            return new ParagraphCenterPlainTextRendererElement(paragraphCenter);
        }

        if (textElement is ParagraphJustify paragraphJustify)
        {
            return new ParagraphJustifyPlainTextRendererElement(paragraphJustify);
        }

        if (textElement is ParagraphRight paragraphRight)
        {
            return new ParagraphRightPlainTextRendererElement(paragraphRight);
        }

        if (textElement is Row row)
        {
            return new RowPlainTextRendererElement(row);
        }

        if (textElement is SectionSubtitle sectionSubtitle)
        {
            return new SectionSubtitlePlainTextRendererElement(sectionSubtitle);
        }

        if (textElement is SectionTitle sectionTitle)
        {
            return new SectionTitlePlainTextRendererElement(sectionTitle);
        }

        if (textElement is Subtitle subtitle)
        {
            return new SubtitlePlainTextRendererElement(subtitle);
        }

        if (textElement is Table table)
        {
            return new TablePlainTextRendererElement(table);
        }

        if (textElement is Title title)
        {
            return new TitlePlainTextRendererElement(title);
        }

        if (textElement is Toc1 toc1)
        {
            return new Toc1PlainTextRendererElement(toc1);
        }

        if (textElement is Toc2 toc2)
        {
            return new Toc2PlainTextRendererElement(toc2);
        }

        if (textElement is Toc3 toc3)
        {
            return new Toc3PlainTextRendererElement(toc3);
        }

        if (textElement is Toc4 toc4)
        {
            return new Toc4PlainTextRendererElement(toc4);
        }

        if (textElement is Toc5 toc5)
        {
            return new Toc5PlainTextRendererElement(toc5);
        }

        if (textElement is Tof tof)
        {
            return new TofPlainTextRendererElement(tof);
        }

        if (textElement is Toe toe)
        {
            return new ToePlainTextRendererElement(toe);
        }

        if (textElement is Tot tot)
        {
            return new TotPlainTextRendererElement(tot);
        }

        if (textElement is Warning warning)
        {
            return new WarningPlainTextRendererElement(warning);
        }

        // ToDo: add all others

        // Inline based elements
        if (textElement is Span span)
        {
            return new SpanPlainTextRendererElement(span);
        }

        if (textElement is Bold bold)
        {
            return new BoldPlainTextRendererElement(bold);
        }

        if (textElement is Italic italic)
        {
            return new ItalicPlainTextRendererElement(italic);
        }

        if (textElement is LineBreak lineBreak)
        {
            return new LineBreakPlainTextRendererElement(lineBreak);
        }

        if (textElement is Hyperlink hyperlink)
        {
            return new HyperlinkPlainTextRendererElement(hyperlink);
        }

        if (textElement is Value value)
        {
            return new ValuePlainTextRendererElement(value);
        }

        return null;
    }

}