using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class MainMenu : Node2D
{
	public bool messageSeen = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (!messageSeen)
		{
			Control message = GetNode<Control>("res://Scenes/MainMenuMessage.tscn");
			AddChild(message);
			message.Visible = true;
		}

	}

	private void ShowCloseButton()
	{
		CanvasItem start = GetNode<CanvasItem>("CanvasGroup/MessageAlert/CloseButton");
		start.Visible = true;
		AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
		player.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void DescendElectricity() {
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/ElectricityDisplay.tscn").Instantiate();
	}

	private void DescendEmotion()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/EmotionDisplay.tscn").Instantiate();
	}

	private void DescendSelf()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/SelfDisplay.tscn").Instantiate();
	}
	
	private void DescendKnow()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/KnowDisplay.tscn").Instantiate();
	}

	private void DescendForce()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/ForceDisplay.tscn").Instantiate();
	}
	
	private void DescendMove()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/MoveDisplay.tscn").Instantiate();
	}

	private void DescendGas()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/GasDisplay.tscn").Instantiate();
	}

	private void DescendLight()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/LightDisplay.tscn").Instantiate();
	}
	
	private void DescendMath()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/MathDisplay.tscn").Instantiate();
	}

	private void CloseMessage()
	{
		Control message = GetNode<Control>("CanvasGroup/MessageAlert");
		message.Visible = false;
		RemoveChild(message);
	}

}
