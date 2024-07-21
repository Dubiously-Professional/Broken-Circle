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
        

    }

    private void ShowCloseButton()
    {
        CanvasItem start = GetNode<CanvasItem>("TypingText/MessageAlert/CloseButton");
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

}
