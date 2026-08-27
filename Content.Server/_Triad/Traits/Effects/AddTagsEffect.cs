using Content.Shared._DV.Traits.Effects;
using Content.Shared.Tag;
using Robust.Shared.Prototypes;

namespace Content.Server._Triad.Traits.Effects;

/// <summary>
/// Effect that adds tags to the player entity.
/// </summary>
public sealed partial class AddTagsEffect : BaseTraitEffect
{
    [Dependency] private TagSystem _tag = default!;

    [DataField(required: true)]
    public List<ProtoId<TagPrototype>> Tags = new();

    public override void Apply(TraitEffectContext ctx)
    {
        _tag.AddTags(ctx.Player, Tags);
    }
}
