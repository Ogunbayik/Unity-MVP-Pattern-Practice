using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPresenter : IInitializable, IDisposable
{
    private EnemyModel _model;
    private IEnemyView _view;


    public EnemyPresenter(EnemyModel model, IEnemyView view)
    {
        _model = model;
        _view = view;
    }
    public void Initialize()
    {
        _view.OnEnemyHitted += View_OnEnemyHitted;
        _model.OnEnemyHealthChanged += Model_OnEnemyHealthChanged;
        _model.OnEnemyDead += Model_OnEnemyDead;
    }
    public void Dispose()
    {
        _view.OnEnemyHitted -= View_OnEnemyHitted;
        _model.OnEnemyHealthChanged -= Model_OnEnemyHealthChanged;
        _model.OnEnemyDead -= Model_OnEnemyDead;
    }
    private void View_OnEnemyHitted() => _model.TakeDamage(GameConstant.HealthConst.TEST_DAMAGE);
    private void Model_OnEnemyHealthChanged(int currentHealth)
    {
        var healthPercentage = (float)currentHealth / _model.InitialHealth;
        _view.UpdateHealthFillAmount(healthPercentage);
        Debug.Log(currentHealth);
    }
    private void Model_OnEnemyDead() => _view.SelfDestroy();
}
