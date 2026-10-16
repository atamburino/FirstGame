using Godot;

public partial class Player : Sprite2D
{
	[Export] public float Speed = 400f;
	[Export] public float SpinSpeed = 6f;

	public override void _Process(double delta)
	{
		// Arrow keys (built-in ui_* actions) plus WASD
		Vector2 dir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (Input.IsKeyPressed(Key.A)) dir.X -= 1;
		if (Input.IsKeyPressed(Key.D)) dir.X += 1;
		if (Input.IsKeyPressed(Key.W)) dir.Y -= 1;
		if (Input.IsKeyPressed(Key.S)) dir.Y += 1;
		dir = dir.LimitLength(1f);

		Position += dir * Speed * (float)delta;

		// Keep the player on screen
		Rect2 screen = GetViewportRect();
		Position = Position.Clamp(screen.Position, screen.End);

		// Spin while moving, just for fun
		if (dir != Vector2.Zero)
			Rotation += SpinSpeed * (float)delta;
	}
}
