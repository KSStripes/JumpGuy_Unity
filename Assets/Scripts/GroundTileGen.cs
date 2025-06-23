using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTileGen : MonoBehaviour
{
    public Tilemap tilemap; // Assign in Inspector
    public TileBase[] groundTiles; //ref to my tilemap folder
    public int witdth = 20;
    public int yLevel = -3; 

    // Start is called before the first frame update
    void Start()
    {
        GenerateGround();
    }

    // Generates Ground procedurally at start
    void GenerateGround()
    {
        for (int x = 0; x < witdth; x++)
        {
            // choose tiles
            int tileIndex = Random.Range(0, groundTiles.Length);
            tilemap.SetTile(new Vector3Int(x, yLevel, 0), groundTiles[tileIndex]);
        }
    }
}
