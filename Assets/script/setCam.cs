using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCam : MonoBehaviour
{
    public Animator player;
    public Transform playerPosition;
    public static Vector3 targetPosition;
    public float targetSize = 11f;
    public float duration = 1.5f;
    public float decrease = 3.2f;
    public static Vector3 distance;

    private Camera mainCamera;
    public static Vector3 initialPosition;
    private float initialSize;
    private float elapsedTime = 0f;

    void Start()
    {
        mainCamera = Camera.main;
        targetPosition = new Vector3(playerPosition.position.x + decrease, playerPosition.position.y, transform.position.z);
        initialPosition = mainCamera.transform.position;
        initialSize = mainCamera.orthographicSize;
        StartCoroutine(MoveAndExpandCamera());
    }

    IEnumerator MoveAndExpandCamera()
    {
        yield return new WaitForSeconds(duration);
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, t);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the camera is at the target position and size
        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetSize;
        camFl.startFL = true;
        distance = new Vector3(playerPosition.position.x + decrease,playerPosition.position.y, transform.position.z) - playerPosition.position;
    }
}
