using Content.Shared.Mobs;
using Content.Shared.Cloning;
using Content.Shared.Mind;

namespace Content.Server.Cloning;

// TODO: Check if can clone
// TODO: Rename CloningConsole

public sealed class AutoCloneSystem : EntitySystem
{
    [Dependency] private readonly CloningSystem _cloning = default!;
    [Dependency] private readonly SharedMindSystem _minds = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AutoCloneComponent, MobStateChangedEvent>(OnMobState);
    }

    private void OnMobState(EntityUid ent, AutoCloneComponent component, MobStateChangedEvent args)
    {
        //if (!Resolve(component.CloningConsole, CloningConsoleComponent));
        //    return; // TODO: Unwise.

        if (args.NewMobState is MobState.Dead)
        {
            //if (TryComp<CloningConsoleComponent>(component.CloningConsole, out CloningConsoleComponent? console))
            //{
            if (!_minds.TryGetMind(ent, out var mindId, out var mindComp))
                return;
            if (!TryComp<AutoCloneComponent>(ent, out var autoclone))
                return;
            if (!TryComp<CloningPodComponent>(autoclone.CloningConsole, out var cloner))
                return;
            if (autoclone.CloningConsole != null)
                _cloning.TryCloning(autoclone.CloningConsole.Value, args.Target, (mindId, mindComp), cloner);
            //}
        }
    }
}
