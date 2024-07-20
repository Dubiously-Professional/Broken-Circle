using Godot;

namespace BrokenCircle.Scenes.Experimental;

public partial class TextNode3 : TextureButton
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void _on_pressed()
    {
        TextureButton descend = GetNode<TextureButton>("Descend");
        TextureButton edit = GetNode<TextureButton>("Edit");
        descend.Visible = !descend.Visible;
        edit.Visible = !edit.Visible;
    }
}