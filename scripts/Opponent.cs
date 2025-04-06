using Godot;
using System;

public partial class Opponent : CharacterBody2D
{
    Vector2 ScreenSize;
    Vector2 opponentSize;
    private Vector2 GetSizeOfSprite2D(Sprite2D sprite2D)
    {
        return sprite2D.Texture.GetSize() * sprite2D.Scale;
    }
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        Position = new Vector2(1122, ScreenSize.Y/2);
        UseFullFunction uff=new();
        opponentSize = uff.GetSizeOfSprite2D(GetNode<Sprite2D>("Sprite2D"));
    }
    public override void _Process(double delta)
    {
        Position = new Vector2(1122,Mathf.Clamp(Position.Y,0,ScreenSize.Y));
    }

}
