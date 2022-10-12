
[System.Serializable]
public class SerializedItem
{
	public string itemName;
	public int amount;

	public SerializedItem(string itemName, int amount)
	{
		this.itemName = itemName;
		this.amount = amount;
	}
}