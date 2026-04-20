using UnityEngine;
using TMPro;

public class HeightUI : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI heightText;

    private float maxHeight = 0f;

    void Update()
    {
        if (player == null || heightText == null) return;

        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
        }

        heightText.text = "Height: " + Mathf.FloorToInt(maxHeight).ToString();
    }
}