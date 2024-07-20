using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        // Set initial Glyph states
        // @TODO: make this a full method of its own
        Glyph glyph0001Self = GetNode<Glyph>("CanvasGroup/Glyph0001Self/Glyph");
        glyph0001Self.ScaleNode = 1;
        glyph0001Self.ActionButton = false;
        glyph0001Self.AscendVisible = false;
        glyph0001Self.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0001Self.SubMenuVisible = false;
        
        Glyph glyph0011Know = GetNode<Glyph>("CanvasGroup/Glyph0011Know/Glyph");
        glyph0011Know.ScaleNode = 1;
        glyph0011Know.ActionButton = false;
        glyph0011Know.AscendVisible = false;
        glyph0011Know.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0011Know.SubMenuVisible = false;
        
        Glyph glyph0012Electricity = GetNode<Glyph>("CanvasGroup/Glyph0012Electricity/Glyph");
        glyph0012Electricity.ScaleNode = 1;
        glyph0012Electricity.ActionButton = false;
        glyph0012Electricity.AscendVisible = false;
        glyph0012Electricity.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0012Electricity.SubMenuVisible = false;
        
        Glyph glyph0013Force = GetNode<Glyph>("CanvasGroup/Glyph0013Force/Glyph");
        glyph0013Force.ScaleNode = 1;
        glyph0013Force.ActionButton = false;
        glyph0013Force.AscendVisible = false;
        glyph0013Force.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0013Force.SubMenuVisible = false;
        
        Glyph glyph0021Move = GetNode<Glyph>("CanvasGroup/Glyph0021Move/Glyph");
        glyph0021Move.ScaleNode = 1;
        glyph0021Move.ActionButton = false;
        glyph0021Move.AscendVisible = false;
        glyph0021Move.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0021Move.SubMenuVisible = false;
        
        Glyph glyph0022Gas = GetNode<Glyph>("CanvasGroup/Glyph0022Gas/Glyph");
        glyph0022Gas.ScaleNode = 1;
        glyph0022Gas.ActionButton = false;
        glyph0022Gas.AscendVisible = false;
        glyph0022Gas.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0022Gas.SubMenuVisible = false;
        
        Glyph glyph0023Emotion = GetNode<Glyph>("CanvasGroup/Glyph0023Emotion/Glyph");
        glyph0023Emotion.ScaleNode = 1;
        glyph0023Emotion.ActionButton = false;
        glyph0023Emotion.AscendVisible = false;
        glyph0023Emotion.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0023Emotion.SubMenuVisible = false;
        
        Glyph glyph0030Light = GetNode<Glyph>("CanvasGroup/Glyph0030Light/Glyph");
        glyph0030Light.ScaleNode = 1;
        glyph0030Light.ActionButton = false;
        glyph0030Light.AscendVisible = false;
        glyph0030Light.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0030Light.SubMenuVisible = false;
        
        Glyph glyph0031Math = GetNode<Glyph>("CanvasGroup/Glyph0031Math/Glyph");
        glyph0031Math.ScaleNode = 1;
        glyph0031Math.ActionButton = false;
        glyph0031Math.AscendVisible = false;
        glyph0031Math.DescendVisible = true;
        glyph0001Self.FlowVisible = false;
        glyph0031Math.SubMenuVisible = false;
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
