// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Diagnostics;
using System.IO;
using System.Reflection;
using Bodoconsult.Test.Test.Helpers;
using Bodoconsult.Test.TestDocumentation;
using NUnit.Framework;

namespace Bodoconsult.Test.Test;

#pragma warning disable CS1591

[TestFixture]
public class DocumentationHandlerTests
{

    private DocumentationHandler _docu;


    [SetUp]
    public void Setup()
    {
        _docu = new DocumentationHandler
        {
            AssemblyDescription = "Testing test documentation",
            AssemblyName = Assembly.GetExecutingAssembly().GetName().Name
        };
    }

    [Test]
    public void TestGetMethodName()
    {
        const string s = nameof(TestGetMethodName);

        Assert.That(s == "TestGetMethodName");
    }

    [Test]
    public void TestStartMethod()
    {
        var s = _docu.StartMethod(GetType());

        Assert.That(s == "TestStartMethod");
    }

    [Test]
    public void TestSuccess()
    {

        const string name = "TestSuccess";

        var s = _docu.StartMethod(GetType());

        Assert.That(s == name);

        s = _docu.MethodSuccess(GetType());

        Assert.That(s == name);

        Assert.That(_docu.TestClasses.Count == 1);
    }

    [Test]
    public void TestCreateReport()
    {
        // Arrange
        var fileName = Path.Combine(TestHelper.TempPath, "testreport.htm");

        if (File.Exists(fileName)) File.Delete(fileName);

        _docu.FileName = fileName;

        const string name = "TestCreateReport";

        var s = _docu.StartMethod(GetType());
        Assert.That(s == name);

        s = _docu.MethodSuccess(GetType());
        Assert.That(s == name);
        Assert.That(_docu.TestClasses.Count == 1);

        // Act
        s = _docu.CreateReport();

        // Assert
        Assert.That(s == fileName);
        Assert.That(File.Exists(fileName));

        if (Debugger.IsAttached)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }


    }

}