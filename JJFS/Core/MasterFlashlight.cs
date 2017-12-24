using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MasterFlashlight : MonoBehaviour {

	[Header("User Input")]
	public KeyCode flashLightKey;

	[Header("References")]
	public Light lightSource;

	[Header("Base Properties")]
	public Color lightColor;
	public float lightIntensity;
	public float lightRange;
	public float lightSpotAngle;

	[Header("Modifiers (Optional)")]
	public BatteryModifier batteryModifier;
	

	#region INIT

	private void Start() {
		UpdateLightColor(lightColor);
		UpdateLightIntensity(lightIntensity);
		UpdateLightRange(lightRange);
		UpdateLightSpotAngle(lightSpotAngle);

		if(usingBatteryModifier()) {
			InitBatteryModifier();
		}
	}

	private void InitBatteryModifier() {
		batteryMax = batteryModifier.batteryCapacity;
		batteryCurrent = batteryMax;
	}

	#endregion

	#region MODIFIERS

	#region Battery
	private float batteryCurrent;
	private float batteryMax;

	private bool usingBatteryModifier() {
		if(batteryModifier != null)
			return true;
		return false;
	}
	#endregion

	#endregion

	#region GENERAL METHODS
	
	public bool isOn() {
		return lightSource.enabled;
	}

	public void ToggleFlashlight() {
		lightSource.enabled = !isOn();
	}

	private void UpdateLightColor(Color col) {
		lightSource.color = col;
	}

	private void UpdateLightIntensity(float val) {
		lightSource.intensity = val;
	}

	private void UpdateLightRange(float val) {
		lightSource.range = val;
	}

	private void UpdateLightSpotAngle(float val) {
		lightSource.spotAngle = val;
	}
	
	#endregion
	
	#region UPDATE

	private void Update() {
		//Turn On/Off Flashlight <supports battery modifier>
		if(Input.GetKeyDown(flashLightKey)) {
			if(usingBatteryModifier()) {
				if(batteryCurrent > 0) {
					ToggleFlashlight();
				}
				else {
					if(isOn())
						lightSource.enabled = false;
				}
			}
			else {
				ToggleFlashlight();
			}
		}

		//Drain Battery if in use. <uses battery modifier>
		if(usingBatteryModifier()) {
			if(isOn()) {
				//Drains battery life.
				batteryCurrent -= Time.deltaTime * batteryModifier.batteryDrainRate;
				
				//Fades light after a battery life threshold is reached.
				if(batteryCurrent < batteryModifier.batteryCapacity/batteryModifier.lightFadeRatio) {
					UpdateLightIntensity((batteryCurrent*batteryModifier.lightFadeRatio)/batteryModifier.batteryCapacity);
				}

				//Shuts off lighting if the battery is dead.
				if(batteryCurrent < 0) {
					batteryCurrent = 0;
					lightSource.enabled = false;
				}
				Debug.Log("Battery:" + batteryCurrent);
			}
		}

	} 

	#endregion

}
