using Godot;
using System;
using System.Linq;

public partial class BallMotion : Line2D
{
    Vector2 previousPosition = Vector2.Zero;
    float ballRadius = 0f;
    public override void _Ready()
    {
        Texture2D texture = GetParent<Sprite2D>().Texture;//récupère la taille de la texture
        ballRadius = texture.GetSize().X * 0.5f;//divise la taille par 2 pour récupérer le rayon
        previousPosition = GetParent<Sprite2D>().GlobalPosition;//récupère la position courante
    }

    public override void _Process(double delta)
    {
        Vector2 currentPosition = GetParent<Sprite2D>().GlobalPosition;//récupère la position courante
        Vector2 direction = (currentPosition - previousPosition).Normalized();//fait la différence entre les deux positions pour soustraire le radius
        AddPoint(currentPosition - ballRadius * direction);//crée un tracé
        if (this.Points.Count()>20)
        {
            this.RemovePoint(0);//laisse un tracé de 20 point
        }
        previousPosition = currentPosition;//attribut la position courante à la précédente
    }

}
