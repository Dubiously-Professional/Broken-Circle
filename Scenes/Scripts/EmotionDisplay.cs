using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class EmotionDisplay : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void on_glyph_0202_art_descend_pressed()
		{
		LoadOldArt();
	}
	
	private void _on_glyph_0023_emotion_2_descend_pressed()
		{
		LoadEmotion2();
	}
		

	private void LoadOldArt() 
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/Depth/OldArt.tscn").Instantiate();
	}
	
	private void LoadStrongEmotions() 
	{
		MainScreen.Instance.ScreenContents =
			ResourceLoader.Load<PackedScene>("res://Scenes/Depth/StrongEmotions.tscn").Instantiate();
	}

}

