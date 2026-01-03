using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TimePresenter : IInitializable, IDisposable
{
    private TimeModel _model;
    private ITimeView _view;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(TimeModel model, ITimeView view, SignalBus signalBus)
    {
        _model = model;
        _view = view;
        _signalBus = signalBus;
    }
    public void Initialize()
    {
        _view.UpdateDayText(_model.DayStatus);

        _view.OnClickedSwitchButton += View_OnClickedSwitchButton;
    }
    public void Dispose() => _view.OnClickedSwitchButton -= View_OnClickedSwitchButton;
    private void View_OnClickedSwitchButton()
    {
        _model.ToggleDayNight();
        _view.UpdateDayText(_model.DayStatus);
        _view.SetDirectionLightRotation(_model.CurrentLightRotation);

        _signalBus.Fire(new GameSignal.DayNightChangeSignal(_model.IsNight));
    }
}
