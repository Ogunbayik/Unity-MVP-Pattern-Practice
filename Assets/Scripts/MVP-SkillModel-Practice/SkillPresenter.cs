using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkillPresenter : IInitializable, IDisposable, ITickable
{
    private SkillModel _model;
    private ISkillView _view;
    private Fireball.Factory _fireballFactory;
    private Transform _attackTransform;

    [Inject]
    public void Construct(SkillModel model, ISkillView view, Fireball.Factory factory, Transform attackTransform)
    {
        _model = model;
        _view = view;
        _fireballFactory = factory;
        _attackTransform = attackTransform;
    }

    public void Initialize()
    {
        _view.ToggleCooldownText(false);

        _view.OnClickSkillButton += View_OnClickSkillButton;
        _model.OnSkillReady += Model_OnSkillReady;
    }
    public void Dispose()
    {
        _view.OnClickSkillButton -= View_OnClickSkillButton;
        _model.OnSkillReady -= Model_OnSkillReady;
    }
    public void Tick()
    {
        _model.Tick(Time.deltaTime);

        if (!_model.IsReady)
        {
            _view.UpdateFillAmount(_model.GetReverseProgress());
            _view.UpdateCooldownText(_model.CurrentTime);
        }
    }
    private void View_OnClickSkillButton()
    {
        _view.SetButtonEnable(false);
        _view.SetSelectedColorAlpha(GameConstant.SkillConst.SKILL_CLICKED_FILL_AMOUNT);
        _view.ToggleCooldownText(true);

        _model.SetReadyStatus(false);

        var newFireball = _fireballFactory.Create();
        newFireball.Init(_attackTransform.position, _attackTransform.rotation);
    }
    private void Model_OnSkillReady()
    {
        _view.SetSelectedColorAlpha(GameConstant.SkillConst.SKILL_NORMAL_FILL_AMOUNT);
        _view.ToggleCooldownText(false);
        _view.SetButtonEnable(true);
    }
}
