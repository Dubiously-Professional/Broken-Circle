using System;
using System.Collections.Generic;
using Godot;
using Godot.Collections;
using Array = Godot.Collections.Array;

namespace BrokenCircle.Scenes.Scripts;

[Tool]
public partial class Glyphs : Node
{
	[Signal]
	public delegate void GlyphTranslationChangedEventHandler(GlyphType glyphType, string translation);

	public enum GlyphType
	{
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
		Cut0110,
		Grief0111,
		Low0112,
		Strong0113,
		Two0120,
		Measure0121,
		Three0122,
		Empty0123,
		Need0130
	};

	public string[,] TranslationOptions = {
		{ "????", "FLOW", "FLOW", "FLOW", "FLOW" },
		{ "????", "SELF", "SELF", "SELF", "SELF" },
		{ "????", "CONTAIN", "OTHER", "MOVE", "TIME" },
		{ "????", "AFFIRM", "AFFIRM", "AFFIRM", "AFFIRM" },
		{ "????", "EMOTION", "SAFE", "FORCE", "OBJECT" },
		{ "????", "EMPTY", "ONE", "TWO", "THREE" },
		{ "????", "KNOW", "OBJECT", "NOT", "MATH" },
		{ "????", "FORCE", "SAFE", "POWER", "CUT" },
		{ "????", "FORCE", "METAL", "CUT", "OBJECT" },
		{ "????", "ORIGIN", "MOVE", "PLACE", "MOVE" },
		{ "????", "OBJECT", "GAS", "LIQUID", "METAL" },
		{ "????", "EMOTION", "OBJECT", "ART", "OTHER" },
		{ "????", "ART", "AFFIRM", "LIGHT", "OTHER" },
		{ "????", "EMPTY", "ONE", "MATH", "ART" },
		{ "????", "NOT", "TIME", "AFTER", "BEFORE" },
		{ "????", "PLACE", "OTHER", "MOVE", "ORIGIN" },
		{ "????", "LIGHT", "MOVE", "PLACE", "FORCE" },
		{ "????", "EMPTY", "ONE", "MATH", "OBJECT" },
		{ "????", "OBJECT", "GAS", "LIQUID", "METAL" },
		{ "????", "ON", "TIME", "EMPTY", "BEFORE" },
		{ "????", "GAS", "AFTER", "CUT", "METAL"},
		{ "????", "EMOTION", "GRIEF", "AFFIRM", "ART"},
		{ "????", "LIGHT", "ON", "AFTER", "LOW"},
		{ "????", "STRONG", "LOW", "TIME", "NOT"},
		{ "????", "THREE", "ONE", "EMPTY", "TWO" },
		{ "????", "MEASURE", "LIQUID", "LIGHT", "TIME"},
		{ "????", "TWO", "THREE", "ONE", "EMPTY"},
		{ "????", "ONE", "MATH", "EMPTY", "ART" },
		{ "????", "PLACE", "MOVE", "CONTAIN", "NEED"}
	};


	private Texture2D[] _glyphIcons;
	private string[] _glyphTranslations;
	private string[][] _glyphTranslationOptions;


	public Glyphs()
	{
		if (Instance != null)
		{
			QueueFree();
			return;
		}

		Instance = this;

		string[] glyphNames = Enum.GetNames<GlyphType>();
		_glyphIcons = new Texture2D[glyphNames.Length];
		_glyphTranslations = new string[glyphNames.Length];
		_glyphTranslationOptions = new string[glyphNames.Length][];

		for (int i = 0; i < glyphNames.Length; i++)
		{
			_glyphIcons[i] = GD.Load<Texture2D>("res://Assets/Sprites/Ideograms/" + glyphNames[i] + ".png");
			_glyphTranslations[i] = "????";
			// TODO
			_glyphTranslationOptions[i] = new[] { TranslationOptions[i, 0], TranslationOptions[i, 1], TranslationOptions[i, 2], TranslationOptions[i, 3], TranslationOptions[i, 4] }
			;
		}
	}

	public static Glyphs Instance { get; private set; }

	public Texture2D GetGlyphIcon(GlyphType glyphType)
	{
		return _glyphIcons[(int)glyphType];
	}

	public string GetGlyphTranslation(GlyphType glyphType)
	{
		return _glyphTranslations[(int)glyphType];
	}

	public void SetGlyphTranslation(GlyphType glyphType, string translation)
	{
		_glyphTranslations[(int)glyphType] = translation;
		EmitSignal(SignalName.GlyphTranslationChanged, (int)glyphType, translation);
	}

	public string[] GetGlyphTranslationOptions(GlyphType glyphType)
	{
		return _glyphTranslationOptions[(int)glyphType];
	}
}
