using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GameStateSOReference : BaseReference<GameStateSO, GameStateSOVariable>
	{
	    public GameStateSOReference() : base() { }
	    public GameStateSOReference(GameStateSO value) : base(value) { }
	}
}