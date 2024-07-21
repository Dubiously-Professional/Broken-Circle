using BrokenCircle.Scenes.Scripts;
using Godot;

public partial class Intro : Node2D {
    private void LoadAuthScene() {
        MainScreen.Instance.ScreenContents =
            ResourceLoader.Load<PackedScene>("res://Scenes/AuthScreen.tscn").Instantiate();
    }
}