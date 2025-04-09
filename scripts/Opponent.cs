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
        float direction = 0;
        if (targetBall == null)
            return;
        else{
        if (Math.Abs(targetBall.Position.Y - Position.Y) > 10)
        {
            direction = targetBall.Position.Y > Position.Y ? 1 : -1;
            
            
            // if (Position.Y >= 648 - opponentSize.Y/2)
            // {
            //     Position = new Vector2(1122,ScreenSize.Y-opponentSize.Y/2);
            //     GD.Print("IF 1");
            //     // targetBall = null;
            //     // while (Position.Y >= ScreenSize.Y/2)
            //     // {
            //     //     Position += new Vector2(0,1*speed*(float)delta);
            //     // }
            // }else if (Position.Y <= 0 + opponentSize.Y /2)
            // {
            //     Position = new Vector2(1122,opponentSize.Y/2);
            //     GD.Print("IF 2");
            //     //targetBall = null;
            //     // while (Position.Y <= ScreenSize.Y/2)
            //     // {
            //     //     Position += new Vector2(0, -1*speed*(float)delta);
            //     // }
            // }else
            // {
            //     Position += new Vector2(0, velocityY);    
            //     GD.Print("IF 3");
            // }
            
        }
        if (direction != 0)
        {
            float velocityY = direction * speed * (float)delta;
            Vector2 newPosition = Position + new Vector2(0, velocityY);

            float minY = opponentSize.Y / 2;
            float maxY = ScreenSize.Y - opponentSize.Y /2;

            newPosition.Y = Mathf.Clamp(newPosition.Y, minY, maxY);

            Position = newPosition;
        }
        }
        
    }

}
