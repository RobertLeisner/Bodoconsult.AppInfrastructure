﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System.Net.Sockets;
using System.Text;
using Bodoconsult.App.Delegates;

namespace Bodoconsult.App.DataProtection;


public class DataProtectionManager : IDataProtectionManager
{
    /// <summary>
    /// File path to save the values in. Public only for testing
    /// </summary>
    public string FilePath;


    private readonly ProducerConsumerQueue<object> _saveValuesRequestQueue = new();

    private readonly List<KeyValuePair<string, string>> _values = new();


    public DataProtectionManager(IDataProtectionService dataProtectionService, IFileProtectionService fileProtectionService, string filePath)
    {
        DataProtectionService = dataProtectionService;
        FileProtectionService = fileProtectionService;
        FilePath = filePath;

        _saveValuesRequestQueue.ConsumerTaskDelegate = ConsumerTaskDelegate;
        _saveValuesRequestQueue.StartConsumer();
    }

    private void ConsumerTaskDelegate(object clientNotification)
    {
        SaveValues();
    }


    /// <summary>
    /// Delegate to read a string input from console, UI, etc.
    /// </summary>
    /// <returns>Read string input</returns>
    public ReadStringDelegate ReadStringDelegate { get; set; }

    /// <summary>
    /// Current values to protect
    /// </summary>
    public List<KeyValuePair<string, string>> Values => _values.ToList();

    /// <summary>
    /// Available keys
    /// </summary>
    public List<string> Keys => _values.Select(x=> x.Key).ToList();

    /// <summary>
    /// Current instance of <see cref="IDataProtectionService"/> to use
    /// </summary>
    public IDataProtectionService DataProtectionService { get; }

    public IFileProtectionService FileProtectionService { get; }

    /// <summary>
    /// Save the values to storage
    /// </summary>
    public void SaveValues()
    {
        if (_values.Any(x => string.IsNullOrEmpty(x.Value)))
        {
            //throw new ArgumentException("Not all keys have a valid value set: saving values was denied!");
            return;
        }

        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }

        var json = System.Text.Json.JsonSerializer.Serialize(_values);

        var data = FileProtectionService.Protect(Encoding.UTF8.GetBytes(json)) ;

        File.WriteAllBytes(FilePath, data);
    }

    /// <summary>
    /// Load the values from storage
    /// </summary>
    public void LoadValues()
    {
        if (!File.Exists(FilePath))
        {
            return;
        }

        var data = File.ReadAllBytes(FilePath);

        var json = FileProtectionService.Unprotect(data);

        var result = System.Text.Json.JsonSerializer.Deserialize<List<KeyValuePair<string, string>>>(json);

        ClearAll();
        _values.AddRange(result);
    }

    /// <summary>
    /// Load the values the first time from console, UI, etc.. Overrides existing secrets file.
    /// </summary>
    public void AskForInitialLoadValues()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }

        foreach (var key in Keys)
        {
            var secret = ReadStringDelegate($"Please insert value for key '{key}': ");

            if (string.IsNullOrEmpty(secret))
            {
                return;
            }

            Protect(key, secret, true);
        }

        _saveValuesRequestQueue.Enqueue(new object());

    }

    /// <summary>
    /// Clear the loaded values
    /// </summary>
    public void ClearAll()
    {
        _values.Clear();
    }

    /// <summary>
    /// Add a key required for the current app
    /// </summary>
    /// <param name="key">Key to be added</param>
    public void AddKey(string key)
    {
        _values.Add(new KeyValuePair<string, string>(key, null));
    }

    /// <summary>
    /// Protect a secret
    /// </summary>
    /// <param name="key">Unique key to use for the secret</param>
    /// <param name="secret">Secret to store</param>
    public void Protect(string key, string secret)
    {
        Protect(key, secret, false);
    }

    /// <summary>
    /// Protect a secret
    /// </summary>
    /// <param name="key">Unique key to use for the secret</param>
    /// <param name="secret">Secret to store</param>
    /// <param name="doNotSave">Do NOT save the values to file. Default: false</param>
    public void Protect(string key, string secret, bool doNotSave)
    {
        var kvp = _values.FirstOrDefault(x => x.Key.Equals(key));

        var cipher = DataProtectionService.Protect(key, secret);

        if (kvp is not { Key: null })
        {
            _values.RemoveAll(x => x.Key == kvp.Key);
        }

        kvp = new KeyValuePair<string, string>(key, cipher);
        _values.Add(kvp);

        if (doNotSave)
        {
            return;
        }
        _saveValuesRequestQueue.Enqueue(new object());
    }

    /// <summary>
    /// Unprotect a secret by its key
    /// </summary>
    /// <param name="key">Key the secret was stored with</param>
    /// <returns>Secret or null if the key does not exist</returns>
    public string Unprotect(string key)
    {
        var kvp = _values.FirstOrDefault(x => x.Key.Equals(key));

        if (kvp is { Key: null })
        {
            return null;
        }

        var secret = DataProtectionService.Unprotect(key, kvp.Value);
        return secret;

    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        _saveValuesRequestQueue.StopConsumer();
        _saveValuesRequestQueue?.Dispose();
    }


}