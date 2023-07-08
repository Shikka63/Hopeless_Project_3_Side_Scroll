using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;
    public TransformData playerPositionData;
    private TriggerEvent playerTriggerEvent;
    Vector2 startPosition;

    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
        startPosition = this.transform.position;
        SavePosition(startPosition);
    }

    //berguna untuk ketika Player Menabrak Checkpoint
    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
        CheckpointWallActive(col);

    }
    //menyalakan Dinding disamping Checkpoint
    public void CheckpointWallActive(GameObject wall)
    {
        //Debug.Log("name="+ wall.gameObject.transform.GetChild(0).gameObject.name);
        wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    //berguna untuk ketika Player Menabrak Checkpoint
    public void OnTrap(GameObject col)
    {
        ChangePlayerPosition(playerPositionData.position);
    }

    //berguna ketika Player menabrak garis Finish
    public void OnFinish()
    {
        playerPositionData.ResetData();

    }
    //berguna untuk mengubah posisi player
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
    //berguna untuk Load Position dari Scriptable object
    private void LoadPosition()
    {
        playerCurrentPosition = playerPositionData.position;
    }
    //berguna untuk Save Position ke Scriptable Object
    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
}