using UnityEngine;
using System;

namespace MONUMENT
{
    public class ForcesMovement : MonoBehaviour
    {
        public Action<float> OnGainSpiritPoints;

        [Header("References")]

        [SerializeField] private Rigidbody rb = null;
        [SerializeField] private Transform eyes = null;
        [SerializeField] private CameraHandler handler = null;
        [SerializeField] private AudioClip jumpSound = null;

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
        [SerializeField] private float pointsGainedWhenSpiritJump = 0f;
        [SerializeField] private float speedIncreaseHeight = 0f;

        [Header("Grounded Settings")]

        [SerializeField] private LayerMask groundMask = 0;
        [SerializeField] private LayerMask wallMask = 0;
        [SerializeField] private float wallRayLength = 0f;

        [SerializeField] private float groundColliderRadius = 0f;
        [SerializeField] private float groundColliderDownward = 0f;
        [SerializeField] private float maxGroundedAngle = 0f;

        private AudioSource audioSource;

        private bool isGrounded;
        private Vector3 wallJumpDirection;
        private Vector3 movement;
        private bool prevIsWalled;
        private bool isWalled;
        private bool jumpBoosted;

        private void Start()
        {
            //Application.targetFrameRate = 300;
            rb.sleepThreshold = 0f;
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isWalled))
                Jump();
        }

        private void Jump()
        {
            Vector3 vec = (isWalled ? wallJumpSpeed : jumpSpeed) * Vector3.up;

            if (jumpBoosted)
            {
                vec *= 2.5f;
                OnGainSpiritPoints?.Invoke(pointsGainedWhenSpiritJump);
            }

            if (rb.velocity.y < 0f) { vec.y -= rb.velocity.y; }

            rb.AddForce(vec, ForceMode.VelocityChange);

            if (isWalled)
            {
                rb.AddForce(wallJumpDirection * wallJumpSpeedHorizontal, ForceMode.VelocityChange);
                rb.AddForce(rb.velocity * velocityMult, ForceMode.VelocityChange);

                //jump sound (wall)
                float rndmPitch = UnityEngine.Random.Range(0.5f, 3f);
                audioSource.pitch = rndmPitch;
                audioSource.volume = 0.5f - (0.1f * rndmPitch);
                audioSource.PlayOneShot(jumpSound);

                OnGainSpiritPoints?.Invoke(pointsGainedWhenSpiritJump * 0.5f);
            }
        }

        private void FixedUpdate()
        {
            CheckIsGrounded();

            if (Input.GetKey(KeyCode.H))
            {
                rb.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
            }

            prevIsWalled = isWalled;
            CheckIsWalled();

            if (!prevIsWalled && isWalled)
            {
                rb.AddForce(rb.velocity.y * Vector3.down, ForceMode.VelocityChange);
                Vector3 vel = rb.velocity;
                vel.y = 0f;

                rb.AddForce(-vel * 0.3f, ForceMode.VelocityChange);
            }

            if (isWalled)
            {
                Vector3 vel = rb.velocity;
                vel.y = 0f;
                rb.velocity = vel;
            }

            rb.useGravity = !isWalled;

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, isGrounded ? maxGroundedVelocity : maxUngroundedVelocity);

            handler.Refresh(eyes.position, rb.velocity, Time.time);

            float acceleration = isGrounded ? movementAcceleration : movementAcceleration * ungroundedAccelerationMultiplier;

            movement = (transform.right * Input.GetAxisRaw("Horizontal")) + (transform.forward * Input.GetAxisRaw("Vertical"));
            movement.Normalize();

            Vector3 velocity = rb.velocity;

            velocity.y = 0f;

            float mag = velocity.magnitude;

            bool speedIncrease = transform.position.y > speedIncreaseHeight;
            if (speedIncrease) { movementCutoffVelocityMagnitude *= 1.5f; }

            if (mag < movementCutoffVelocityMagnitude)
            {
                rb.AddForce(Vector3.ClampMagnitude(acceleration * Time.fixedDeltaTime * movement, movementCutoffVelocityMagnitude - mag), ForceMode.VelocityChange);
            }
            else if (isGrounded)
            {
                rb.AddForce(Vector3.ClampMagnitude(acceleration * Time.fixedDeltaTime * -velocity.normalized, mag - movementCutoffVelocityMagnitude), ForceMode.VelocityChange);
            }

            if (speedIncrease) { movementCutoffVelocityMagnitude /= 1.5f; }

            Vector3 counterMovement = acceleration * Time.fixedDeltaTime * ungroundedAccelerationMultiplier * -(velocity.normalized - movement);

            if (mag != 0f && counterMovement.magnitude > mag) { counterMovement = -velocity; }

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
                    if (hit.transform.CompareTag("Cube") || hit.transform.CompareTag("Climbable"))
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
            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, wallRayLength, wallMask, QueryTriggerInteraction.Ignore) && hit.collider.CompareTag("Climbable"))
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