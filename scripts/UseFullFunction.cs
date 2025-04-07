using Godot;
public partial class UseFullFunction
{
    public Vector2 GetSizeOfSprite2D(Sprite2D sprite2D)
    {
        return sprite2D.Texture.GetSize() * sprite2D.Scale;
    }
}