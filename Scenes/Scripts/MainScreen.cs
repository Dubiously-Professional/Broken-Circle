using System;
using System.Collections.Generic;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

public partial class MainScreen : Node2D {
	[Export] private CanvasItem _screenContents;
    private string _sceneName = "Default";
    private Dictionary<string, CanvasItem> _scenes = new();
	
	public static bool Testing = true;
	public static MainScreen Instance { get; private set; }

	public string ScreenContents {
		get => _sceneName;
		set {
			if (value == _sceneName) return;
			if (_screenContents != null) {
				_screenContents.Visible = false;
			}

            if (_sceneName == "Default") {
                RemoveChild(_screenContents); // Don't ask me why I need to do this, it's necessary
            }
            _sceneName = value;

            if (!_scenes.ContainsKey(value)) {
                CanvasItem newScene = ResourceLoader.Load<PackedScene>(value).Instantiate() as CanvasItem;
                _scenes.Add(value, newScene);
                _screenContents = newScene;
                AddChild(_screenContents);
            } else {
                _screenContents = _scenes[value];
                if (_screenContents != null) {
                    _screenContents.Visible = true;
                }
            }
        }
	}

	public override void _EnterTree() {
		if (Instance != null) {
			throw new InvalidOperationException("Only one instance of main scene is allowed.");
		}

		Instance = this;
        _scenes[_sceneName] = _screenContents;
    }

	public override void _ExitTree() {
		Instance = null;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }
}
