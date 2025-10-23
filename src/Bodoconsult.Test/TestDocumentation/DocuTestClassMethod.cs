// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Text;

namespace Bodoconsult.Test.TestDocumentation;

/// <summary>
/// Represents the docu for test class
/// </summary>
public class DocuTestClassMethod : IHtmlCreator
{
    /// <summary>
    /// Method name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Parent test class
    /// </summary>
    public DocuTestClass Parent { get; set; }

    /// <summary>
    /// Test was successful?
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Test class description: should address documentation receivers, not software developer
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The priority of a test as importance for the whole
    /// </summary>
    public TestPriority TestPriority { get; set; }

    /// <summary>
    /// Create a report as an HTML string in a short version
    /// </summary>
    /// <returns>HTML string</returns>
    public StringBuilder ToHtmlString()
    {
        var result = new StringBuilder();

        result.AppendLine($"<p>{Name}: {(Success ? "successful" : "failed")}</p>");


        if (TestPriority != TestPriority.Normal)
        {
            result.AppendLine($"<p class=\"margin\">Test priority: {TestPriority}</p>");
        }

        if (string.IsNullOrEmpty(Description))
        {
            return result;
        }

        if (!Description.EndsWith("."))
        {
            Description += ".";
        }

        result.AppendLine($"<p class=\"margin\">{Description}</p>");

        return result;
    }

    /// <summary>
    /// Create a report as an HTML string in a longer, more detailled version
    /// </summary>
    /// <returns>HTML string</returns>
    public StringBuilder ToHtmlStringLong()
    {
        var result = new StringBuilder();

        result.AppendLine($"<p>{Parent.Name}.{Name}: {(Success ? "successful" : "failed")}</p>");


        if (TestPriority != TestPriority.Normal)
        {
            result.AppendLine($"<p class=\"margin\">Test priority: {TestPriority}</p>");
        }

        if (string.IsNullOrEmpty(Description))
        {
            return result;
        }

        if (!Description.EndsWith("."))
        {
            Description += ".";
        }

        result.AppendLine($"<p class=\"margin\">{Description}</p>");

        return result;
    }

    /// <summary>
    /// Mark method as successful
    /// </summary>
    public void MethodSuccess()
    {
        Success = true;

        if (TestPriority == TestPriority.IgnoreIfError)
        {
            Parent.DocuHandler.NumberOfTests++;
        }

        if (Parent.TestPriority != TestPriority.Ignore && TestPriority != TestPriority.Ignore)
        {
            Parent.DocuHandler.NumberOfTestsSuccess++;
        }
    }
}