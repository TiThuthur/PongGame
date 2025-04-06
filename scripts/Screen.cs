using Godot;
using System;

public partial class Screen : Node2D
{
    int[] score = [0, 0];
	private void OnStartTimerTimeout()
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://scenes/ball.tscn");
		Ball ball = packedScene.Instantiate<Ball>();
		AddChild(ball);
		
	}
    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		CollisionShape2D leftWall = GetNode<CollisionShape2D>("Wall/Left");
		CollisionShape2D rightWall = GetNode<CollisionShape2D>("Wall/Right");
		
	}
}
