using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    public GameObject Hunter, Portal;
    public Dictionary<int, System.Action> keyFrames;
    // Start is called before the first frame update
    void Start()
    {
        keyFrames = new Dictionary<int, System.Action>
        {
            {
                60,
                () =>
                {
                    Instantiate(Hunter, new Vector3(426f, 0.5f, 38f), Quaternion.identity);
                }
            },
            {
                120,
                () =>
                {
                    Instantiate(Hunter, new Vector3(198.32f, 0.5f, 277.36f), Quaternion.identity);
                }
            },
            {
                180,
                () =>
                {
                    Instantiate(Hunter, new Vector3(319f, 0.5f, 394f), Quaternion.identity);
                }
            },
            {
                240,
                () =>
                {
                    Instantiate(Hunter, new Vector3(184f, 0.5f, 194f), Quaternion.identity);
                }
            },
            {
                300,
                () =>
                {
                    Instantiate(Hunter, new Vector3(80f, 0.5f, 64f), Quaternion.identity);
                    Instantiate(Hunter, new Vector3(343f, 0.5f, 119f), Quaternion.identity);

                    Instantiate(Portal, Common.Common.RandomNavMesh(), Quaternion.Euler(-90f, 0f, 0f));
                }
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(keyFrames.ContainsKey((int)Time.timeSinceLevelLoad))
        {
            Debug.Log("Yes");
            keyFrames[(int)Time.timeSinceLevelLoad]();
            keyFrames.Remove((int)Time.timeSinceLevelLoad);
        }

        string time = string.Format("{0:D2}:{1:D2}", ((int)Time.timeSinceLevelLoad) / 60, (int)Time.timeSinceLevelLoad % 60);

        GameObject.Find("/Canvas/Panel/Text").GetComponent<Text>().text = time;
    }
}
