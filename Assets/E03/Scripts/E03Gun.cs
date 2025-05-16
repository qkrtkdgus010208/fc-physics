using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E03Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
