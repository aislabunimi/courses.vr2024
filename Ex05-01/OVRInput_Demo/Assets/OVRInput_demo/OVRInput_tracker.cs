using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class OVRInput_tracker : MonoBehaviour
{
    private string actualTime;

    public TextMeshProUGUI logsArea;
    private int maxLines;

    public void Start()
    {

    }

    private void FixedUpdate()
    {
        actualTime = GetTimestamp();

        if (OVRPlugin.GetNodePositionTracked(OVRPlugin.Node.Head))
        {
            CollectOVRNodeTrackingInfo(OVRPlugin.Node.Head);
        }

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch) && OVRInput.IsControllerConnected(OVRInput.Controller.LTouch))
        {
            CollectOVRInputControllerTrackingInfo(OVRInput.Controller.LTouch);
            CollectOVRInputControllerTrackingInfo(OVRInput.Controller.RTouch);

            CollectOVRInputControllerButtonData();
        }

    }

    #region Movement

    /// <summary>
    /// Collect tracking info related to position and rotation of a Node from OVRPlugin 
    /// </summary>
    /// <param name="node">
    /// OVR node, can be like head, hand, centereye, ecc...
    /// </param>
    private void CollectOVRNodeTrackingInfo(OVRPlugin.Node node)
    {

        OVRPose pose = OVRPlugin.GetNodePose(node, OVRPlugin.Step.Render).ToOVRPose();
        Vector3 position = pose.position;
        Vector3 velocity = OVRPlugin.GetNodeVelocity(node, OVRPlugin.Step.Render).FromVector3f();
        Vector3 angVelocity = OVRPlugin.GetNodeAngularVelocity(node, OVRPlugin.Step.Render).FromVector3f();
        Quaternion orientation = pose.orientation;


    }

    /// <summary>
    /// Collect tracking info related to position and rotation of a controller from OVRInput
    /// </summary>
    /// <param name="controller">
    /// Selected OVR controller (touch is quest controller)
    /// </param>
    private void CollectOVRInputControllerTrackingInfo(OVRInput.Controller controller)
    {

        Vector3 position = OVRInput.GetLocalControllerPosition(controller);
        Vector3 velocity = OVRInput.GetLocalControllerVelocity(controller);
        Vector3 angVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        Quaternion orientation = OVRInput.GetLocalControllerRotation(controller);

    }


    /// <summary>
    /// Collect Button data from OVRInput class, using different types of sources
    /// </summary>
    private void CollectOVRInputControllerButtonData()
    {
        float triggerValue = OVRInput.Get( OVRInput.RawAxis1D.LIndexTrigger );
        LogInfo(triggerValue.ToString());
    }

    #endregion

    public static string GetTimestamp()
    {
        return DateTime.UtcNow.ToString(format: "yyyy-MM-dd' 'HH:mm:ss.fff");
    }

    private void LogInfo(string message)
    {
        ClearLines();
        logsArea.text += $"{GetTimestamp()} {message}\n";
    }
    
    private void ClearLines()
    {
        if (logsArea.text.Split('\n').Count() >= maxLines)
        {
            logsArea.text = string.Empty;
        }
    }
}
