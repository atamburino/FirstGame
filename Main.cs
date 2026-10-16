using Godot;

public partial class Main : Node2D
{
	[Export] public float PickupDistance = 60f;
	[Export] public float SpawnMargin = 40f;

	private Sprite2D _player;
	private Coin _coin;
	private Label _scoreLabel;
	private int _score;

	private readonly RandomNumberGenerator _rng = new();

	public override void _Ready()
	{
		_player = GetNode<Sprite2D>("Player");
		_coin = GetNode<Coin>("Coin");
		_scoreLabel = GetNode<Label>("ScoreLabel");

		_rng.Randomize(); // different coin spots every run
		MoveCoin();
		UpdateScore();
	}

	public override void _Process(double delta)
	{
		if (_player.Position.DistanceTo(_coin.Position) < PickupDistance)
		{
			_score++;
			UpdateScore();
			MoveCoin();
		}
	}

	private void MoveCoin()
	{
		// Pick a random spot on screen, keeping away from the edges
		Vector2 size = GetViewportRect().Size;
		_coin.Position = new Vector2(
			_rng.RandfRange(SpawnMargin, size.X - SpawnMargin),
			_rng.RandfRange(SpawnMargin, size.Y - SpawnMargin));
	}

	private void UpdateScore() => _scoreLabel.Text = $"Score: {_score}";
}
