﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.DependencyInjection;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.I18N.DependencyInjection;
using Bodoconsult.I18N.Test.Samples;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.DependencyInjection;

internal class I18NDiContainerServiceProviderTests
{


    [Test]
    public void AddServices_DefaultSetup_InstanceLoadedInDiContainer()
    {
        // Arrange 
        var diContainer = new DiContainer();

        var factory = new TestI18NFactory();
        var diProvider = new I18NDiContainerServiceProvider(factory);

        // Act  
        diProvider.AddServices(diContainer);

        diContainer.BuildServiceProvider();

        // Assert
        var instance = diContainer.Get<II18N>();

        Assert.That(instance, Is.Not.Null);
        Assert.That(instance.Providers.Count, Is.Not.EqualTo(0));

        // **** Use it ****
        // change to spanish (not necessary if thread language is ok)
        instance.Locale = "es";

        var translation = instance.Translate("one");
        Assert.That(translation, Is.EqualTo("uno"));

        translation = "Contains".Translate();
        Assert.That(translation, Is.EqualTo("Contains"));

        // Change to english
        instance.Locale = "en";

        translation = instance.Translate("one");
        Assert.That(translation, Is.EqualTo("one"));

        translation = "Contains".Translate();
        Assert.That(translation, Is.EqualTo("Contains"));

    }

}