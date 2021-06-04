using System.Collections;
using UnityEngine;

/**
 * Nicholas Cullmann - 2/2021
 * CubeController - Controls colored cubes on the map.
 * Red/Blue - only one color can be active at a time.
 * Yellow/Green - player can either see the cube and fall through, or make it disappear but remain standable.
 */

public class CubeController : MonoBehaviour
{
    public enum ControllerFunction { EnableCube, HideMesh, DisableCollision, DisableCube };
    public GameObject cubes;
    public CubeController[] controllers;
    public ControllerFunction controllerFuntction;
    public GameObject warningText;
    private bool warningTextNotActivated = true;

    private void OnTriggerEnter()
    {
        // disable all other controllers when a new one is active
        foreach (CubeController cc in controllers)
            cc.SwitchCubes(false);

        SwitchCubes(true);
    }
    public void SwitchCubes(bool enable)
    {
        switch (controllerFuntction)
        {
            // Red and BLue
            case ControllerFunction.EnableCube:
                cubes.transform.gameObject.SetActive(enable);
                break;
            // Green
            case ControllerFunction.HideMesh:
                for (int i = 0; i < cubes.transform.childCount; i++)
                {
                    cubes.transform.GetChild(i).gameObject.SetActive(enable);
                    cubes.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = !enable;
                    cubes.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = enable;
                }
                break;
            // Yellow
            case ControllerFunction.DisableCollision:
                for (int i = 0; i < cubes.transform.childCount; i++)
                {
                    cubes.transform.GetChild(i).gameObject.SetActive(enable);
                    cubes.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = enable;
                    cubes.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = !enable;

                }
                if (enable)
                {
                    // show a warning when yellow is enabled
                    warningText.SetActive(warningTextNotActivated);
                    StartCoroutine(RemoveAfterSeconds(3, warningText));
                    warningTextNotActivated = false;
                }
                break;
            case ControllerFunction.DisableCube:
                for (int i = 0; i < cubes.transform.childCount; i++)
                {
                    cubes.transform.GetChild(i).gameObject.SetActive(!enable);
                }
                break;
        }
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        // remove text after x seconds
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
