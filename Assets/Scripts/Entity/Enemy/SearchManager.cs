using Entity.Player;
using UnityEngine;

namespace Entity.Enemy
{
    internal class SearchManager : MonoBehaviour
    {
        private readonly float _searchDistance = 3f;
        [SerializeField] private PlayerController player;

        public bool Search()
        {
            return Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) < _searchDistance;
        }
        
    }
}