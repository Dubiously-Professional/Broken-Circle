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
    
	private void LoadOldArt() 
	{
		MainScreen.Instance.ScreenContents = "res://Scenes/Depth/OldArt.tscn";
	}
	
	private void LoadStrongEmotions() 
	{
		MainScreen.Instance.ScreenContents = "res://Scenes/Depth/StrongEmotions.tscn";
	}

    public void AscendEmotion()
    {
        MainScreen.Instance.ScreenContents = "res://Scenes/MainMenu.tscn";
    }

}

