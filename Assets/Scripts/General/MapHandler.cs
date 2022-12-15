using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    static List<GameObject> map;
    [SerializeField]
    GameObject MapPrefab;

    void Awake()
    {
        GameObject leftMap = Instantiate(MapPrefab, new Vector3(-73, 0, 1), Quaternion.identity);
        GameObject centerMap = Instantiate(MapPrefab, new Vector3(0, 0, 1), Quaternion.identity);
        GameObject rightMap = Instantiate(MapPrefab, new Vector3(73, 0, 1), Quaternion.identity);

        // Remove collider from center map as we don't care about collisions on it
        Destroy(centerMap.GetComponent<BoxCollider2D>());

        map = new List<GameObject> { leftMap, centerMap, rightMap };
    }

    public void HandleMapTiling(GameObject child)
    {
        // Check if map is left or right
        if (child.GetInstanceID() == map[0].GetInstanceID())
        {
            // Collision with left map has occurred

            for (int i = 0; i < map.Count; i++)
            {
                map[i].transform.position = new Vector3(map[i].transform.position.x - 73, 0, 1);
            }
        }
        else if (child.GetInstanceID() == map[2].GetInstanceID())
        {
            // Collision with right map has occurred

            for (int i = 0; i < map.Count; i++)
            {
                map[i].transform.position = new Vector3(map[i].transform.position.x + 73, 0, 1);
            }
        }
        else
        {
            Debug.Log("Should be unreachable");
        }
    }
}
