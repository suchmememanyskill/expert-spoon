﻿using LauncherGamePlugin;
using Newtonsoft.Json;

namespace LegendaryIntegration.Model;

public class LaunchDryRun
{
    [JsonProperty("game_parameters")]
    public List<string> GameParameters { get; set; }

    [JsonProperty("game_executable")]
    public string GameExecutable { get; set; }

    [JsonProperty("game_directory")]
    public string GameDirectory { get; set; }

    [JsonProperty("egl_parameters")]
    public List<string> EglParameters { get; set; }

    [JsonProperty("launch_command")]
    public List<string> LaunchCommand { get; set; }

    [JsonProperty("working_directory")]
    public string WorkingDirectory { get; set; }

    [JsonProperty("user_parameters")]
    public List<string> UserParameters { get; set; }

    [JsonProperty("environment")]
    public Dictionary<string, string> Environment { get; set; }

    [JsonProperty("pre_launch_command")]
    public string PreLaunchCommand { get; set; }

    [JsonProperty("pre_launch_wait")]
    public bool PreLaunchWait { get; set; }

    public IEnumerable<string> AllParameters => GameParameters.Concat(UserParameters).Concat(EglParameters);

    // https://github.com/derrod/legendary/blob/master/legendary/cli.py#L641
    public ExecLaunch toLaunch()
    {
        ExecLaunch launch = new(Path.Join(WorkingDirectory, GameExecutable), String.Join(" ", AllParameters), WorkingDirectory, Platform.Windows);
        
        foreach (var (key, value) in Environment)
            launch.EnvironmentOverrides[key] = value;

        if (LaunchCommand.Count > 0)
            throw new NotImplementedException();

        return launch;
    }
}