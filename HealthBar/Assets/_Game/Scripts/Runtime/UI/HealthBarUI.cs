using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image healthBarFill;

    [SerializeField]
    private DamageableBehaviour damageable;

    [SerializeField]
    [Min(0.1f)]
    private float speed = 2;

    private void LateUpdate()
    {
        if (damageable != null)
        {
            //1 when CurrentHealth = MaxHealth, 0 when CurrentHealth = 0
            var healthPercent = (float) damageable.CurrentHealth / damageable.MaxHealth;
            healthBarFill.fillAmount = Mathf.Lerp(healthBarFill.fillAmount, healthPercent, Time.deltaTime*speed);
        }
    }
}
