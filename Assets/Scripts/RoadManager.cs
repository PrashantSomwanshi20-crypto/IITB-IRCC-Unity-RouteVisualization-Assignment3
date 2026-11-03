using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public bool isBlocked = false; // Check karne ke liye ki road block hai ya nahi
    private Renderer roadRenderer;

    void Start()
    {
        roadRenderer = GetComponent<Renderer>();
    }

    // Road ko block ya unblock karne ka function
    public void ToggleRoadBlock(bool blockStatus)
    {
        isBlocked = blockStatus;

        if (roadRenderer != null)
        {
            // Agar road block ho toh Red color ho jaye, warna Grey
            roadRenderer.material.color = isBlocked ? Color.red : Color.gray;
        }
    }
}