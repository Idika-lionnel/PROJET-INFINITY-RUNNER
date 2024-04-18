using UnityEngine;

public class MapDuplication : MonoBehaviour
{
    public GameObject mapToDuplicate;
    public float duplicationOffset;
    private bool hasDuplicated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDuplicated)
        {
            DuplicateMap();
            hasDuplicated = true;
        }
    }

    private void DuplicateMap()
    {
        // Calculate the position of duplication based on the length of the previous map
        float mapLength = mapToDuplicate.GetComponent<Renderer>().bounds.size.x;
        Vector3 newPosition = mapToDuplicate.transform.position + Vector3.forward * mapLength;

        // Duplicate the map at the new position
        GameObject newMap = Instantiate(mapToDuplicate, newPosition, Quaternion.identity);

        // Set the rotation of the new map to be the same as the original map
        newMap.transform.rotation = mapToDuplicate.transform.rotation;
    }
}
