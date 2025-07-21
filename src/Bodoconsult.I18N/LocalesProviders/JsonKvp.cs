// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Text.Json.Serialization;

namespace Bodoconsult.I18N.LocalesProviders;

public class JsonKvp
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}