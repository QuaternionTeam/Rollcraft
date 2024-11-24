using UnityEditor;

public class BuildScript
{
    public static void PermormBuild()
    {
        string[] scenes = { "Assets/Scenes/Board.unity", "Assets/Scenes/Combat.unity", "Assets/Scenes/MainMenu.unity" };
        string buildPath = "Builds/WebGL";

        BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.WebGL, BuildOptions.None);
    }
}
