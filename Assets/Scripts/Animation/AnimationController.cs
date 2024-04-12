using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator PlayerAnim;
    public PlayerMovement playerMovement;

    public enum AirborneState { NotAirborne, Jumping, Falling };
    public AirborneState airborneState;

    private void Update()
    {
        UpdatePlayerState();
    }

    void UpdatePlayerState()
    {
        if (!playerMovement.controller.isGrounded)
        {
            if (playerMovement.playerVelocity.y > 1)
            {
                airborneState = AirborneState.Jumping;
            }
            else
            {
                airborneState = AirborneState.Falling;
            }
        }
        else
        {
            airborneState = AirborneState.NotAirborne;
        }

        float playerZVelocity = Mathf.Abs(playerMovement.controllerVelocity.z);
        float playerXVelocity = Mathf.Abs(playerMovement.controllerVelocity.x);

        if (playerXVelocity > 0.1)
        {
            PlayerAnim.SetFloat("Speed", playerXVelocity / 4);
        }
        else if (playerZVelocity > 0.1)
        {
            PlayerAnim.SetFloat("Speed", playerZVelocity / 4);
        }
        else
        {
            PlayerAnim.SetFloat("Speed", 0f);
        }

        PlayerAnim.SetInteger("Airborne", (int)airborneState);
    }
}
