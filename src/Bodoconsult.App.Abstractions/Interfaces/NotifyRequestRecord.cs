// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

/*
 * Copyright 2021 Kazuhiro Fujieda <fujieda@roundwide.com>

   Permission to use, copy, modify, and/or distribute this software for any
   purpose with or without fee is hereby granted.

   THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH
   REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY
   AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,
   INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM
   LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR
   OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR
   PERFORMANCE OF THIS SOFTWARE.
 */

//using System.Windows.Forms;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Request record for a TOAST notification
/// </summary>
public class NotifyRequestRecord
{
    /// <summary>
    /// Notification title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Notification text
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Duration of showing the notification in ms
    /// </summary>
    public int Duration { get; set; } = 1000;


    //public ToolTipIcon Icon { get; set; } = ToolTipIcon.Info;
}