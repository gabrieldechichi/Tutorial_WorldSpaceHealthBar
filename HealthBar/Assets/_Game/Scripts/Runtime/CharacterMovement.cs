using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private float groundSpeed = 2;

    [SerializeField]
    [Min(0)]
    private float rotateSpeed = 2;

    [SerializeField]
    private float groundAcceleration = 100.0f;
    
    public float GroundSpeed => groundSpeed;

    private Rigidbody rb;

    public Vector3 CurrentVelocity { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Move CharacterController
        rb.MovePosition(rb.position + CurrentVelocity*Time.fixedDeltaTime);

        //Look towards movement
        if (CurrentVelocity.sqrMagnitude > 0.01)
        {
            var lookRotation = Quaternion.LookRotation(CurrentVelocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
        }
    }

    public void SetMovementInput(Vector2 movementInput)
    {
        var desiredVelocity = new Vector3(movementInput.x, 0, movementInput.y) * groundSpeed;
        CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, desiredVelocity, groundAcceleration * Time.deltaTime);
    }

    public void StopImmediatelly()
    {
        CurrentVelocity = Vector3.zero;
    }
}
