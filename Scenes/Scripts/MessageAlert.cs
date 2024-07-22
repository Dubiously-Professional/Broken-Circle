using Godot;
namespace BrokenCircle.Scenes.Scripts;

public partial class MessageAlert : Panel
{
    
    private string _messageText = "";
    
    // Allow setting of the MessageAlert Text
    [Export]
    private string MessageText {
        get => _messageText;
        set { 
            _messageText = value;
            if (IsNodeReady()) {
                GetNode<RichTextLabel>("AlertPanel/MessageBox").Text = _messageText;
            }
        }
    }
    
    public override void _Ready()
    {
        GetNode<RichTextLabel>("AlertPanel/MessageBox").Text = _messageText;
    }
    
    // Hide MessageAlert upon confirmation.
    private void CloseMessage()
    {
        Visible = false;
    }
    
    // Display CloseButton
    private void ShowCloseButton()
    {
        TextureButton closeButton = GetNode<TextureButton>("AlertPanel/CloseButton");
        closeButton.Visible = true;
        
        AudioStreamPlayer2D player = GetNode<AudioStreamPlayer2D>("AlertPanel/CloseButton/ButtonAppearSound");
        player.Play();
    }
    
}