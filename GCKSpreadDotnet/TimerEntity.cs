namespace GCKSpreadDotnet;

public class TimerEntity : BaseEntity
{
	private string datetime;

	public string Datetime
	{
		get => datetime;
		set
		{
			if (datetime == value) return;
			datetime = value;
			OnPropertyChanged();
		}
	}
}