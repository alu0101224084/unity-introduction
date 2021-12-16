using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        
        Debug.Log("hola");
        if (!Input.location.isEnabledByUser)
            yield break;

        // Starts the location service.
        Input.location.Start();
        

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;

        dir *= Time.deltaTime;

        transform.Translate(dir * speed);

        if (dir.sqrMagnitude > 1)
            dir.Normalize();
    }
}
