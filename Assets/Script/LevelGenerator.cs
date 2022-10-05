using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some test code, a lot needs to change
public class LevelGenerator : MonoBehaviour
{
    /*
     * Generator Algorithm: Composites
     * 1. Start with a fixed (Rest) room
     * 2. Generate a Composite level (Consists of 3 room)
     * 3. Connect the Composite level to Rest and boss room.
     */
    public List<GameObject> Rooms;
    public GameObject SpawnRoom;
    public GameObject BossRoom;

    private List<GameObject> _RoomPoolCopy;
    public int RoomsInLevel = 3;

    [Header("Public Variables")]
    private float PosX = 0f;
    private float PosY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _RoomPoolCopy = Rooms;

        PosX = SpawnRoom.transform.position.x;
        PosY = SpawnRoom.transform.position.y;

        for (int i = 0; i < RoomsInLevel; i++)
        {
            // Select the rooms
            int random = Random.Range(0, _RoomPoolCopy.Count - 1);
            Instantiate(_RoomPoolCopy[random], new Vector2(PosX + 1, PosY), Quaternion.identity);
            PosX += 1;
            _RoomPoolCopy.Remove(_RoomPoolCopy[random]);
        }
        
        Instantiate(BossRoom, new Vector2(PosX+1, PosY), Quaternion.identity);
    }
}