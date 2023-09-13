using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace RespawnSystem
{
    public class RespawnPointManager : MonoBehaviour
    {
        List<RespawnPoint> respawnPoints = new List<RespawnPoint>();
        RespawnPoint currentRespawnPoint;

        private void Awake() {
            foreach(Transform item in transform)
            {
                Debug.Log(item);
                respawnPoints.Add(item.GetComponent<RespawnPoint>());
            }
            currentRespawnPoint = respawnPoints[0];
        }

        public void UpdateRespawnPonit(RespawnPoint respawnPoint)
        {
            currentRespawnPoint.DisableRespawnPoint();
            currentRespawnPoint = respawnPoint;
        }

        public void Respawn(GameObject objectToRespawm)
        {
            currentRespawnPoint.RespawnPlayer();
            objectToRespawm.SetActive(true); // Can move to RespawnPlayer()
        }

        public void RespawnAt(RespawnPoint respawnPoint, GameObject playerGO)
        {

            respawnPoint.SetPlayerGO(playerGO);
            Respawn(playerGO);
        }

        public void ResetAllSpawnPoints() 
        {
            foreach (var item in respawnPoints)
            {
                item.ResetRespawnPoint();
            }
            currentRespawnPoint = respawnPoints[0];
        }
    }
}
