using System.Collections;
using UnityEngine;

public class GPSManager : MonoBehaviour
{
    private double first_Lat;     //최초 위도
    private double first_Long;    //최초 경도
    private double current_Lat;   //현재 위도
    private double current_Long;  //현재 경도

    private static WaitForSeconds second;

    private static bool gpsStarted = false;

    private static LocationInfo location;

    private void Awake() {
        second = new WaitForSeconds(1.0f);
    }

    private IEnumerator Start() {
        if (!Input.location.isEnabledByUser) {
            Debug.Log("GPS is not enabled");
            yield break;
        }

        Input.location.Start();
        Debug.Log("Awaiting initialization");

        int maxWait = 20;
        while (Input.location.status ==
            LocationServiceStatus.Initializing && maxWait > 0) {
            yield return second;
            maxWait -= 1;
        }

        if (maxWait < 1) {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.Log("Unable to determine device location");
            yield break;
        } else {
            location = Input.location.lastData;
            first_Lat = location.latitude * 1.0d;
            first_Long = location.longitude * 1.0d;
            gpsStarted = true;

            while (gpsStarted) {
                location = Input.location.lastData;
                current_Lat = location.latitude * 1.0d;
                current_Long = location.longitude * 1.0d;

                Debug.Log(location + " / " + current_Lat + " / " + current_Long);
                yield return second;
            }
        }
    }

    public static void StopGPS() {
        if (Input.location.isEnabledByUser) {
            gpsStarted = false;
            Input.location.Stop();
        }
    }
}