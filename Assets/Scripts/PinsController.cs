using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PinsController : MonoBehaviour
{
    private List<Pin> pins;
    private Dictionary<Pin, Vector3> pinsDefaultPosition = new Dictionary<Pin, Vector3>();
    private Dictionary<Pin, Quaternion> pinsDefaultRotations = new Dictionary<Pin, Quaternion>();
    public int fallenCount;

    void Start()
    {
        pins = GameObject.FindObjectsOfType<Pin>().ToList();

        foreach (var pin in pins)
        {
            pinsDefaultPosition.Add(pin, pin.transform.position);
            pinsDefaultRotations.Add(pin, pin.transform.rotation);
        }
    }

    public int GetCountOfFallenPins()
    {
        return pins.Count(pin => pin.CheckFall() && pin.gameObject.activeSelf);
    }

    public void ResetPinsPositions()
    {
        foreach (var pin in pins)
        {
            pin.gameObject.SetActive(true);

            pin.transform.position = pinsDefaultPosition[pin];
            pin.transform.rotation = pinsDefaultRotations[pin];

            pin.rb.constraints = RigidbodyConstraints.FreezeAll;
            pin.rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void RemoveFallenPins()
    {
        pins.FindAll(pin => pin.CheckFall()).ForEach(pin => pin.gameObject.SetActive(false));
    }
}
