// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Crypto.Hashing;

public interface IPasswordHasher
{
    string Hash(string password);

    (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
}