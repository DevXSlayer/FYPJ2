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

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private GameObject Item;

    private int PathNumber = 0;

    private void Start()
    {
        int SpawnFactor= Random.Range(0, 2);
        switch (SpawnFactor)
        {
            case 0:
                Instantiate(Enemy, transform);
                break;
            case 1:
                Instantiate(Item, transform);
                break;
        }
    }

    private void Update()
    {
        if (CheckPlayerDistance())
            SpawnDirArrows();
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

    void Pressed(int PathIndex)
    {
        //Set position of the player to the point
        //Paths[PathIndex].transform.position;
    }

    bool CheckPlayerDistance()
    {
        return false;
    }

    void SpawnDirArrows()
    {
        for (int PathIndex = 0; PathIndex < Paths.Length; ++PathIndex)
        {
            Vector2 Dir = (Paths[PathIndex].transform.position - transform.position).normalized;
            float Angle = Mathf.Atan2(Paths[PathIndex].transform.position.y - transform.position.y, Paths[PathIndex].transform.position.x - transform.position.x) * 180.0f / Mathf.PI;
            GameObject DirChoices = Instantiate(DirectionArrow, new Vector3(Mathf.Clamp(Dir.x, -0.5f, 0.5f) + transform.position.x, Mathf.Clamp(Dir.y, -0.5f, 0.5f) + transform.position.y, 0), Quaternion.Euler(0, 0, Angle), transform.GetChild(0));
            DirChoices.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
            DirChoices.GetComponent<Button>().onClick.AddListener(() => Pressed(PathNumber));
            ++PathNumber;
        }
    }
}
