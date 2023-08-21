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

        public void BuildStructure(GameObject placementStructure, Vector3 buildPosition)
        {
            if (placementStructure.TryGetComponent(out RoadBuildPropertiesContainer roadBuildPropertiesContainer))
            {
                Destroy(placementStructure);
                var roadProperties = roadBuildPropertiesContainer.roadBuildProperties;

            }
            else if (placementStructure.TryGetComponent(out HouseBuildPropertiesContainer houseBuildPropertiesContainer))
            {
                Destroy(placementStructure); 
                var houseProperties = houseBuildPropertiesContainer.houseBuildProperties;
                
            }
        }

        public async void BuildStructure(GameObject placementStructure, Vector3 buildPosition)
        {
            
        }


        private void Update()
        {
            
        }

        private void OnDisable()
        {

        }
    }
}

