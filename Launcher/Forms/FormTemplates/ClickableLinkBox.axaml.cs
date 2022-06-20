﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Launcher.Utils;
using LauncherGamePlugin.Forms;

namespace Launcher.Forms.FormTemplates;

public partial class ClickableLinkBox : UserControl
{
    private FormEntry _formEntry;
    
    public ClickableLinkBox()
    {
        InitializeComponent();
    }

    public ClickableLinkBox(FormEntry formEntry) : this()
    {
        _formEntry = formEntry;
        Button.Content = formEntry.Name;
        Button.Command = new LambdaCommand(x => formEntry.LinkClick(formEntry));
    }
}