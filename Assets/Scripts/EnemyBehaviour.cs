using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Common;
using UnityEngine.PostProcessing;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject target;

    float start = -10;

    // Start is called before the first frame update
    void Start()
    {
        target = new GameObject("Target");
        GetComponent<AICharacterControl>().target = target.transform;
        StartCoroutine(RefreshTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, GameObject.Find("/Player").transform.position) < 2f)
        {
            Debug.Log("Failed");
            Time.timeScale = 0.5f;
            if (!GameObject.Find("/Player/FirstPersonCharacter").GetComponent<PostProcessingBehaviour>())
            {
                StartCoroutine(GameObject.Find("/Player").GetComponent<PlayerBehaviour>().Failure());
            }
        }

        if (Time.time - start > 10 && GetComponent<AICharacterControl>().target != target.transform)
        {
            GetComponent<AICharacterControl>().target = target.transform;
            StartCoroutine(RefreshTarget());
        }

        Ray ray = new Ray(transform.position, GameObject.Find("/Player").transform.position - transform.position);

        Debug.DrawRay(transform.position, GameObject.Find("/Player").transform.position - transform.position);

        if (GetComponent<AICharacterControl>().target == GameObject.Find("/Player").transform)
            Debug.DrawRay(transform.position, GameObject.Find("/Player").transform.position - transform.position, Color.yellow);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == GameObject.Find("/Player"))
            {
                GetComponent<AICharacterControl>().target = GameObject.Find("/Player").transform;
                Debug.DrawRay(transform.position, GameObject.Find("/Player").transform.position - transform.position, Color.red);
                start = Time.time;
            }
        }
    }

    IEnumerator RefreshTarget()
    {
        while(GetComponent<AICharacterControl>().target == target.transform)
        {
            target.transform.position = Common.Common.RandomNavMesh();
            yield return new WaitForSeconds(30f);
        }
    }
}
