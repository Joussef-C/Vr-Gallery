using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    //public XRController leftTeleportaRay;
    public XRController rightTeleportaRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;


    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;

  
    // Update is called once per frame
    void Update()
    {

        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;


        //if (leftTeleportaRay)
      //  {
     //       leftTeleportaRay.gameObject.SetActive(CheckIfActivated(leftTeleportaRay));
     //   }

        if (rightTeleportaRay)

        {
            bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
            rightTeleportaRay.gameObject.SetActive(CheckIfActivated(rightTeleportaRay)&& !isRightInteractorRayHovering);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
