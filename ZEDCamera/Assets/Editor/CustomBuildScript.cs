using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class CustomBuildScript
{
    [MenuItem("Build/Build Windows")]
    static void PerformBuild()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildFilePath = "./MegaQuantumBuildZEDUNITY/BuildCI.exe";
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "+bfp")
            {
                buildFilePath = args[i + 1];
            }
        }

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/ZED/Examples/Body Tracking/Scene/BodyTrackingMulti.unity" };
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.locationPathName = buildFilePath;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes to " + summary.outputPath);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed to " + summary.outputPath);
        }
    }
}
