namespace Content.Shared.Cloning;

[RegisterComponent]
public sealed partial class AutoCloneComponent : Component
{
    /// <summary>
    /// The cloning console we will request cloning from
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    public EntityUid? CloningConsole;

    /// <summary>
    /// See TODO FANCY CODE LINK FOR CLONINGSYSTEM
    /// </summary>
    [DataField("failChanceModifier"), ViewVariables(VVAccess.ReadWrite)]
    public float FailChanceModifier = 1f;
}
