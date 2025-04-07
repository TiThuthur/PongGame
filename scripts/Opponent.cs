using Godot;
using System;

public partial class Opponent : CharacterBody2D
{
    [Export]
    int speed = 500;
    
    Vector2 ScreenSize;
    Vector2 opponentSize;
    private CharacterBody2D targetBall;
    public void SetTarget(CharacterBody2D ball)
    {
        targetBall = ball;
        GD.Print("targetBall: " + targetBall);
    }

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        Position = new Vector2(1122, ScreenSize.Y/2);
        UseFullFunction uff=new();
        opponentSize = uff.GetSizeOfSprite2D(GetNode<Sprite2D>("Sprite2D"));
    }
    public override void _PhysicsProcess(double delta)
    {
        if (targetBall == null)
            return;
        if (Math.Abs(targetBall.Position.Y - Position.Y) > 10)
        {
            float direction = targetBall.Position.Y > Position.Y ? 1 : -1;
            float velocityY = direction * speed * (float)delta;
            Position = new Vector2(1122, Mathf.Clamp(velocityY,opponentSize.Y/2,ScreenSize.Y-opponentSize.Y/2));
            
        }
        
        
    }

}
