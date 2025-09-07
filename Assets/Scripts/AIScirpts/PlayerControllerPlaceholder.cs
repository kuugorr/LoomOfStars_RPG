using UnityEngine;
using UnityEngine.AI;

// Placeholder controller: replace with Cinemachine + Input System or Starter Assets
public class PlayerControllerPlaceholder : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;
    CharacterController controller;



    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var dir = new Vector3(h, 0, v);
        if (dir.magnitude > 0.1f)
        {
            controller.SimpleMove(dir.normalized * moveSpeed);
            transform.forward = Vector3.Lerp(transform.forward, dir.normalized, Time.deltaTime * 10f);
        }
    }
}
