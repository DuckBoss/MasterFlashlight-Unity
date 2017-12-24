using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryModifier : ScriptableObject {

    [Header("Battery Properties")]
    public float batteryCapacity;
    public float batteryDrainRate;

    //This determines at what ratio of battery life left that the light starts fading it's intensity.
    //Formula: batteryCapacity/lightFadeRatio = Percent To Start Fading.
    //Example: (100 batteryCapacity)/(4 lightFadeRatio) = light starts fading at 25% of battery capacity
    [Tooltip("batteryCapacity/lightFadeRatio = Percent To Start Fading Flashlight.")]
    public float lightFadeRatio;

}
