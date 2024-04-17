using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(OVRFaceExpressions))]
public class EyeFace_tracker : MonoBehaviour
{

    //Region to manage Editor behaviour
    #region GUI
    [CustomEditor(typeof(EyeFace_tracker))]
    public class DataTrackerGUI : Editor
    {
        private EyeFace_tracker trackerClass;

        private OVRFaceExpressions ovrexpr;

        public void OnEnable()
        {
            trackerClass = (EyeFace_tracker)target;
            ovrexpr = trackerClass.GetComponent<OVRFaceExpressions>();
        }

        public override void OnInspectorGUI()
        {
            if (trackerClass == null)
            {
                return;
            }

            trackerClass.takeTime = EditorGUILayout.Toggle("Take Time", trackerClass.takeTime);


            if (!FindObjectOfType<OVRCameraRig>())
            {
                EditorGUILayout.HelpBox("Missing OVRCameraRig in the scene", MessageType.Warning);

                trackerClass.takeEyeData = false;
                trackerClass.takeFaceData = false;

                ovrexpr.enabled = false;
            }
            else
            {

                trackerClass.takeEyeData = EditorGUILayout.Toggle("Take Eye Data", trackerClass.takeEyeData);
                if (trackerClass.takeEyeData)
                {
                    EditorGUI.indentLevel++;
                    trackerClass.leftEye = (GameObject)EditorGUILayout.ObjectField("Left Eye", trackerClass.leftEye, typeof(UnityEngine.Object), true);
                    trackerClass.rightEye = (GameObject)EditorGUILayout.ObjectField("Right Eye", trackerClass.rightEye, typeof(UnityEngine.Object), true);
                    EditorGUI.indentLevel--;
                }
                trackerClass.takeFaceData = EditorGUILayout.Toggle("Take Face Data", trackerClass.takeFaceData);

                ovrexpr.enabled = trackerClass.takeFaceData || trackerClass.takeEyeData;


            }
        }

    }
    #endregion

    //Parameters are not shown in inspector if public, only using the GUI above (override for editor purpose)

    private OVRFaceExpressions ovrexpr;

    public bool takeTime;
    private string actualTime = "";

    public bool takeEyeData, takeFaceData;

    [SerializeField]
    public GameObject leftEye, rightEye;

    public bool toggleDebugEye = false;

    public void Start()
    {

        if (takeFaceData || takeEyeData)
        {
            ovrexpr = GetComponent<OVRFaceExpressions>();
            ovrexpr.enabled = true;
        }

    }

    public static string GetTimestamp()
    {
        return DateTime.UtcNow.ToString(format: "yyyy-MM-dd' 'HH:mm:ss.fff");
    }


    private void FixedUpdate()
    {
        if (takeTime)
        {
            actualTime = GetTimestamp();

            if (takeEyeData)
            {
                CollectEyeTransform(rightEye);
                CollectEyeTransform(leftEye);

            }

            if (takeFaceData)
            {
                CollectFaceData();
            }
        }
    }


    #region eyeTracking

    private void CollectEyeTransform(GameObject eye)
    {
        OVREyeGaze gaze = eye.GetComponent<OVREyeGaze>();
        string label = "Eye" + gaze.Eye.ToString();
        Vector3 eyePos = eye.transform.position;
           
    }

    #endregion

    #region FaceTracking

    private void CollectFaceData()
    {
        List<float> faceWeights = new(ovrexpr.ToArray());

        foreach (OVRFaceExpressions.FaceExpression expr in (OVRFaceExpressions.FaceExpression[])Enum.GetValues(typeof(OVRFaceExpressions.FaceExpression)))
        {
            if (expr == OVRFaceExpressions.FaceExpression.InnerBrowRaiserL)
            {
                Debug.Log(faceWeights[(int)expr].ToString());
            }
        }
       
    }


    #endregion

}
