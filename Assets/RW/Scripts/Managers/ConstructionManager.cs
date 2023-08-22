
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace RayWenderlich.WenderlichTopia
{
    public class ConstructionManager : MonoBehaviour
    {
        public GameObject constructionTilePrefab;
        public UiManager uiManager;
        public Transform levelGeometryContainer;

        private void Start()
        {

        }

        public async void BuildStructure(GameObject placementStructure, Vector3 buildPosition)
        {
            // Method code goes here
            var buildRoadTask = BuildRoadAsync(roadProperties, buildPosition);
            await buildRoadTask;
            uiManager.NewStructureComplete(roadProperties.roadCost, buildPosition);

        }

        private async Task BuildRoadAsync(RoadBuildProperties roadProperties, Vector3 buildPosition)
        {
            var constructionTile = Instantiate(constructionTilePrefab, buildPosition, Quaternion.identity, levelGeometryContainer);
            await Task.Delay(2500);
            Destroy(constructionTile);
            Instantiate(roadProperties.completedRoadPrefab, buildPosition, Quaternion.identity, levelGeometryContainer);

        }


        private void Update()
        {

        }

        private void OnDisable()
        {

        }
    }
}