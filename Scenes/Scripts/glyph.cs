using Godot;
using System;

public partial class glyph : Node2D
{
	[Export] 
	public Texture2D GlyphIcon;
	[Export]
	public int ScaleNode = 1;
	[Export]
	public bool SubMenuVisible { get; set; }
	[Export]
	public bool FlowVisible { get; set; }
	[Export]
	public bool AscendVisible { get; set; }
	[Export]
	public bool DescendVisible { get; set; }
	[Export]
	public string LabelText { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
