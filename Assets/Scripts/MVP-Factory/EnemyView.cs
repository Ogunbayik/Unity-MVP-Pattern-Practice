using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : MonoBehaviour, IEnemyView
{
    [Header("Enemy UI")]
    [SerializeField] private Button _hitButton;
    [SerializeField] private Image _healthFillImage;

    public event Action OnEnemyHitted;
    void Start() => _hitButton.onClick.AddListener(() => OnEnemyHitted?.Invoke());
    public void UpdateHealthFillAmount(float amount) => _healthFillImage.fillAmount = amount;
    public void SelfDestroy() => Destroy(gameObject);
    public class Factory : PlaceholderFactory<EnemyView> { }
}
