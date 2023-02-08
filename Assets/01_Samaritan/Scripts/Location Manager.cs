using DeadMosquito.AndroidGoodies;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _userLocationTMP;
    [SerializeField]
    private TextMeshProUGUI _shelterLocationTMP;
    [SerializeField]
    private TextMeshProUGUI _dangerLocationTMP;

    private void OnEnable()
    {
        OnStartTrackingLocation();
    }

    private void OnDisable()
    {
        OnStopTrackingLocation();
    }

    public void OnStartTrackingLocation()
    {
        // Minimum time interval between location updates, in milliseconds.
        const long minTimeInMillis = 200;
        // Minimum distance between location updates, in meters.
        const float minDistanceInMetres = 1;
        AGGPS.RequestLocationUpdates(minTimeInMillis, minDistanceInMetres, OnLocationChanged);
    }

    public void OnStopTrackingLocation()
    {
        AGGPS.RemoveUpdates();
    }

    private void OnLocationChanged(AGGPS.Location location)
    {
        string gpsText;
        gpsText = location.Latitude + " " + location.Longitude;
        _userLocationTMP.text = gpsText;
    }
}