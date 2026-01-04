using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Fireball : MonoBehaviour
{
    private float _movementSpeed;

    [Inject]
    public void Consruct(float movementSpeed = GameConstant.SkillConst.SKILL_MOVEMENTSPEED)
    {
        _movementSpeed = movementSpeed;
    }
    public void Init(Vector3 position, Quaternion rotation) => transform.SetPositionAndRotation(position, rotation);
    private void Start() => SelfDestroy(GameConstant.SkillConst.SKILL_DESTROY_TIME);
    void Update() => transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    public void SelfDestroy(float time) => Destroy(gameObject, time);
    public class Factory : PlaceholderFactory<Fireball> { }
}
