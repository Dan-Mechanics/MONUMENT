using UnityEngine;

namespace MONUMENT
{
    /// <summary>
    /// Project add pixelated look with rendertextur.
    /// 
    /// Gotta try unity unit tests !! poggg
    /// </summary>
    public class ForcesMovement1 : MonoBehaviour
    {
        [Header("References")]

        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Transform eyes = null;
        [SerializeField] private CameraHandler handler = null;
        //[SerializeField] private TowerActivator towerActivator = null;
        //[SerializeField] private MaterialColor materialColor = null;

        [Header("Movement Settings")]

        [SerializeField] private float movementCutoffVelocityMagnitude = 0f;
        [SerializeField] private float maxGroundedVelocity = 0f;
        [SerializeField] private float maxUngroundedVelocity = 0f;
        [SerializeField] private float movementAcceleration = 0f;
        [SerializeField] private float ungroundedAccelerationMultiplier = 0f;

        [SerializeField] private float jumpSpeed = 0f;
        [SerializeField] private float wallJumpSpeed = 0f;
        [SerializeField] private float wallJumpSpeedHorizontal = 0f;
        [SerializeField] private float velocityMult = 0f;

        [Header("Grounded Settings")]

        [SerializeField] private LayerMask groundMask = 0;
        [SerializeField] private LayerMask wallMask = 0;
        [SerializeField] private float wallRayLength = 0f;

        [SerializeField] private float groundColliderRadius = 0f;
        [SerializeField] private float groundColliderDownward = 0f;
        [SerializeField] private float maxGroundedAngle = 0f;
        

        private bool isGrounded;
        private Vector3 wallJumpDirection;
        private Vector3 movement;
        private bool prevIsWalled;
        private bool isWalled;
        private bool jumpBoosted;

        private void Start()
        {
            Application.targetFrameRate = 300;
            rb.sleepThreshold = 0f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isWalled))
                Jump();
        }

        private void Jump()
        {
            Vector3 vec = (jumpBoosted ? 2.5f : 1f) * (isWalled ? wallJumpSpeed : jumpSpeed) * Vector3.up;

            if (rb.velocity.y < 0f) { vec.y -= rb.velocity.y; }

            if (isWalled) 
            { 
                rb.AddForce(wallJumpDirection * wallJumpSpeedHorizontal, ForceMode.VelocityChange);
                rb.AddForce(rb.velocity * velocityMult, ForceMode.VelocityChange);
                //rb.AddForce(0.5f * wallJumpSpeedHorizontal * movement, ForceMode.VelocityChange);
            }
            rb.AddForce(vec, ForceMode.VelocityChange);
        }

        private void FixedUpdate()
        {
            CheckIsGrounded();

            prevIsWalled = isWalled;
            CheckIsWalled();

            if (!prevIsWalled && isWalled)
            {
                rb.AddForce(rb.velocity.y * Vector3.down, ForceMode.VelocityChange);
                Vector3 vel = rb.velocity;
                vel.y = 0f;
                
                rb.AddForce(-vel * 0.3f, ForceMode.VelocityChange);
            }

            rb.useGravity = !isWalled;

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, isGrounded ? maxGroundedVelocity : maxUngroundedVelocity);

            handler.Refresh(eyes.position, rb.velocity, Time.time);

            float acceleration = isGrounded ? movementAcceleration : movementAcceleration * ungroundedAccelerationMultiplier;

            movement = (transform.right * Input.GetAxisRaw("Horizontal")) + (transform.forward * Input.GetAxisRaw("Vertical"));
            movement.Normalize();

            Vector3 velocity = rb.velocity;

            //materialColor.value = velocity.magnitude / maxGroundedVelocity;

            velocity.y = 0f;

            float mag = velocity.magnitude;

            if (mag < movementCutoffVelocityMagnitude)
            {
                rb.AddForce(Vector3.ClampMagnitude(acceleration * Time.fixedDeltaTime * movement, movementCutoffVelocityMagnitude - mag), ForceMode.VelocityChange);
            }
            else if (isGrounded)
            {
                rb.AddForce(Vector3.ClampMagnitude(acceleration * Time.fixedDeltaTime * -velocity.normalized, mag - movementCutoffVelocityMagnitude), ForceMode.VelocityChange);
            }

            Vector3 counterMovement = acceleration * Time.fixedDeltaTime * ungroundedAccelerationMultiplier * -(velocity.normalized - movement);

            if (mag != 0f && counterMovement.magnitude > mag) { counterMovement = -velocity;  }

            rb.AddForce(counterMovement, ForceMode.VelocityChange);
        }

        private void CheckIsGrounded()
        {
            isGrounded = false;
            jumpBoosted = false;

            RaycastHit[] hits = Physics.SphereCastAll(transform.position, groundColliderRadius, Vector3.down, groundColliderDownward, groundMask, QueryTriggerInteraction.Ignore);

            foreach (RaycastHit hit in hits)
            {
                if (hit.distance == 0f) { continue; }

                if (Vector3.Angle(Vector3.up, hit.normal) <= maxGroundedAngle)
                {
                    isGrounded = true;
                    if (hit.transform.CompareTag("Cube")) 
                    {
                        jumpBoosted = true;
                    }
                }
            }
        }

        private void CheckIsWalled()
        {
            if (CheckWall(Vector3.forward) || CheckWall(Vector3.back) || CheckWall(Vector3.left) || CheckWall(Vector3.right))
                return;

            wallJumpDirection = Vector3.zero;
            isWalled = false;
        }

        private bool CheckWall(Vector3 dir) 
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, wallRayLength, wallMask, QueryTriggerInteraction.Ignore))
            {
                isWalled = true;
                wallJumpDirection = hit.normal;

                return true;
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = (Color.blue + Color.white) / 2f;
            Gizmos.DrawWireSphere(transform.position + (Vector3.down * groundColliderDownward), groundColliderRadius);
        }
    }
}