using System;
using System.Linq;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class TypingText : Timer {
	[Export] public RichTextLabel Text;
	[Signal] public delegate void TypingEndedEventHandler();
    
	private void _on_timeout() {
        
        int increase = Convert.ToInt16(GD.Randi() % 6);
        
        if (MainScreen.Instance.Testing)
        {
            increase += 20;
        }

        int startingVisibleCharacters = Text.VisibleCharacters;
		Text.VisibleCharacters += increase;
		
		if (Text.VisibleRatio >= 1) {
			EmitSignal(SignalName.TypingEnded);
			Stop();
		} else {
			string nextChars = Text.Text.Substring(startingVisibleCharacters, increase);
			PlayTextSound(0.1f * nextChars.Count(c => !char.IsWhiteSpace(c)) / 6.0f);
		}
	}

	private async void PlayTextSound(float duration) {
		AudioStreamPlayer2D player = MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/Text");
		player.Play();
		await ToSignal(GetTree().CreateTimer(duration), SceneTreeTimer.SignalName.Timeout);
		player.Stop();
	}
}
