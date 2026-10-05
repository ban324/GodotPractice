using Godot;
using System;
public partial class Poop : Area2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public int minSpeed = 0;
	[Export]
	public int maxSpeed = 0;
	public int Speed=30;
	public override void _Ready()
	{
		instantiate();
	}
	public void instantiate()
	{
		Random rand = new Random();
		double _xRange = rand.NextDouble() * 720f;
		Vector2 _startPos;
		_startPos.X = (float)_xRange;
		_startPos.Y = 0 - Scale.X * 32;
		Position = _startPos;
		Speed = rand.Next(minSpeed, maxSpeed);

	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;
		velocity.Y += Speed * (float)delta;
		Position += velocity;
		if(Position.Y > 480)
		{
			QueueFree();
		}
	}
}
