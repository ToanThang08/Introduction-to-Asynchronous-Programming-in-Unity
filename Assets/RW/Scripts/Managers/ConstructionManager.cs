
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
            var buildHouseTask = BuildHouseAsync(houseProperties, buildPosition);
            await buildHouseTask;
            var houseCost = buildHouseTask.Result;
            uiManager.NewStructureComplete(houseCost, buildPosition);

        }

        private async Task BuildRoadAsync(RoadBuildProperties roadProperties, Vector3 buildPosition)
        {
            var constructionTile = Instantiate(constructionTilePrefab, buildPosition, Quaternion.identity, levelGeometryContainer);
            await Task.Delay(2500);
            Destroy(constructionTile);
            Instantiate(roadProperties.completedRoadPrefab, buildPosition, Quaternion.identity, levelGeometryContainer);

        }

        private async Task<int> BuildHouseAsync(HouseBuildProperties houseBuildProperties, Vector3 buildPosition)
        {
            var constructionTile = Instantiate(constructionTilePrefab, buildPosition, Quaternion.identity, levelGeometryContainer);

            return 100;
        }

        private async Task<int> BuildHousePartAsync(HouseBuildProperties houseBuildProperties, GameObject housePartPrefab, Vector3 buildPosition)
        {
            var constructionTime = houseBuildProperties.GetConstructionTime();
            await Task.Delay(constructionTime);

            Instantiate(housePartPrefab, buildPosition, Quaternion.identity, levelGeometryContainer);
            var taskCost = constructionTime * houseBuildProperties.wage;
            return taskCost;

        }


        private void Update()
        {

        }

        private void OnDisable()
        {

        }
    }
}