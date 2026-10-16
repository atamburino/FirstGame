using Godot;

public partial class Coin : Node2D
{
	[Export] public float Radius = 16f;

	private float _time;

	public override void _Process(double delta)
	{
		// Gentle pulse so the coin catches your eye
		_time += (float)delta;
		float s = 1f + 0.15f * Mathf.Sin(_time * 6f);
		Scale = new Vector2(s, s);
	}

	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, Radius, new Color(1f, 0.84f, 0f));          // gold
		DrawCircle(Vector2.Zero, Radius * 0.6f, new Color(1f, 0.93f, 0.4f)); // shine
	}
}
