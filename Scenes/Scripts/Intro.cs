using BrokenCircle.Scenes.Scripts;
using Godot;

public partial class Intro : Node2D {
	private void LoadAuthScene() {
		MainScreen.Instance.ScreenContents = "res://Scenes/AuthScreen.tscn";
	}

	private void ShowFlowButton() {
		CanvasItem start = GetNode<CanvasItem>("TextBackground2/TypingText/Glyph0000Flow");
		start.Visible = true;
		AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
		player.Play();
	}
}
