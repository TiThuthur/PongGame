using Godot;
using System;
using System.Linq;

public partial class BallMotion : Line2D
{
    Vector2 previousPosition = Vector2.Zero;
    float ballRadius = 0f;
    public override void _Ready()
    {
        Texture2D texture = GetParent<Sprite2D>().Texture;
        ballRadius = texture.GetSize().X * 0.5f;
        previousPosition = GetParent<Sprite2D>().GlobalPosition;
    }

    public override void _Process(double delta)
    {
        Vector2 currentPosition = GetParent<Sprite2D>().GlobalPosition;
        Vector2 direction = (currentPosition - previousPosition).Normalized();
        AddPoint(currentPosition - ballRadius * direction);
        if (this.Points.Count()>20)
        {
            this.RemovePoint(0);
        }
        previousPosition = currentPosition;
    }

}
