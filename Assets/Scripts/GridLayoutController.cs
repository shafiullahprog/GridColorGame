using UnityEngine;

public class GridLayoutController : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int height, width;
    float tileSize;

    [SerializeField] float zPos;

    private void Start()
    {
        tileSize = GridSizeValue.gridSizeRef;
        SpawnGrid();
    }

    void SpawnGrid()
    {
        float gridSize = GridSizeValue.gridSize;
        for(int i = 0; i < height; i++) 
        {
            for (int j = 0; j < width; j++)
            {
                GameObject grid = Instantiate(prefab,transform);
                float x = j * tileSize;
                float y = i * -tileSize;
                grid.transform.position = new Vector2 (x,y);
                grid.transform.localScale = new Vector3(gridSize, gridSize, gridSize);
            }
        }
        AlignGridToCenter();
        Debug.Log("Grid Spawned");
    }

    public void AlignGridToCenter()
    {
        float gridW = width * tileSize;
        float gridH = height * tileSize;
        transform.position = new Vector3 (-gridW/2 + tileSize/2 ,gridH/2 - tileSize/2, zPos);
    }
}
