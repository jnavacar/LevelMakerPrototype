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

    [Header("Rooms")]
    public GameObject Square;
    public GameObject Circle;
    public GameObject Capsule;
    public GameObject RestRoom;
    public GameObject BossRoom;
    public GameObject Composite; // Composite = {Square, Circle, Cylinder}
    private List<GameObject> _CompositeRoom;
    private List<GameObject> _RoomPool;
    private List<GameObject> _RoomPoolCopy;

    [Header("Public Variables")]
    private float _RestxPos = 0f;
    private float _RestyPos = 0f;
    private float _BossxPos = 0f;
    private float _BossyPos = 0f;
    private int _RoomCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Declare all variables
        _RoomPool = new List<GameObject>() { Square, Circle, Capsule };
        _CompositeRoom = new List<GameObject>();
        _RoomPoolCopy = new List<GameObject>();
        _RoomCount = _RoomPool.Count;
        // Get the position of the rest room
        _RestxPos = RestRoom.transform.position.x;
        _RestyPos = RestRoom.transform.position.y;
        _BossxPos = BossRoom.transform.position.x;
        _BossyPos = BossRoom.transform.position.y;
        // Create the random composite level
        for (int i = 0; i < _RoomCount; i++)
        {
            // Copy the room pool since we want to keep the original room pool
            _RoomPoolCopy = _RoomPool;
            // Select the rooms
            int random = Random.Range(0, _RoomPoolCopy.Count);
            _CompositeRoom.Add(_RoomPoolCopy[random]);
            // Once a room from the room pool is selected, remove the selected room
            _RoomPool.Remove(_RoomPoolCopy[random]);
        }
        // Link the composite rooms (The game objects, must always +2/-2 apart from each other)
        _CompositeRoom[0].transform.position = new Vector2(-4f, _RestyPos); // This is hard coded for now to test functionality
        _CompositeRoom[1].transform.position = new Vector2(_CompositeRoom[0].transform.position.x + 1, _RestyPos);
        _CompositeRoom[2].transform.position = new Vector2(_CompositeRoom[1].transform.position.x + 1, _RestyPos);
        // Once Composite rooms are made, connect with the rest room and boss room.
        Composite.transform.position = new Vector2(_RestxPos + 5, _RestyPos);
        BossRoom.transform.position = new Vector2(_RestxPos + 4, _RestyPos);
    }

    // Update is called once per frame
    void Update()
    {

    }
}