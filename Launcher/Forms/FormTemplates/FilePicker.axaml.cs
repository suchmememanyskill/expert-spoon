﻿using Avalonia.Controls;
using Avalonia.Threading;
using Launcher.Utils;
using LauncherGamePlugin.Forms;

namespace Launcher.Forms.FormTemplates;

public partial class FilePicker : UserControl
{
    private FormEntry _formEntry;
    
    public FilePicker()
    {
        InitializeComponent();
    }

    public FilePicker(FormEntry formEntry) : this()
    {
        _formEntry = formEntry;
        Label.Content = formEntry.Name;
        TextBox.Text = formEntry.Value;
        Button.Command = new LambdaCommand(x => Dispatcher.UIThread.Post(OnBrowse));
        TextBox.KeyUp += (_, _) =>
        {
            formEntry.Value = TextBox.Text;
            _formEntry.InvokeOnChange();
        };
    }

    public async void OnBrowse()
    {
        if (_formEntry.Type == FormEntryType.FilePicker)
        {
            OpenFileDialog dialog = new();
            dialog.AllowMultiple = false;
            string[]? results = await dialog.ShowAsync(Loader.App.GetInstance().MainWindow);

            if (results == null || results.Length < 1)
                return;

            string result = results[0];
            
            if (!string.IsNullOrWhiteSpace(result))
            {
                _formEntry.Value = result;
                TextBox.Text = result;
                _formEntry.InvokeOnChange();
            }
        }
        else
        {
            OpenFolderDialog dialog = new();
            string? result = await dialog.ShowAsync(Loader.App.GetInstance().MainWindow);
            if (!string.IsNullOrWhiteSpace(result))
            {
                _formEntry.Value = result;
                TextBox.Text = result;
                _formEntry.InvokeOnChange();
            }
        }
    }
}