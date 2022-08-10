using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Vector3 PlatformToCameraOffset;
    public float Speed;

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (player.CurrentPlatform == null)
        {
            return;
        }

        Vector3 targetPosition = player.CurrentPlatform.transform.position + PlatformToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }
}