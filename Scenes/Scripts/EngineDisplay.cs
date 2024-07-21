using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class EngineDisplay : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AscendEngine()
	{
		MainScreen.Instance.ScreenContents = "res://Scenes/MainMenu.tscn";
	}

    public void showFlow()
    {
        Control flowMenuDisplay = GetNode<Control>("FlowMenuDisplay");
        flowMenuDisplay.Visible = !flowMenuDisplay.Visible;
    }

    public void Power()
    {
        Glyph power = GetNode<Glyph>("Glyph0103On");
        power.GlyphType = Glyphs.GlyphType.On0103;
        
        Glyph enginePower = GetNode<Glyph>("Glyph0103On2");
        enginePower.GlyphType = Glyphs.GlyphType.On0103;
        
        showFlow();
    }

    public void dePower()
    {
        Glyph power = GetNode<Glyph>("Glyph0103On");
        power.GlyphType = Glyphs.GlyphType.Empty0123;
        
        Glyph enginePower = GetNode<Glyph>("Glyph0103On2");
        enginePower.GlyphType = Glyphs.GlyphType.Empty0123;
    }
}
