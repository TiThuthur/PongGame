using Godot;
using System;

public partial class Screen : Node2D
{
    int[] score = [0, 0];

	public void OnDetectionLeftBodyEntered(Node2D body)
	{
		if (body == GetNode<CharacterBody2D>("Ball"))
		{
			score[1] += 1;
			body.Free();
		}
	}
	private void OnStartTimerTimeout()
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://scenes/ball.tscn");
		Ball ball = packedScene.Instantiate<Ball>();//instancie une nouvelle balle
		AddChild(ball);//Crée la balle
		GetNode<Opponent>("Opponent").SetTarget(ball);//attribut à l'opponenet la ball
	}
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		GetNode<Label>("Container/PlayerScore").Text = score[0].ToString();
		GetNode<Label>("Container/OpponentScore").Text = score[1].ToString();
		
	}
}
