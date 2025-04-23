// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.I18N
{
    public class PortableLanguage
    {
        public string Locale { get; set; }
        public string DisplayName { get; set; }
        public override string ToString() => DisplayName;
    }
}