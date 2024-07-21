using BrokenCircle.Scenes.Scripts;
using Godot;

public partial class MainMenu : Node2D {
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() { }

	private void ShowCloseButton() {
		CanvasItem start = GetNode<CanvasItem>("CanvasGroup/MessageAlert/CloseButton");
		start.Visible = true;
		AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
		player.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }

	private void DescendElectricity() {
		MainScreen.Instance.ScreenContents = "res://Scenes/ElectricityDisplay.tscn";
	}

	private void DescendEmotion() {
		MainScreen.Instance.ScreenContents = "res://Scenes/EmotionDisplay.tscn";
	}

	private void DescendSelf() {
		MainScreen.Instance.ScreenContents = "res://Scenes/SelfDisplay.tscn";
	}

	private void DescendKnow() {
		MainScreen.Instance.ScreenContents = "res://Scenes/KnowDisplay.tscn";
	}

	private void DescendForce() {
		MainScreen.Instance.ScreenContents = "res://Scenes/ForceDisplay.tscn";
	}

	private void DescendMove() {
		MainScreen.Instance.ScreenContents = "res://Scenes/MoveDisplay.tscn";
	}

	private void DescendGas() {
		MainScreen.Instance.ScreenContents = "res://Scenes/GasDisplay.tscn";
	}

	private void DescendLight() {
		MainScreen.Instance.ScreenContents = "res://Scenes/LightsDisplay.tscn";
	}

	private void DescendMath() {
		MainScreen.Instance.ScreenContents = "res://Scenes/MathDisplay.tscn";
	}

	private void CloseMessage()
	{
		Control message = GetNode<Control>("CanvasGroup/MessageAlert");
		message.Visible = false;
		RemoveChild(message);
	}

}
