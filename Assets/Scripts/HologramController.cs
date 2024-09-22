using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramController : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint, hologramPrefab; // Reference to the hologram prefab
    private GameObject currentHologram; // Reference to the currently active hologram


    void Update()
    {
        float x = spawnPoint.transform.rotation.x + 90;

        Quaternion currentRotation = transform.localRotation;
        Vector3 modifiedRotationUp = currentRotation.eulerAngles + new Vector3(90, 0, 0);
        Vector3 modifiedRotationRight = currentRotation.eulerAngles + new Vector3(0,0,-90);
        Quaternion newRotation = Quaternion.Euler(modifiedRotationUp);

        //// Check if any arrow key is held
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Keep the hologram visible while a key is held
            if (currentHologram == null)
            {
                currentHologram = Instantiate(hologramPrefab, spawnPoint.transform.position, newRotation);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentHologram == null)
            {
                currentHologram = Instantiate(hologramPrefab,spawnPoint.transform.position, Quaternion.Euler(-90,0,0) * transform.localRotation);
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (currentHologram == null)
            {
                currentHologram = Instantiate(hologramPrefab, spawnPoint.transform.position, Quaternion.Euler(modifiedRotationRight));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentHologram == null)
            {
                currentHologram = Instantiate(hologramPrefab, spawnPoint.transform.position, Quaternion.Euler(90,0,90) * transform.localRotation);
            }
        }
        else
        {
            // Hide the hologram when no arrow key is held
            HideHologram();
        }
    }

    void HideHologram()
    {
        if (currentHologram != null)
        {
            Destroy(currentHologram);
            currentHologram = null;
        }
    }
}
