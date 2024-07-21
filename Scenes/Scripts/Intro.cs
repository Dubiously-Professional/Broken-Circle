using BrokenCircle.Scenes.Scripts;
using Godot;

public partial class Intro : Node2D {
    private void LoadAuthScene() {
        MainScreen.Instance.ScreenContents =
            ResourceLoader.Load<PackedScene>("res://Scenes/AuthScreen.tscn").Instantiate();
    }

    private void ShowFlowButton() {
        CanvasItem start = GetNode<CanvasItem>("TextBackground2/TypingText/Glyph0000Flow");
        start.Visible = true;
        AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
        player.Play();
    }
}