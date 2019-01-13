using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMapPath : MonoBehaviour {

    [SerializeField]
    private GameObject[] Paths;

    [SerializeField]
    private GameObject DirectionArrow;

    private void Start()
    {
        for (int PathIndex = 0; PathIndex < Paths.Length; ++PathIndex)
        {
            Vector2 Dir = Paths[PathIndex].transform.position - transform.position;
            Debug.Log(Dir);
            float Angle = Vector2.Angle(Dir.normalized, transform.up);
            //Instantiate(DirectionArrow, transform.position, Quaternion.Euler(0, 0, Angle), transform);
            GameObject DirChoices = Instantiate(DirectionArrow,transform.position,Quaternion.Euler(0,0,Angle), transform);
            //DirChoices.transform.rotation
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

}
