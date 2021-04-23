using System;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(IDamageable))]
public class PlayerController : MonoBehaviour
{
    public CharacterMovement CharacterMovement { get; private set; }
    public IDamageable Damageable { get; private set; }

    private void Awake()
    {
        CharacterMovement = GetComponent<CharacterMovement>();
        Damageable = GetComponent<IDamageable>();
        Damageable.DamageEvent += OnDamage;
        Damageable.DeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        if (Damageable != null)
        {
            Damageable.DamageEvent -= OnDamage;
            Damageable.DeathEvent -= OnDeath;
        }
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        CharacterMovement.SetMovementInput(new Vector2(horizontal, vertical));
    }

    private void OnDeath()
    {
        enabled = false;
    }

    private void OnDamage(DamageEventParams obj)
    {
        CharacterMovement.StopImmediatelly();
    }
}
