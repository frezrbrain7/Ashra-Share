using UnityEngine;
using UnityEngine.Tilemaps;

public class YSortTile : MonoBehaviour
{
    private TilemapRenderer tilemapRenderer;

    [Header("Sorting")]
    public int sortingOffset = 0;

    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    void LateUpdate()
    {
        tilemapRenderer.sortingOrder =
            Mathf.RoundToInt(-transform.position.y * 100) + sortingOffset;
    }
}