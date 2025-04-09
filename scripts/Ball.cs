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

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;//récupère la taille de l'écran
		Position = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);//Place la balle au millieu de l'écran
		direction = GetRandomDirection() * speed;//donne une direction aléatoire à la balle
	}

	public override void _Process(double delta)
	{
		
		KinematicCollision2D collision = MoveAndCollide(direction * (float)delta);//MoveAndCollide 
		if (collision != null)
		{
			direction = direction.Bounce(collision.GetNormal()) * 1.05f;
			
		}
	}
}
