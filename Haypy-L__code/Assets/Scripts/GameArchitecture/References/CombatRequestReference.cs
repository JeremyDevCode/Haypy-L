using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CombatRequestReference : BaseReference<CombatRequest, CombatRequestVariable>
	{
	    public CombatRequestReference() : base() { }
	    public CombatRequestReference(CombatRequest value) : base(value) { }
	}
}