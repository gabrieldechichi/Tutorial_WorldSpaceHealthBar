using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private Animator animator;

    private int movementParameterId;
    private int damageTriggerParameterId;
    private int deadTriggerParameterId;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementParameterId = Animator.StringToHash("Movement");
        damageTriggerParameterId = Animator.StringToHash("Damaged");
        deadTriggerParameterId = Animator.StringToHash("Dead");
    }

    private void Start()
    {
        playerController.Damageable.DamageEvent += OnDamage;
        playerController.Damageable.DeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        if (playerController != null && playerController.Damageable != null)
        {
            playerController.Damageable.DamageEvent -= OnDamage;
            playerController.Damageable.DeathEvent -= OnDeath;
        }
    }

    private void FixedUpdate()
    {
        var characterMovement = playerController.CharacterMovement;
        var speedPercent = characterMovement.CurrentVelocity.sqrMagnitude / (characterMovement.GroundSpeed*characterMovement.GroundSpeed);
        animator.SetFloat(movementParameterId, speedPercent);
    }

    private void OnDeath()
    {
        animator.SetTrigger(deadTriggerParameterId);
    }

    private void OnDamage(DamageEventParams obj)
    {
        animator.SetTrigger(damageTriggerParameterId);
    }
}
