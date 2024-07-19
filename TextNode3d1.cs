using Godot;
using System;

public partial class TextNode3d1 : TextureButton
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
        TextureButton ascend = GetNode<TextureButton>("Ascend");
        TextureButton edit = GetNode<TextureButton>("Edit");
        ascend.Visible = !ascend.Visible;
        edit.Visible = !edit.Visible;
    }
}