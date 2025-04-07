using Godot;
using System;

public partial class Screen : Node2D
{
    int[] score = [0, 0];

	// public void OnDetectionLeftBodyEntered(Node2D body)
	// {
	// 	if (body == GetNode<CharacterBody2D>("Ball"))
	// 	{
	// 		body.Free();
	// 		score[1] += 1;
	// 	}
	// }
	private void OnStartTimerTimeout()
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://scenes/ball.tscn");
		Ball ball = packedScene.Instantiate<Ball>();
		AddChild(ball);
		GetNode<Opponent>("Opponent").SetTarget(ball);
	}
    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetNode<Label>("Container/PlayerScore").Text = score[0].ToString();
		GetNode<Label>("Container/OpponentScore").Text = score[1].ToString();
		
	}
}
