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

    private bool PassedPoint = false;
    private bool CreatedArrows = false;
    private int PathNumber = 0;
    private GameObject PlayerObject;
    private List<GameObject> SpawnedArrows;

    private void Start()
    {
        SpawnedArrows = new List<GameObject>();
        PlayerObject = TeamManager.Instance.gameObject;
        int SpawnFactor= Random.Range(0, 2);
        switch (SpawnFactor)
        {
            case 0:
                Instantiate(Enemy,transform.position,Quaternion.Euler(Vector3.zero), transform);
                break;
            case 1:
                Instantiate(Item, transform.position, Quaternion.Euler(Vector3.zero), transform);
                break;
        }
    }

    private void Update()
    {
        if (CheckPlayerDistance() && !PassedPoint && !CreatedArrows)
            SpawnDirArrows();
        else if(!CheckPlayerDistance() && PassedPoint)
            DeSpawnDirArrows();
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
        PlayerObject.transform.position = Paths[PathIndex].transform.position;
        PassedPoint = true;
        
    }

    bool CheckPlayerDistance()
    {
        Vector2 Distance = (transform.position - PlayerObject.transform.position);
        if (Distance.magnitude < 0.1f)
            return true;
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
            SpawnedArrows.Add(DirChoices);
        }
        CreatedArrows = true;
    }

    void DeSpawnDirArrows()
    {
        for(int index = 0;index < SpawnedArrows.Count; ++index)
        {
            Destroy(SpawnedArrows[index].gameObject);
        }
    }
}
