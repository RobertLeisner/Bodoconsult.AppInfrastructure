// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Delegates;

/// <summary>
/// Request application stop delegate
/// </summary>

public delegate void RequestApplicationStopDelegate();

/// <summary>
/// A delegate for "status message" method calls getting a string a input parameter
/// </summary>
/// <param name="message">Input string</param>
public delegate void StatusMessageDelegate(string message);

/// <summary>
/// Delegate fired if the app finds no valid license
/// </summary>
/// <param name="message"></param>
public delegate void LicenseMissingDelegate(string message);

/// <summary>
/// Delegate called if a fatale app exception has been raised and a message to the UI has to be sent before app terminates
/// </summary>
/// <param name="e"></param>
/// <returns>A string to shown to the user on UI before app terminates</returns>
public delegate string HandleFatalExceptionDelegate(Exception e);

/// <summary>
/// Delegate for a method creating a business transaction
/// </summary>
/// <returns>The requested business transaction</returns>
public delegate BusinessTransaction CreateBusinessTransactionDelegate();


/// <summary>
/// Run a business transaction
/// </summary>
/// <param name="requestData">Request data</param>
/// <returns>A buiness action reply</returns>

public delegate IBusinessTransactionReply RunBusinessTransactionDelegate(IBusinessTransactionRequestData requestData);

/// <summary>
/// A delegate for converting a notification to the target object to transfer to the client
/// </summary>
/// <param name="notification">Current notification</param>
/// <returns>Target object to transfer to the client</returns>
public delegate object NotificationToTargetTransferObjectDelegate(IClientNotification notification);
