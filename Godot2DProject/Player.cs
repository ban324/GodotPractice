using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

	Vector2 _screenSize= Vector2.Zero; // Size of the game window.
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//SOMETHINGcHANGE
		 _screenSize.X = 720/2;
		_screenSize.Y = 480;
		_screenSize.Y -= Scale.Y*32;
		Position = _screenSize;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;
		if(Input.IsActionPressed("Right"))
		{
			velocity.X = 1;
		}
		if(Input.IsActionPressed("Left"))
		{
			velocity.X = -1;
		}
 	   AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

 	   if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}
		Position += velocity * (float)delta; 
	}
}
