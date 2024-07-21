using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class OldArt : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_glyph_0202_art_ascend_pressed()
	{
		LoadEmotionDisplay();
	}

	private void LoadEmotionDisplay() 
	{
		MainScreen.Instance.ScreenContents = "res://Scenes/EmotionDisplay.tscn";
	}
}
