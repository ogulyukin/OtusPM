using Lessons.Architecture.PM;
using UnityEngine;

namespace UI
{
    public sealed class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private GameObject playerStatPrefab;
        public void RedrawStats(CharacterStat[] stats)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var t in stats)
            {
                var stat = Instantiate(playerStatPrefab, transform);
                stat.GetComponent<StatItemView>().SetStat(t.Name, t.Value);
            }
        }
    }
}
