using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDirector : MonoBehaviour
{
    private List<GameObject> fields = new List<GameObject>();
    private Camera _camera;
    private GameObject _field, _cactus;
    public byte verSpeed;
    private float fieldHight = 23.6f;
    private CameraBorder cameraBorder;
    private void Start()
    {
        verSpeed = 5;
        _camera = Camera.main;
        cameraBorder = new CameraBorder(_camera, 50, 50 ,0 , 0);
        _field = Resources.Load<GameObject>("Floor");
        _cactus = Resources.Load<GameObject>("Cactus");
        Createfloor(new Vector3(0, 0, 0));
        Createfloor(new Vector3(0, fieldHight, 0));
        Createfloor(new Vector3(0, fieldHight * 2, 0));
    }
    void Update()
    {
        FloorMover();
        RecreateField();
    }
    private void Createfloor(Vector3 position)
    {
        fields.Add( Instantiate(_field, position, Quaternion.Euler(Vector3.zero)));
    }
    private void CreateObstacleOnField(GameObject perentField)
    {
        bool filling = true;
        float highestObstaclelPos = -fieldHight / 2;
        while (filling)
        {
            highestObstaclelPos = Random.Range(highestObstaclelPos + 2, (highestObstaclelPos + 4));
            if (highestObstaclelPos + 4 < fieldHight)
            {
                GameObject createObject = Instantiate(_cactus, perentField.transform);
                createObject.transform.localPosition = new Vector3(Random.Range(cameraBorder.LeftBorder, cameraBorder.RightBorder), highestObstaclelPos, -1);

            }
            else
                filling = false;
        }
    }
    private void FloorMover()
    {
        for (int i = 0; i < fields.Count; i++)
        {
            fields[i].transform.position += Vector3.down * verSpeed * Time.deltaTime;
        }
    }
    private void RecreateField()
    {
        if (fields[0].transform.position.y + fieldHight <= cameraBorder.DownBorder)
        {
            GameObject destroyebleObject = fields[0];
            fields.RemoveAt(0);
            Createfloor(fields[fields.Count - 1].transform.position + (Vector3.up * fieldHight));
            CreateObstacleOnField(fields[fields.Count - 1]);
            Destroy(destroyebleObject);
        }
    }
}
