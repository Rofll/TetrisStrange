using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext : SignalContext {

    public MainContext(MonoBehaviour view)
        :base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<Config>().ToSingleton();

        injectionBinder.Bind<CreateMeshSc>().ToSingleton();
        injectionBinder.Bind<UpdateFiguresField>().ToSingleton();
        injectionBinder.Bind<CreateFieldMesh>().ToSingleton();
        injectionBinder.Bind<InputMove>().ToSingleton();
        injectionBinder.Bind<StayOnField>().ToSingleton();
        injectionBinder.Bind<CheckField>().ToSingleton();
        injectionBinder.Bind<CheckPossibleMove>().ToSingleton();

        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<UpdateFigureSignal>().To<UpdateFigureCommand>();
        commandBinder.Bind<CheckFieldSignal>().To<CheckFieldCommand>();
        commandBinder.Bind<ClickAudioSignal>().To<ClickAudioCommand>();
        commandBinder.Bind<DropAudioSignal>().To<DropAudioCommand>();
        commandBinder.Bind<GameOverSignal>().To<GameOverCommand>();

        mediationBinder.Bind<MainFieldView>().To<MainFieldMediator>();
        mediationBinder.Bind<FigureFieldView>().To<FigureFieldMediator>();
        mediationBinder.Bind<GameView>().To<GameMediator>();
        mediationBinder.Bind<UIView>().To<UIMediator>();
    }
}
