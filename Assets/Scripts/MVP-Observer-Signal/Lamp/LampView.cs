using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LampView : MonoBehaviour, ILampView
{
    [SerializeField] private GameObject _lightGO;

    public void ToggleLight(bool isActive) => _lightGO.SetActive(isActive);
}
