using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthPresenter : IInitializable, IDisposable
{
    private HealthModel _model;
    private IHealthView _view;

    [Inject]
    public void Construct(HealthModel model, IHealthView view)
    {
        _model = model; 
        _view = view;
    }
    public void Initialize()
    {
        _view.UpdateHealthText(_model.CurrentHealth);
        _view.ToggleGameOverPanel(false);

        _view.OnClickDamageButton += View_OnClickDamageButton;
        _model.OnHealthChanged += Model_OnHealthChanged;
        _model.OnDead += Model_OnDead;
    }
    public void Dispose()
    {
        _view.OnClickDamageButton -= View_OnClickDamageButton;
        _model.OnHealthChanged -= Model_OnHealthChanged;
        _model.OnDead -= Model_OnDead;
    }
    private void View_OnClickDamageButton() =>_model.TakeDamage(GameConstant.HealthConst.TEST_DAMAGE);
    private void Model_OnHealthChanged(int currentHealth) => _view.UpdateHealthText(currentHealth);
    private void Model_OnDead() => _view.ToggleGameOverPanel(true);

}
