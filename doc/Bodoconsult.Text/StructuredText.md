Using StructuredText class for document creation
===================================

Structured text is a simplified version of handling structured text documents compared to DocumentBuilder class. It is kept mainly for compatibilty reasons.

Define your StructuredText instance as required and then let a ITextFormatter instance do its work and produce the requsted output like plain text, HTML or PDF.

# Export as HTML without template (HtmlTextFormatter class)

``` csharp
var sr = new StructuredText();
sr.AddHeader1("Überschrift 1 '& &&&' ");
sr.AddParagraph(MassText, "CssTestFixture");
sr.AddDefinitionListLine("Def1", "Value1");
sr.AddDefinitionListLine("Definition 2", "Value1234");
sr.AddDefinitionListLine("Defini 3", "Value234556666");
sr.AddParagraph(string.Empty);

sr.AddParagraph(FormattedMasstext, "CssTestFixture");

sr.AddCode(MassText, "CssTestFixture");

sr.AddParagraph(MassText);

sr.AddListItem("Bahnhof");
sr.AddListItem("HauptBahnhof");
sr.AddListItem("SüdBahnhof");
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);

var f = new HtmlTextFormatter { StructuredText = sr };
f.GetFormattedText();

f.SaveAsFile(fileName);
```

# Export as HTML with a individual template (HtmlTextFormatter class)

``` csharp
var sr = new StructuredText();
sr.AddHeader1("Überschrift 'Databanka'");
sr.AddParagraph(MassText);
sr.AddDefinitionListLine("Def1", "Value1");
sr.AddDefinitionListLine("Definition 2", "Value1234");
sr.AddDefinitionListLine("Defini 3", "Value234556666");
sr.AddParagraph(string.Empty);
sr.AddParagraph(MassText);

sr.AddListItem("Bahnhof");
sr.AddListItem("HauptBahnhof");
sr.AddListItem("SüdBahnhof");
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader2("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);

var f = new HtmlTextFormatter
{
    StructuredText = sr,
    Template = "<<<Start>>>{0}<<<Ende>>>",
    AddTableOfContent = true
};
var result = f.GetFormattedText();

f.SaveAsFile(fileName);
```

# Export as plain ASCII file (PlainTextFormatter class)

``` csharp
var sr = new StructuredText();
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddDefinitionListLine("Def1", "Value1");
sr.AddDefinitionListLine("Definition 2", "Value1234");
sr.AddDefinitionListLine("Defini 3", "Value234556666");
sr.AddParagraph(string.Empty);
sr.AddParagraph(MassText);

sr.AddListItem("Bahnhof");
sr.AddListItem("HauptBahnhof");
sr.AddListItem("SüdBahnhof");

sr.AddHeader1("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 2");
sr.AddParagraph(MassText);
sr.AddHeader1("Überschrift 1");
sr.AddParagraph(MassText);
sr.AddParagraph(MassText);

var f = new PlainTextFormatter { StructuredText = sr };
var result = f.GetFormattedText();

f.SaveAsFile(fileName);
```

# Export as PDF (PdfTextFormatter class)

``` csharp
var st = new StructuredText();

st.AddHeader1("Überschrift 1");

st.AddParagraph(TestHelper.Masstext1);

var code = FileHelper.GetTextResource("code1.txt");

st.AddCode(code);

st.AddParagraph(TestHelper.Masstext1);

st.AddDefinitionListLine("Left1", "Right1");
st.AddDefinitionListLine("Left2", "Right2");
st.AddDefinitionListLine("Left3", "Right3");
st.AddDefinitionListLine("Left4", "Right4");

st.AddParagraph(TestHelper.Masstext1);

st.AddTable("Tabelle", TestHelper.GetDataTable());

st.AddHeader1("Überschrift 2");

st.AddDefinitionListLine("Left1", "Right1");
st.AddDefinitionListLine("Left2", "Right2");
st.AddDefinitionListLine("Left3", "Right3");
st.AddDefinitionListLine("Left4", "Right4");

var f = new PdfTextFormatter
{
    Title = "Testreport",
    StructuredText = st,
    DateString = $"Date created: {DateTime.Now:G}",
    Author = "Testautor"

};
f.GetFormattedText();
f.SaveAsFile(fileName);
```

# About us

Bodoconsult (<http://www.bodoconsult.de>) is a Munich based software company.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.
