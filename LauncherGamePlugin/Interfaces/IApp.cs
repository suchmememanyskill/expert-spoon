﻿using LauncherGamePlugin.Forms;

namespace LauncherGamePlugin.Interfaces;

public interface IApp
{
    public string ConfigDir { get; }
    public string GameDir { get; }
    public Logger Logger { get; }
    void ShowForm(Form form);
    void HideOverlay();
    void ReloadGames();
    void ReloadGlobalCommands();
    void Launch(ExecLaunch launch);
}