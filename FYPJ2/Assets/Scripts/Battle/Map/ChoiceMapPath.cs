using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoiceMapPath : MonoBehaviour {

    [SerializeField]
    private GameObject[] Points;

    [SerializeField]
    private GameObject MapPathing;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private GameObject Item;

    [SerializeField]
    private float Speed = 0.5f;

    private bool SpawnEnemy;
    private bool PassedPoint = false;
    public bool AtPoint = false;
    private bool Interacted = false;

    private GameObject PlayerObject;
    private GameObject PrevPath;
    private List<GameObject> PathList;

    private float StartTime, PathDistance;

    private void Start()
    {
        PlayerObject = TeamManager.Instance.gameObject;
        PathList = new List<GameObject>();
        int SpawnFactor= Random.Range(0, 2);
        switch (SpawnFactor)
        {
            case 0:
                Instantiate(Enemy,transform.position,Quaternion.Euler(Vector3.zero), transform);
                SpawnEnemy = true;
                break;
            case 1:
                Instantiate(Item, transform.position, Quaternion.Euler(Vector3.zero), transform);
                SpawnEnemy = false;
                break;
        }

        SpawnPaths();
    }

    private void Update()
    {
        if (CheckPlayerDistance() && !AtPoint)
            AtPoint = true;
        else if (!CheckPlayerDistance())
            AtPoint = false;

        if(CheckPlayerDistance() && !Interacted)
        {
            Interacted = true; 
            if(SpawnEnemy)
            {
                //Do enemy spawn things
            }
            else
            {
                //Do Item spawn things
            }
        }

        if(PassedPoint)
        {
            for(int index = 0; index < PathList.Count; ++index)
            {
                PathList[index].gameObject.GetComponent<Image>().color = Color.grey;
            }
            PassedPoint = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (Points != null)
        {
            if (Points.Length > 0)
            {
                for (int PathIndex = 0; PathIndex < Points.Length; ++PathIndex)
                {
                    if (Points[PathIndex] != null)
                        Gizmos.DrawLine(this.transform.position, Points[PathIndex].transform.position);
                }
            }
        }
    }

    public void OnPathClick()
    {
        ChoiceMapPath PrevNode;
        if (PrevPath == null || PrevPath.GetComponent<ChoiceMapPath>() == null)
            return;
        else
            PrevNode = PrevPath.GetComponent<ChoiceMapPath>();

        if (PrevNode.AtPoint)
        {
            PrevNode.PassedPoint = true;
            StartTime = Time.time;
            PathDistance = Vector3.Distance(transform.position, PlayerObject.transform.position);
            StartCoroutine(PlayerMove());
        }
    }

    IEnumerator PlayerMove()
    {
        //Distance moved = time * speed;
        while(!CheckPlayerDistance())
        {
            float DistCovered = (Time.time - StartTime) * Speed;
            float PathFraction = DistCovered / PathDistance;
            PlayerObject.transform.position = Vector3.Lerp(PlayerObject.transform.position, transform.position, PathFraction);
            yield return null;
        }
    }

    bool CheckPlayerDistance()
    {
        Vector2 Distance = (transform.position - PlayerObject.transform.position);
        if (Distance.magnitude < 0.001f)
            return true;
        return false;
    }

    void SpawnPaths()
    {
        for (int PathIndex = 0; PathIndex < Points.Length; ++PathIndex)
        {
            Vector3 Dir = (Points[PathIndex].transform.position - transform.position).normalized;
            float Dist = Vector3.Distance(transform.position, Points[PathIndex].transform.position);
            float Angle = Mathf.Atan2(Points[PathIndex].transform.position.y - transform.position.y, Points[PathIndex].transform.position.x - transform.position.x) * 180.0f / Mathf.PI;
            GameObject Path = Instantiate(MapPathing,transform.position, Quaternion.Euler(0, 0, Angle), transform.GetChild(0));
            Path.GetComponent<RectTransform>().sizeDelta = new Vector2(Dist, 1);
            PathList.Add(Path);
            Points[PathIndex].GetComponent<ChoiceMapPath>().PrevPath = transform.gameObject;
        }
    }
}
