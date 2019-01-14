using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoiceMapPath : MonoBehaviour {

    [SerializeField]
    private GameObject[] Paths;

    [SerializeField]
    private GameObject DirectionArrow;

    private void Start()
    {
        for (int PathIndex = 0; PathIndex < Paths.Length; ++PathIndex)
        {
            Vector2 Dir =(Paths[PathIndex].transform.position - transform.position).normalized;
            float Angle = Mathf.Atan2(Paths[PathIndex].transform.position.y - transform.position.y, Paths[PathIndex].transform.position.x - transform.position.x) * 180.0f / Mathf.PI;
            GameObject DirChoices = Instantiate(DirectionArrow,new Vector3(Mathf.Clamp(Dir.x,-0.5f,0.5f),Mathf.Clamp(Dir.y,-0.5f,0.5f),0),Quaternion.Euler(0,0,Angle), transform);
            DirChoices.GetComponent<Image>().alphaHitTestMinimumThreshold = 1.0f;
            DirChoices.GetComponent<Button>().onClick.AddListener(Pressed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (Paths != null)
        {
            if (Paths.Length > 0)
            {
                for (int PathIndex = 0; PathIndex < Paths.Length; ++PathIndex)
                {
                    if (Paths[PathIndex] != null)
                        Gizmos.DrawLine(this.transform.position, Paths[PathIndex].transform.position);
                }
            }
        }
    }

    void Pressed()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
