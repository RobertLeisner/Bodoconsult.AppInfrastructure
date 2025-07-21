// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.DataProtection;
using Bodoconsult.App.Test.App;
using Bodoconsult.App.Test.TestData;

namespace Bodoconsult.App.Test.DataProtection;

[TestFixture]
internal class EntityProtectionServiceTests
{
    private readonly EntityProtectionService _entityProtectionService;

    protected const string AppName = "MyAppEps";

    public EntityProtectionServiceTests()
    {
        var path = Globals.Instance.AppStartParameter.DataPath;
        var dataProtectionService = DataProtectionService.CreateInstance(path, AppName);
        _entityProtectionService = new EntityProtectionService(dataProtectionService);
    }


    [Test]
    public void Protect_MultipleSecrets_PropsWithDataProtectionSecretAttributeProtected()
    {
        // Arrange 
        const string secret = "Secret";
        const string secret2 = "Secret2";
        const string name = "BlubbEps1";

        var entity = new EntityWithSecrets
        {
            Name = name,
            Secret = secret,
            Secret2 = secret2
        };

        // Act  
        _entityProtectionService.Protect(entity);

        // Assert
        Assert.That(entity.Name, Is.EqualTo(name));
        Assert.That(entity.Secret, Is.Not.EqualTo(secret));
        Assert.That(entity.Secret2, Is.Not.EqualTo(secret2));
        Assert.That(entity.Secret, Is.Not.EqualTo(entity.Secret2));

    }

    [Test]
    public void Unprotect_MultipleSecrets_PropsWithDataProtectionSecretAttributeProtected()
    {
        // Arrange 
        const string secret = "Secret";
        const string secret2 = "Secret2";
        const string name = "BlubbEps2";

        var entity = new EntityWithSecrets
        {
            Name = name,
            Secret = secret,
            Secret2 = secret2
        };

        _entityProtectionService.Protect(entity);

        Assert.That(entity.Name, Is.EqualTo(name));
        Assert.That(entity.Secret, Is.Not.EqualTo(secret));
        Assert.That(entity.Secret2, Is.Not.EqualTo(secret2));
        Assert.That(entity.Secret, Is.Not.EqualTo(entity.Secret2));

        // Act  
        _entityProtectionService.Unprotect(entity);

        // Assert
        Assert.That(entity.Name, Is.EqualTo(name));
        Assert.That(entity.Secret, Is.EqualTo(secret));
        Assert.That(entity.Secret2, Is.EqualTo(secret2));

    }

    [Test]
    public void Protect_MultipleSecretsWithUid_PropsWithDataProtectionSecretAttributeProtected()
    {
        // Arrange 
        const string secret = "Secret";
        const string secret2 = "Secret2";
        var uid = Guid.NewGuid();

        var entity = new EntityWithUidWithSecrets
        {
            Uid = uid,
            Secret = secret,
            Secret2 = secret2
        };

        // Act  
        _entityProtectionService.Protect(entity);

        // Assert
        Assert.That(entity.Uid, Is.EqualTo(uid));
        Assert.That(entity.Secret, Is.Not.EqualTo(secret));
        Assert.That(entity.Secret2, Is.Not.EqualTo(secret2));
        Assert.That(entity.Secret, Is.Not.EqualTo(entity.Secret2));
    }

    [Test]
    public void Unprotect_MultipleSecretsWithUid_PropsWithDataProtectionSecretAttributeProtected()
    {
        // Arrange 
        const string secret = "Secret";
        const string secret2 = "Secret2";
        var uid = Guid.NewGuid();

        var entity = new EntityWithUidWithSecrets
        {
            Uid = uid,
            Secret = secret,
            Secret2 = secret2
        };

        _entityProtectionService.Protect(entity);

        Assert.That(entity.Uid, Is.EqualTo(uid));
        Assert.That(entity.Secret, Is.Not.EqualTo(secret));
        Assert.That(entity.Secret2, Is.Not.EqualTo(secret2));
        Assert.That(entity.Secret, Is.Not.EqualTo(entity.Secret2));

        // Act  
        _entityProtectionService.Unprotect(entity);

        // Assert
        Assert.That(entity.Uid, Is.EqualTo(uid));
        Assert.That(entity.Secret, Is.EqualTo(secret));
        Assert.That(entity.Secret2, Is.EqualTo(secret2));
    }

}