using System;
using AndroidGoodiesExamples;
using DeadMosquito.AndroidGoodies;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GPSTest_s : MonoBehaviour
{
    public const double AmsterdamLatitude = 52.3745913;
    public const double AmsterdamLongitude = 4.8285751;
    public const double BrusselsLatitude = 50.854954;
    public const double BrusselsLongitude = 4.3053508;

    [SerializeField]
    private TextMeshProUGUI _userLocationTMP;
    [SerializeField]
    private TextMeshProUGUI _shelterLocationTMP;
    [SerializeField]
    private TextMeshProUGUI _dangerLocationTMP;

    private void Start()
    {
        try
        {
            _shelterLocationTMP.text = AGGPS.GetLastKnownGPSLocation().ToString();
        }
        catch (Exception)
        {
            Debug.Log("Could not get last known location.");
            _userLocationTMP.text = "Could not get last known location.";
            _shelterLocationTMP.text = $"Has GPS: {AGGPS.DeviceHasGPS()} - Is GPS Enabled: {AGGPS.IsGPSEnabled()}";
        }

        TestDistanceBetween();
    }

    private void TestDistanceBetween()
    {
        var results = new float[3];
        AGGPS.DistanceBetween(AmsterdamLatitude, AmsterdamLongitude,
            BrusselsLatitude, BrusselsLongitude, results);
        _dangerLocationTMP.text = $"DistanceBetween results: {results[0]}, Initial bearing: {results[1]}, Final bearing: {results[2]}";
    }

    [UsedImplicitly]
    public void OnStartTrackingLocation()
    {
        AGPermissions.ExecuteIfHasPermission(AGPermissions.ACCESS_FINE_LOCATION, StartLocationTacking,
            () => ExampleUtil.ShowPermissionErrorToast(AGPermissions.ACCESS_FINE_LOCATION));
    }

    private void StartLocationTacking()
    {
        // Minimum time interval between location updates, in milliseconds.
        const long minTimeInMillis = 0;
        // Minimum distance between location updates, in meters.
        const float minDistanceInMetres = 0;
        AGGPS.RequestLocationUpdates(minTimeInMillis, minDistanceInMetres, OnLocationChanged);
    }

    [UsedImplicitly]
    public void OnStopTrackingLocation()
    {
        AGGPS.RemoveUpdates();
    }

    private void OnLocationChanged(AGGPS.Location location)
    {
        Debug.Log($"Location changed: {location}");
        _userLocationTMP.text = $"Location changed: {location}";
        _shelterLocationTMP.text = location.ToString();
    }
}