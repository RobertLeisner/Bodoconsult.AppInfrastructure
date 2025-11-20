// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using System.Reflection;
using Bodoconsult.Test.MetaData.Handler;
using Bodoconsult.Test.Test.Models;
using NUnit.Framework;

namespace Bodoconsult.Test.Test;

[TestFixture]
#pragma warning disable 1591
public class MetaDataHandlerTests
{
    //private string Path = System.IO.Path.Combine(TestHelper.TempPath, "MetaDataText.txt");

    private readonly Assembly _assembly = Assembly.GetExecutingAssembly();


    [Test]
    public void TestLoadAssemblies()
    {

        var mh = new MetaDataHandler();

        mh.LoadReferencedAssemblies(_assembly);
        mh.LoadAssembly(_assembly);

        Assert.That(mh.Documentation.Count>0);
        Assert.That(mh.Documentation[0].Documentation != null);
    }


    [Test]
    public void TestAddTypeBaseClass()
    {

        var mh = new MetaDataHandler();

        mh.LoadReferencedAssemblies(_assembly);
        mh.LoadAssembly(_assembly);

        mh.AddType(typeof(BaseClass));

        Assert.That(mh.TypeMetaDatas.Count == 1);
        Assert.That(mh.TypeMetaDatas[0].TypeItemMetaDatas.Count == 1);

        ShowData(mh);
    }

    [Test]
    public void TestAddTypeDerivedClass()
    {

        var mh = new MetaDataHandler();

        mh.LoadReferencedAssemblies(_assembly);
        mh.LoadAssembly(_assembly);

        mh.AddType(typeof(DerivedClass));

        Assert.That(mh.TypeMetaDatas.Count==1);
        Assert.That(mh.TypeMetaDatas[0].TypeItemMetaDatas.Count == 2);

        ShowData(mh);
    }


    [Test]
    public void TestAddTypeDerivedClass2()
    {

        var mh = new MetaDataHandler();

        mh.LoadReferencedAssemblies(_assembly);
        mh.LoadAssembly(_assembly);

        mh.AddType(typeof(DerivedClass2));

        Assert.That(mh.TypeMetaDatas.Count == 1);
        Assert.That(mh.TypeMetaDatas[0].TypeItemMetaDatas.Count == 3);

        ShowData(mh);
    }

    private static void ShowData( MetaDataHandler mh)
    {
        var item = mh.TypeMetaDatas[0];

        Assert.That(item.Summary, Is.Not.Null);

        Debug.Print(item.FullName);
        Debug.Print(item.Summary);

        foreach (var prop in mh.TypeMetaDatas[0].TypeItemMetaDatas)
        {
            Debug.Print($"\t{prop.Name}");
            Debug.Print($"\t\t{prop.Summary}");
            Assert.That(prop.Summary, Is.Not.Null);
        }
    }
}