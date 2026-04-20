using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField] private float aboveBoundary = 10f;
    [SerializeField] private float belowBoundary = -10f;
    [SerializeField] private float leftBoundary = -10f;
    [SerializeField] private float rightBoundary = 10f;
    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetVerticalBoundary()
    {
        return new Vector2(aboveBoundary, belowBoundary);
    }

    public Vector2 GetHorizontalBoundary()
    {
        return new Vector2(leftBoundary, rightBoundary);
    }
}
