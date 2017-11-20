using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class SignalContext : MVCSContext {

    public SignalContext(MonoBehaviour view) : base(view)
	{

    }

    public SignalContext(MonoBehaviour contextView, ContextStartupFlags flags)
        : base(contextView, flags)
    {

    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    override public IContext Start()
    {
        base.Start();
        AppStartSignal startSignal = (AppStartSignal)injectionBinder.GetInstance<AppStartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        base.mapBindings();
    }
}
