using System;
using System.Linq;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class TypingText : Timer {
    
	[Export]
    private RichTextLabel _text;
    
	[Signal]
    public delegate void TypingEndedEventHandler();
    
	private void _on_timeout() {
        // Increase visible text by 0-5 characters
        int increase = Convert.ToInt16(GD.Randi() % 6);
        
        // Speed up text typing if testing.
        if (MainScreen.Testing)
        {
            increase += 20;
        }
        
        // Ensure character value is non-negative
        int startingVisibleCharacters = _text.VisibleCharacters > 0 ? _text.VisibleCharacters : 0;
        
        _text.VisibleCharacters += increase;
		
		if (_text.VisibleRatio >= 1) {
			EmitSignal(SignalName.TypingEnded);
			Stop();
		} else {
            // Verify characters shown are not whitespace when playing sound
			string nextChars = _text.Text.Substring(startingVisibleCharacters, increase);
			PlayTextSound(0.1f * nextChars.Count(c => !char.IsWhiteSpace(c)) / 6.0f);
		}
	}

	private async void PlayTextSound(float duration) {
		AudioStreamPlayer2D player = GetNode<AudioStreamPlayer2D>("TypingTextSound");
		player.Play();
        
		await ToSignal(GetTree().CreateTimer(duration), SceneTreeTimer.SignalName.Timeout);
		player.Stop();
	}
}
