using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class AuthScreen : Node2D
{
	private void ShowCloseButton() {
		CanvasItem start = GetNode<CanvasItem>("TypingText/MessageAlert/CloseButton");
		start.Visible = true;
		AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
		player.Play();
	}
	
	private void LoadMainMenu() {
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/MainMenu.tscn").Instantiate();
	}

	private void FlowMenu()
	{
		Control flowMenu = GetNode<Control>("FlowMenuDisplay");
		flowMenu.Visible = !flowMenu.Visible;
	}
}
