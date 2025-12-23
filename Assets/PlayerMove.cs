using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D, Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S, Up/Down

        Vector3 dir = new Vector3(h, 0f, v).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}