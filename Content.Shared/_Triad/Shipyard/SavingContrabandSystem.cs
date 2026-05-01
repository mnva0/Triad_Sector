using Content.Shared.Examine;

namespace Content.Shared._Triad.Shipyard;

public sealed class SavingContrabandSystem : EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<SavingContrabandComponent, ExaminedEvent>(OnExamined);
    }

    private void OnExamined(Entity<SavingContrabandComponent> ent, ref ExaminedEvent args)
    {
        if (ent.Comp.ExamineText == null)
            return;
        args.PushMarkup(Loc.GetString(ent.Comp.ExamineText));
    }
}
