using Godot;

namespace BrokenCircle.Scenes.Scripts;

[Tool]
public partial class Glyph : Node2D {
    [Signal]
    public delegate void AscendPressedEventHandler();

    [Signal]
    public delegate void DescendPressedEventHandler();

    [Signal]
    public delegate void FlowPressedEventHandler();

    [Signal]
    public delegate void GlyphPressedEventHandler();

    [Signal]
    public delegate void TranslatePressedEventHandler();

    private bool _actionButton;
    private bool _ascendVisible;
    private bool _descendVisible;
    private bool _flowVisible;
    private Texture2D _glyphIcon;
    private string _labelText = "????";
    private int _scaleNode = 1;
    private bool _subMenuVisible;

    [Export]
    public int ScaleNode {
        get => _scaleNode;
        set {
            _scaleNode = value;
            if (IsNodeReady()) {
                GetNode<Control>("ControlCanvas").Scale = new Vector2(_scaleNode, _scaleNode);
            }
        }
    }

    [Export]
    public Texture2D GlyphIcon {
        get => _glyphIcon;
        set {
            _glyphIcon = value;
            if (IsNodeReady()) {
                GetNode<TextureRect>("ControlCanvas/ButtonCanvas/GlyphButtonCanvas/GlyphButton/GlyphTexture").Texture =
                    value;
            }
        }
    }

    [Export]
    public bool SubMenuVisible {
        get => _subMenuVisible;
        set {
            _subMenuVisible = value;
            if (IsNodeReady()) {
                GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas").Visible = value;
            }
        }
    }

    [Export]
    public bool FlowVisible {
        get => _flowVisible;
        set {
            _flowVisible = value;
            if (IsNodeReady()) {
                GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/FlowButtonCanvas").Visible = value;
            }
        }
    }

    [Export]
    public bool AscendVisible {
        get => _ascendVisible;
        set {
            _ascendVisible = value;
            if (IsNodeReady()) {
                GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/AscendButtonCanvas").Visible = value;
            }
        }
    }

    [Export]
    public bool DescendVisible {
        get => _descendVisible;
        set {
            _descendVisible = value;
            if (IsNodeReady()) {
                GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/DescendButtonCanvas").Visible = value;
            }
        }
    }

    [Export]
    public string LabelText {
        get => _labelText;
        set {
            _labelText = value;
            if (IsNodeReady()) {
                GetNode<RichTextLabel>("ControlCanvas/TranslationLabelCanvas/TranslationLabel").Text =
                    $"[center]{value}[/center]";
            }
        }
    }

    [Export]
    public bool ActionButton {
        get => _actionButton;
        set {
            _actionButton = value;
            _subMenuVisible = false;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas").Visible = _subMenuVisible;
        GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/FlowButtonCanvas").Visible = _flowVisible;
        GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/AscendButtonCanvas").Visible = _ascendVisible;
        GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/DescendButtonCanvas").Visible = _descendVisible;
        GetNode<RichTextLabel>("ControlCanvas/TranslationLabelCanvas/TranslationLabel").Text =
            $"[center]{_labelText}[/center]";
        GetNode<Control>("ControlCanvas").Scale = new Vector2(_scaleNode, _scaleNode);
        GetNode<TextureRect>("ControlCanvas/ButtonCanvas/GlyphButtonCanvas/GlyphButton/GlyphTexture").Texture =
            _glyphIcon;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    private void OnGlyphButtonPressed() {
        if (ActionButton) {
            EmitSignal(SignalName.GlyphPressed);
        } else {
            SubMenuVisible = !SubMenuVisible;
        }
    }

    private void OnTranslatePressed() {
        EmitSignal(SignalName.TranslatePressed);
    }

    private void OnDescendPressed() {
        EmitSignal(SignalName.DescendPressed);
    }

    private void OnFlowPressed() {
        EmitSignal(SignalName.FlowPressed);
    }

    private void OnAscendPressed() {
        EmitSignal(SignalName.AscendPressed);
    }
}