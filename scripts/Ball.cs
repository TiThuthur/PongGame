using Godot;
using System;

public partial class Ball : RigidBody2D
{

    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RigidBody2D Ball = GetNode<RigidBody2D>("Ball");
		Position = GetNode<Marker2D>("BallStartPosition").Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;
		velocity.X -= 1;
        velocity.Y -= 1;
		velocity = velocity.Normalized() * (float)delta;
        Position = velocity;
		
	}
}
