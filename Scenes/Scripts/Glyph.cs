using Godot;

namespace BrokenCircle.Scenes.Scripts;

[Tool]
public partial class Glyph : Control {
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
    private Glyphs.GlyphType _glyphType;
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

    private Texture2D GlyphIcon {
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
                GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/FlowButton").Visible = value;
            }
        }
    }

    [Export]
    public bool AscendVisible {
        get => _ascendVisible;
        set {
            _ascendVisible = value;
            if (IsNodeReady()) {
                GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/AscendButton").Visible = value;
            }
        }
    }

    [Export]
    public bool DescendVisible {
        get => _descendVisible;
        set {
            _descendVisible = value;
            if (IsNodeReady()) {
                GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/DescendButton").Visible = value;
            }
        }
    }

    private string LabelText {
        get => _labelText;
        set {
            _labelText = value;
            if (IsNodeReady()) {
                GetNode<RichTextLabel>("ControlCanvas/TranslationLabel").Text =
                    $"[center]{value.ToUpper()}[/center]";
            }
        }
    }

    [Export]
    public bool ActionButton {
        get => _actionButton;
        set {
            _actionButton = value;
            SubMenuVisible = false;
        }
    }

    [Export]
    public Glyphs.GlyphType GlyphType {
        get => _glyphType;
        set {
            _glyphType = value;
            if (IsNodeReady()) {
                GlyphIcon = Glyphs.Instance.GetGlyphIcon(value);
                LabelText = Glyphs.Instance.GetGlyphTranslation(value);
            }
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        GlyphIcon = Glyphs.Instance.GetGlyphIcon(_glyphType);
        LabelText = Glyphs.Instance.GetGlyphTranslation(_glyphType);
        GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas").Visible = _subMenuVisible;
        GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/FlowButton").Visible = _flowVisible;
        GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/AscendButton").Visible = _ascendVisible;
        GetNode<TextureButton>("ControlCanvas/ButtonCanvas/SubMenuCanvas/DescendButton").Visible = _descendVisible;
        GetNode<RichTextLabel>("ControlCanvas/TranslationLabel").Text =
            $"[center]{_labelText}[/center]";
        GetNode<Control>("ControlCanvas").Scale = new Vector2(_scaleNode, _scaleNode);
        GetNode<TextureRect>("ControlCanvas/ButtonCanvas/GlyphButtonCanvas/GlyphButton/GlyphTexture").Texture =
            _glyphIcon;
        Glyphs.Instance.GlyphTranslationChanged += OnTranslationChanged;
    }

    protected override void Dispose(bool disposing) {
        Glyphs.Instance.GlyphTranslationChanged -= OnTranslationChanged;
        base.Dispose(disposing);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    private void OnGlyphButtonPressed() {
        MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/GlyphButtonClick").Play();
        if (ActionButton) {
            EmitSignal(SignalName.GlyphPressed);
        } else {
            SubMenuVisible = !SubMenuVisible;
        }
    }

    private void PlayHoverSound() {
        MainScreen.Instance.GetNode<AudioStreamPlayer2D>("Sounds/Hover").Play();
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

    private void OnTranslationChanged(Glyphs.GlyphType glyphType, string translation) {
        if (glyphType == GlyphType) {
            LabelText = translation;
        }
    }
}