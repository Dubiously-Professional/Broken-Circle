using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class Intro : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Glyph glyph =
			GetNode<Glyph>(
				"TextBackground2/TypingText/Glyph0000Flow/Glyph");
		glyph.ActionButton = true;
		glyph.ScaleNode = 2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
