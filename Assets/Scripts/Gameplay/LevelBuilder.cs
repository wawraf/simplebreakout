using UnityEditor;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject standardBlockPrefab;

    [SerializeField]
    GameObject bonusBlockPrefab;

    [SerializeField]
    GameObject effectBlockPrefab;

    float width;
    float height;
    float ROWS = 3;

    // Start is called before the first frame update
    void Start()
    {
        // creating temporary block to retrieve height and width
        GameObject tempBlock = Instantiate<GameObject>(standardBlockPrefab);
        BoxCollider2D boxCollider2D = tempBlock.GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x * tempBlock.transform.localScale.x;
        height = boxCollider2D.size.y * tempBlock.transform.localScale.y;
        Destroy(tempBlock);

        CreateLevel();
    }

    void CreateLevel()
    {
        AddEdgeCollider();
        float side = Mathf.Floor(ScreenUtils.ScreenRight / width);
        if (side * width + width * 0.5 > ScreenUtils.ScreenRight) side -= 1;
        float columns = side * 2 + 1;
        float start_from = -(side * width);

        for (int j = 0; j < ROWS; j++)
        {
            for (int i = 0; i < columns; i++)
            {
                GameObject prefab = ChooseBlock();
                GameObject block = Instantiate(prefab, new Vector3(start_from + i * width, 3 - j * height), Quaternion.identity);
                EffectBlock effectBlock = block.GetComponent<EffectBlock>();
                if (effectBlock != null)
                {
                    effectBlock.BlockEffectName = prefab.GetComponent<EffectBlock>().BlockEffectName;
                }
            }
        }

    }

    GameObject ChooseBlock()
    {
        GameObject prefab;
        float rand = Random.Range(0, 100);
        if (rand < 70)
        {
            prefab = standardBlockPrefab;
        } 
        else if (rand < 90)
        {
            prefab = bonusBlockPrefab;
        }
        else if (rand < 95)
        {
            prefab = effectBlockPrefab;
            prefab.GetComponent<EffectBlock>().BlockEffectName = EffectName.Freezer;
        }
        else
        {
            prefab = effectBlockPrefab;
            prefab.GetComponent<EffectBlock>().BlockEffectName = EffectName.Speedup;
        }

        return prefab;
    }

    void AddEdgeCollider()
    {
        if (Camera.main == null) { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

        var cam = Camera.main;
        if (!cam.orthographic) { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        // add or use existing EdgeCollider2D
        var edge = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight };
        edge.points = edgePoints;
    }
}
