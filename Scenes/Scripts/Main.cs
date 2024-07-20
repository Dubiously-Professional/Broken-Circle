using System;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

[Tool]
public partial class Main : Node2D {

    private Node2D _screenContents;

    [Export]
    public Node2D ScreenContents {
        get => _screenContents;
        set {
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

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}