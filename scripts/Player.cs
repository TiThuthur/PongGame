using Godot;
using System;

public partial class Player : CharacterBody2D
{
    int speed = 400;
    Vector2 ScreenSize;
    Vector2 playerSize;
   
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        Position = new Vector2(32, ScreenSize.Y /2);
        UseFullFunction uff = new();
        playerSize = uff.GetSizeOfSprite2D(GetNode<Sprite2D>("Sprite2D"));
    }
    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;
        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1; 
        }
        if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
        }
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() *speed;
        }
        Position += velocity * (float)delta;
        Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0 + playerSize.Y / 2, ScreenSize.Y - playerSize.Y / 2)
		);
    }
}
