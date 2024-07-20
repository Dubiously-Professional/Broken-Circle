using System;
using System.Linq;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class TypingText : Timer {
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        GD.Randomize();
    }

    private void _on_timeout() {
        Label text = GetNode<Label>("Text");
        int increase = Convert.ToInt16(GD.Randi() % 6);

        int startingVisibleCharacters = text.VisibleCharacters;
        text.VisibleCharacters += increase;

        if (text.VisibleRatio >= 1) {
            Node2D start = GetNode<Node2D>("Glyph000");
            start.Visible = true;
            AudioStreamPlayer2D player = GetNode<AudioStreamPlayer2D>("ButtonAppearSound");
            player.Play();
            Stop();
        } else {
            string nextChars = text.Text.Substring(startingVisibleCharacters, increase);
            PlayTextSound(0.1f * nextChars.Count(c => !char.IsWhiteSpace(c)) / 6.0f);
        }
    }

    private async void PlayTextSound(float duration) {
        AudioStreamPlayer2D player = GetNode<AudioStreamPlayer2D>("TextSound");
        player.Play();
        await ToSignal(GetTree().CreateTimer(duration), SceneTreeTimer.SignalName.Timeout);
        player.Stop();
    }
}