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

using Bodoconsult.App.Abstractions.Interfaces;
using System.Windows.Forms;

namespace Bodoconsult.App.Wpf.AppStarter;

public class WinNotifyRequestRecord : NotifyRequestRecord
{
    /// <summary>
    /// Icon for the notification
    /// </summary>
    public ToolTipIcon Icon { get; set; } = ToolTipIcon.Info;
}