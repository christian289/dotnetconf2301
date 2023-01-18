namespace GCKSpreadDotnet;

public class Entity : BaseEntity
{
    public Entity(string name, int price)
    {
        Name = name;
        Price = price;
    }

    private string name;

    public string Name
    {
        get => name;
        set
        {
            if (name == value) return;
            name = value;
            OnPropertyChanged();
        }
    }

    private int price;

    public int Price
    {
        get => price;
        set
        {
            if (price == value) return;
            price = value;
            OnPropertyChanged();
        }
    }
}
