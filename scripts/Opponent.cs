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
        targetBall = ball;//assignation d'une nouvelle cible à l'opponent
    }

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;//récupération de la taille de l'écran
        Position = new Vector2(1122, ScreenSize.Y/2);//initialisation de la position au départ
        UseFullFunction uff=new();
        opponentSize = uff.GetSizeOfSprite2D(GetNode<Sprite2D>("Sprite2D")); // on calcule la taille du sprite2D
    }
    public override void _PhysicsProcess(double delta)
    {
        float direction = 0;
        if (targetBall == null)
            return;//si il n'y a pas de balle on assigne rien 
        else{
        if (Math.Abs(targetBall.Position.Y - Position.Y) > 10)//évite les tremblement
        {
            direction = targetBall.Position.Y > Position.Y ? 1 : -1; // assignation d'une direction en Y
        }
        if (direction != 0)//si la direction a une valeur
        {
            float velocityY = direction * speed * (float)delta;//on associe à la vélocité la direction et la vitesse ainsi que delta
            Vector2 newPosition = Position + new Vector2(0, velocityY);//récupération de la Position actuelle et attribution de la vitesse en Y à une nouvelle position

            float minY = opponentSize.Y / 2;
            float maxY = ScreenSize.Y - opponentSize.Y /2;

            newPosition.Y = Mathf.Clamp(newPosition.Y, minY, maxY);//Clamp avec les valeurs min et max définit juste au dessus

            Position = newPosition;//actualisation de la position
        }
        }
        
    }

}
