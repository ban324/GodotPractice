using Godot;
using System;

public partial class PoopManager : Node2D
{
	[Export]
	PackedScene poop;
	[Export]
	public double timer;
	[Export]
	public double duration;
	[Export]
	public bool timerStoped = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer += delta;
		if(timer > duration)
		{
			if(!timerStoped)
			{
				timer = 0;
				SummonPoop();
			}
		}
	}

	public void SummonPoop()
	{
		var p = poop.Instantiate<Poop>();
		AddChild(p);
		p.instantiate();
	}

	public void StopTimer()
	{
		timerStoped = true;
	}
}
