using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public enum Direction {up,down,left,right};
    public Direction direction;
    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;
    public GameObject gate;
    private GameObject endRoom;
   
    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public int maxstep;
    public List<Room> rooms = new List<Room>();
    List<GameObject> farRooms = new List<GameObject>();
    List<GameObject> lessFarRooms = new List<GameObject>();
    List<GameObject> oneWayRooms = new List<GameObject>();
    public WallType wallType;
    public LayerMask roomLayer;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<roomNumber;i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());
            ChangePointPos();
        }
        endRoom = rooms[0].gameObject;
        foreach(var room in rooms)
        {
            SetupRoom(room, room.transform.position);
        }
        FindEndRoom();
        endRoom.GetComponent<SpriteRenderer>().color = endColor;
        endRoom.GetComponentInChildren<CreateEnemy2>().enabled = false;
        Instantiate(gate, endRoom.GetComponent<Transform>().position, Quaternion.identity);
        rooms[0].GetComponentInChildren<CreateEnemy2>().enabled = false;
        GameObject.Find("Player").transform.position = rooms[0].GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ChangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);
            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position,0.2f,roomLayer));
    }
    public void SetupRoom(Room newRoom,Vector3 roomPosition)//判断上下左右是否有房间，有则设置门
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset,0), 0.2f,roomLayer);
        newRoom.roomDown= Physics2D.OverlapCircle(roomPosition + new Vector3(0,-yOffset,0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset,0,0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset,0,0), 0.2f, roomLayer);
        newRoom.UpdateRoom(xOffset, yOffset);
        switch(newRoom.doorNumber)
        {
            case 1:
                if (newRoom.roomUp)
                    Instantiate(wallType.singleup, roomPosition, Quaternion.identity);
                if (newRoom.roomDown)
                    Instantiate(wallType.singleBottom, roomPosition, Quaternion.identity);
                if (newRoom.roomRight)
                    Instantiate(wallType.singleRight, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft)
                    Instantiate(wallType.singleLeft, roomPosition, Quaternion.identity);
                break;
            case 2:
                if (newRoom.roomUp && newRoom.roomDown)
                    Instantiate(wallType.doubleBU, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomRight)
                    Instantiate(wallType.doubleRU, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomLeft)
                    Instantiate(wallType.doubleLU, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomLeft)
                    Instantiate(wallType.doubleLR, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomDown)
                    Instantiate(wallType.doubleRB, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomDown)
                    Instantiate(wallType.doubleLB, roomPosition, Quaternion.identity);
                break;
            case 3:
                if (newRoom.roomUp && newRoom.roomDown && newRoom.roomLeft)
                    Instantiate(wallType.tripleLUB, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomDown && newRoom.roomRight)
                    Instantiate(wallType.tripleURB, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomRight && newRoom.roomLeft)
                    Instantiate(wallType.tripleLUR, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomRight && newRoom.roomLeft)
                    Instantiate(wallType.tripleLRB, roomPosition, Quaternion.identity);
                break;
            case 4:
                if (newRoom.doorUp && newRoom.roomDown && newRoom.roomLeft && newRoom.roomRight)
                    Instantiate(wallType.fourDoors, roomPosition, Quaternion.identity);
                break;
        }
    }
    public void FindEndRoom()
    {
        for(int i=0;i<rooms.Count;i++)//获得最大数值
        {
            if (rooms[i].stepToStart > maxstep)
                maxstep = rooms[i].stepToStart;
        }
        foreach(var room in rooms)//获得最大值房间和次大值
        {
            if (room.stepToStart == maxstep)
                farRooms.Add(room.gameObject);
            if (room.stepToStart == maxstep - 1)
                lessFarRooms.Add(room.gameObject);
        }
        for(int i=0;i<farRooms.Count;i++)
        {
            if(farRooms[i].GetComponent<Room>().doorNumber==1)
            {
                oneWayRooms.Add(farRooms[i]);
            }
        }
        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if (lessFarRooms[i].GetComponent<Room>().doorNumber == 1)
            {
                oneWayRooms.Add(lessFarRooms[i]);
            }
        }
        if(oneWayRooms.Count!=0)
        {
            endRoom = oneWayRooms[Random.Range(0, oneWayRooms.Count)];
        }
        else
        {
            endRoom = farRooms[Random.Range(0, farRooms.Count)];
        }
    }

}
[System.Serializable]
public class WallType
{
    public GameObject singleLeft, singleRight, singleup, singleBottom,
                      doubleLU, doubleLR, doubleLB, doubleBU, doubleRU, doubleRB,
                      tripleLUR, tripleLUB, tripleURB, tripleLRB,
                      fourDoors;
}
