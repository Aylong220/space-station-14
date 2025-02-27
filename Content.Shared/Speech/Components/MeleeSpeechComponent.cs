using Content.Shared.Speech.EntitySystems;
using Robust.Shared.Serialization;

namespace Content.Shared.Speech.Components;

[RegisterComponent]
[AutoGenerateComponentState]
[Access(typeof(SharedMeleeSpeechSystem), Other = AccessPermissions.ReadWrite)]
public sealed partial class MeleeSpeechComponent : Component
{

	[ViewVariables(VVAccess.ReadWrite)]
	[DataField("Battlecry")]
	[AutoNetworkedField]
	[Access(typeof(SharedMeleeSpeechSystem), Other = AccessPermissions.ReadWrite)]
	public string? Battlecry;
}

/// <summary>
/// Key representing which <see cref="BoundUserInterface"/> is currently open.
/// Useful when there are multiple UI for an object. Here it's future-proofing only.
/// </summary>
[Serializable, NetSerializable]
public enum MeleeSpeechUiKey : byte
{
    Key,
}

/// <summary>
/// Represents an <see cref="MeleeSpeechComponent"/> state that can be sent to the client
/// </summary>
[Serializable, NetSerializable]
public sealed class MeleeSpeechBoundUserInterfaceState : BoundUserInterfaceState
{
    public string CurrentBattlecry { get; }

    public MeleeSpeechBoundUserInterfaceState(string currentBattlecry)
    {
        CurrentBattlecry = currentBattlecry;
    }
}

[Serializable, NetSerializable]
public sealed class MeleeSpeechBattlecryChangedMessage : BoundUserInterfaceMessage
{
    public string Battlecry { get; }
    public MeleeSpeechBattlecryChangedMessage(string battlecry)
    {
        Battlecry = battlecry;
    }
}
