using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public GameObject tilePrefab;

    public int width = 5;
    public int height = 3;

    public float spacing = 1.2f;

    public List<GameObject> tiles =
        new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(
                    x * spacing,
                    0,
                    z * spacing
                );

                GameObject tile = Instantiate(
                    tilePrefab,
                    pos,
                    Quaternion.identity
                );

                tiles.Add(tile);
            }
        }
    }

    public void HideGrid()
    {
        foreach (GameObject tile in tiles)
        {
            tile.SetActive(false);
        }
    }
}