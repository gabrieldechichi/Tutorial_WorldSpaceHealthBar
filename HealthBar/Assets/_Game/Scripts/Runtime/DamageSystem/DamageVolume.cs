using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Collider))]
public class DamageVolume : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    public int damage = 1;

    private void Awake()
    {
        var thisCollider = GetComponent<Collider>();
        Assert.IsNotNull(thisCollider);
        Assert.IsTrue(thisCollider.isTrigger, "Collider must me marked as trigger");
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}
