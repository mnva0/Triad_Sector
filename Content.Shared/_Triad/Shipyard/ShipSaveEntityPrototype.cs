using Robust.Shared.Prototypes;
using Content.Shared.Whitelist;

namespace Content.Shared._Triad.Shipyard;

/// <summary>
/// Component to whitelist which component or tags that should be deleted when ship saving.
/// </summary>
[Prototype]
public sealed partial class ShipSaveEntityPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// Entities matching this blacklist will be deleted during ship save.
    /// </summary>
    [DataField]
    public EntityWhitelist Blacklist { get; private set; } = new();
}
