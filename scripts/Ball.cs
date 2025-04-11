using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	[Export]
	float speed = 400;
	Vector2 ScreenSize;
	Vector2 velocity;
	public Vector2 direction;
	public bool stopped;

	public static void Stop()
	{
		direction = Vector2.Zero;

	}
	private static Vector2 GetRandomDirection()
	{
		Vector2 newDirection = new();
		RandomNumberGenerator rng = new();// création d'un nouvelle objet rng pour RandomNumberGenerator
		newDirection.X = rng.RandfRange(-1,1);//random direction en X
		newDirection.Y = rng.RandfRange(-1,1);//random direction en Y
		return newDirection.Normalized();//return du Vecteur 2 normalisé
	}

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;//récupère la taille de l'écran
		Position = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);//Place la balle au millieu de l'écran
		direction = GetRandomDirection();//donne une direction aléatoire à la balle
	}

	public override void _Process(double delta)
	{
		if (!stopped)
		{
		KinematicCollision2D collision = MoveAndCollide(direction * speed * (float)delta);//MoveAndCollide 
		if (collision != null)
		{
			if (speed < 1500)
			{
			speed *= 1.05f;
			GD.Print(speed);
			}
			direction = direction.Bounce(collision.GetNormal());
			
		}	
		}
		
	}

}
