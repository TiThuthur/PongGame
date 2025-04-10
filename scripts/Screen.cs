using Godot;
using System;

public partial class Screen : Node2D
{
    int[] score = [0, 0];
	Vector2 screenSize;
	public void OnDetectionLeftBodyEntered(Node2D body)
	{
		if (body == GetNode<Ball>("Ball"))
		{
			score[1] += 1;
			body.GetNode<AnimationPlayer>("AnimationPlayer").Play("explode");
			body.Position = body.Position;
			body.Free();
			GetNode<Timer>("StartTimer").Start();
			GetNode<AnimationPlayer>("Ball/");
		}
	}
	public void OnDetectionRightBodyEntered(Node2D body)
	{
		if (body == GetNode<CharacterBody2D>("Ball"))
		{
			score[0] += 1;
			body.Free();
			GetNode<Timer>("StartTimer").Start();
		}
	}
	private void OnStartTimerTimeout()
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://scenes/ball.tscn");
		Ball ball = packedScene.Instantiate<Ball>();//instancie une nouvelle balle
		ball.Position = new Vector2(screenSize.X/2, screenSize.Y/2);
		AddChild(ball);//Crée la balle
		GetNode<Opponent>("Opponent").SetTarget(ball);//attribut à l'opponenet la ball
	}
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		GetNode<Label>("Container/PlayerScore").Text = score[0].ToString();
		GetNode<Label>("Container/OpponentScore").Text = score[1].ToString();
		
	}
}
