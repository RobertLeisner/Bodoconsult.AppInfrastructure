// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using NUnit.Framework;

namespace Bodoconsult.I18N.Test;

/// <summary>
/// Base class for related I18N tests
/// </summary>
[TestFixture]
public abstract class BaseTests
{
    [SetUp]
    public void Init()
    {
        //I18N.Current = new I18N();
        I18N.Current.Reset();
    }


    [TearDown]
    public void Finish() =>
        I18N.Current?.Dispose();
}