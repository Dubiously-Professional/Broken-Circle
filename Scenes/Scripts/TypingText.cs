using System;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class TypingText : Timer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Randomize();
	}
	private void _on_timeout()
	{
		Label text = GetNode<Label>("Text");
		int increase = Convert.ToInt16(GD.Randi() % 6);
		text.VisibleCharacters += increase;

		if (text.VisibleRatio >= 1)
		{
			TextureButton start = GetNode<TextureButton>("Start");
			start.Visible = true;
			Stop();
		}
	}
}