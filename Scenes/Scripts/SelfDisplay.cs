using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class SelfDisplay : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_self_ascend_pressed()
	{
		LoadMainMenu();
	}

	private void LoadMainMenu()
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/MainMenu.tscn").Instantiate();
	}
}
