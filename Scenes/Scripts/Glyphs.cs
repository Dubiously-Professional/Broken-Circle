using System;
using Godot;

namespace BrokenCircle.Scenes.Scripts;

[Tool]
public partial class Glyphs : Node {
    [Signal]
    public delegate void GlyphTranslationChangedEventHandler(GlyphType glyphType, string translation);

    public enum GlyphType {
        Flow0000,
        Self0001,
        Contain0002,
        Affirm0003,
        Safe0010,
        One0011,
        Know0012,
        Electricity0013,
        Force0020,
        Move0021,
        Gas0022,
        Emotion0023,
        Light0030,
        Math0031,
        Not0032,
        Origin0033,
        Place0100,
        Object0101,
        Metal0102,
        On0103,
        Cut0110
    }

    private Texture2D[] _glyphIcons;
    private string[] _glyphTranslations;
    private string[][] _glyphTranslationOptions;

    public Glyphs() {
        if (Instance != null) {
            QueueFree();
            return;
        }

        Instance = this;

        string[] glyphNames = Enum.GetNames<GlyphType>();
        _glyphIcons = new Texture2D[glyphNames.Length];
        _glyphTranslations = new string[glyphNames.Length];
        _glyphTranslationOptions = new string[glyphNames.Length][];

        for (int i = 0; i < glyphNames.Length; i++) {
            _glyphIcons[i] = GD.Load<Texture2D>("res://Assets/Sprites/Ideograms/" + glyphNames[i] + ".png");
            _glyphTranslations[i] = "????";
            // TODO
            _glyphTranslationOptions[i] = new []{"????", "Fluffy", "Onion", "No Really"};
        }
    }

    public static Glyphs Instance { get; private set; }

    public Texture2D GetGlyphIcon(GlyphType glyphType) {
        return _glyphIcons[(int)glyphType];
    }

    public string GetGlyphTranslation(GlyphType glyphType) {
        return _glyphTranslations[(int)glyphType];
    }

    public void SetGlyphTranslation(GlyphType glyphType, string translation) {
        _glyphTranslations[(int)glyphType] = translation;
        EmitSignal(SignalName.GlyphTranslationChanged, (int)glyphType, translation);
    }

    public string[] GetGlyphTranslationOptions(GlyphType glyphType) {
        return _glyphTranslationOptions[(int)glyphType];
    }
}