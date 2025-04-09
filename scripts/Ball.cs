using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	[Export]
	int speed = 400;
	Vector2 ScreenSize;
	Vector2 velocity;
	Vector2 direction;
	
	private Vector2 GetRandomDirection()
	{
		Vector2 newDirection = new();
		RandomNumberGenerator rng = new();// création d'un nouvelle objet rng pour RandomNumberGenerator
		newDirection.X = rng.RandfRange(-1,1);//random direction en X
		newDirection.Y = rng.RandfRange(-1,1);//random direction en Y
		return newDirection.Normalized();//return du Vecteur 2 normalisé
	}

    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Position = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);
		velocity = GetRandomDirection() * speed;
		direction = velocity;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		KinematicCollision2D collision = MoveAndCollide(velocity * (float)delta);
		if (collision != null)
		{
			velocity = velocity.Bounce(collision.GetNormal()) * 1.05f;
			
		}
	}
}
