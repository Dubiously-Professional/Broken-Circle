using Godot;
using System;
using BrokenCircle.Scenes.Scripts;

public partial class MainMenu : Node2D
{
    private void ShowCloseButton() {
        CanvasItem start = GetNode<CanvasItem>("TypingText/MessageAlert/CloseButton");
        start.Visible = true;
        AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/ButtonAppear");
        player.Play();
    }
}
