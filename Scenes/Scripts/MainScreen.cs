using System;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class MainScreen : Node2D {
	[Export] private Node _screenContents;
    
    public static bool Testing = true;
	public static MainScreen Instance { get; private set; }

	public Node ScreenContents {
		get => _screenContents;
		set {
			if (value == _screenContents) return;
			if (_screenContents != null) {
				RemoveChild(_screenContents);
				_screenContents.QueueFree();
			}

			_screenContents = value;

			if (_screenContents != null) {
				AddChild(_screenContents);
			}
		}
	}

	public override void _EnterTree() {
		if (Instance != null) {
			throw new InvalidOperationException("Only one instance of main scene is allowed.");
		}

		Instance = this;
	}

	public override void _ExitTree() {
		Instance = null;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }
}
