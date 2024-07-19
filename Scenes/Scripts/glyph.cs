using Godot;

[Tool]
public partial class glyph : Node2D
{
	[Export] 
	public Texture2D GlyphIcon;
	[Export] public int ScaleNode = 1;
	[Export] public bool SubMenuVisible = false;
	[Export] public bool FlowVisible = false;
	[Export] public bool AscendVisible = false;
	[Export] public bool DescendVisible = false;
	[Export]
	public string LabelText { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Engine.IsEditorHint()) {
			TextureRect glyphRect =
				GetNode<TextureRect>("ControlCanvas/ButtonCanvas/GlyphButtonCanvas/GlyphButton/GlyphTexture");
			glyphRect.Texture = GlyphIcon;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		Control subMenu = GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas");
		subMenu.Visible = SubMenuVisible;
		Control flowButtonCanvas = GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/FlowButtonCanvas");
		flowButtonCanvas.Visible = FlowVisible;
		Control ascendButtonCanvas = GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/AscendButtonCanvas");
		ascendButtonCanvas.Visible = AscendVisible;
		Control descendButtonCanvas = GetNode<Control>("ControlCanvas/ButtonCanvas/SubMenuCanvas/DescendButtonCanvas");
		descendButtonCanvas.Visible = DescendVisible;
		
	}
}
