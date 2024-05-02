using System;
using System.Collections.Generic;
using System.Security.Cryptography;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// This component listens for images detected by the <c>XRImageTrackingSubsystem</c>
    /// and overlays some prefabs on top of the detected image.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class PrefabImagePairManager : MonoBehaviour
    {

        public List<GameObject> m_PrefabsList;

        Dictionary<string, GameObject> m_PrefabsDictionary = new Dictionary<string, GameObject>();
        Dictionary<string, GameObject> m_Instantiated = new Dictionary<string, GameObject>();
        ARTrackedImageManager m_TrackedImageManager;

      
        void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
            m_PrefabsDictionary.Add("rafflesia", m_PrefabsList[0]);
            m_PrefabsDictionary.Add("logo", m_PrefabsList[1]);
            m_PrefabsDictionary.Add("QRCode", m_PrefabsList[2]);
        }

        void OnEnable()
        {
            m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        void OnDisable()
        {
            m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
                // Give the initial image a reasonable default scale
                var minLocalScalar = Mathf.Min(trackedImage.size.x, trackedImage.size.y) / 2;
                trackedImage.transform.localScale = new Vector3(minLocalScalar, minLocalScalar, minLocalScalar);
                AssignPrefab(trackedImage);
            }
        }

        void AssignPrefab(ARTrackedImage trackedImage)
        {
            if (m_PrefabsDictionary.TryGetValue(trackedImage.referenceImage.name, out var prefab))
                if (!m_Instantiated.ContainsKey(trackedImage.referenceImage.name))
                {
                    if(m_Instantiated.Count > 0 )
                        foreach (var i in m_Instantiated.Keys)
                        {
                            var tmp = m_Instantiated[i];
                            Destroy(tmp);
                        }
                    m_Instantiated.Clear();
                    m_Instantiated[trackedImage.referenceImage.name] = Instantiate(prefab, trackedImage.transform);
                }
        }

    }
}
