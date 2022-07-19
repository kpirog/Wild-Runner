using UnityEngine;

public class TemporaryPlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float levelBoundary;

    private Vector3 horizontalDirection;

    private void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < levelBoundary)
        {
            horizontalDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -levelBoundary)
        {
            horizontalDirection = Vector3.left;
        }
        else
        {
            horizontalDirection = Vector3.zero;
        }

        transform.position += horizontalDirection;
    }
}
