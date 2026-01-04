using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LampPresenter : IInitializable, IDisposable
{
    private SignalBus _signalBus;

    private LampModel _model;
    private ILampView _view;

    [Inject]
    public void Construct(SignalBus signalBus, LampModel model, ILampView view)
    {
        _signalBus = signalBus;
        _model = model;
        _view = view;
    }
    public void Initialize() => _signalBus.Subscribe<GameSignal.DayNightChangeSignal>(SwitchNightMode);
    public void Dispose() => _signalBus.Unsubscribe<GameSignal.DayNightChangeSignal>(SwitchNightMode);

    public void SwitchNightMode(GameSignal.DayNightChangeSignal signal)
    {
        _model.SetNightMode(signal.IsNight);
        _view.ToggleLight(_model.IsNightMode);
    }
}
