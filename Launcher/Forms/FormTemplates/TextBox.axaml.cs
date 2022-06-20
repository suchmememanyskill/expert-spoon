﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LauncherGamePlugin.Forms;

namespace Launcher.Forms.FormTemplates;

public partial class TextBox : UserControl
{
    public TextBox()
    {
        InitializeComponent();
    }

    public TextBox(FormEntry entry) : this()
    {
        TextBlock.Text = entry.Name;
        if (!string.IsNullOrWhiteSpace(entry.Value))
            TextBlock.FontWeight = (FontWeight)Enum.Parse(typeof(FontWeight), entry.Value);
    }
    
}