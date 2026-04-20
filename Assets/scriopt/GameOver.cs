using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;
    public float loseDistanceBelowCamera = 6f;

    void Update()
    {
        if (player == null || mainCamera == null) return;

        float cameraBottom = mainCamera.transform.position.y - loseDistanceBelowCamera;

        if (player.position.y < cameraBottom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}