using UnityEngine;

public class ExitIfBossDead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sahnedeki "Boss" tag'li objeyi arar
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");

            if (boss == null)
            {
                Debug.Log("Boss yok, oyundan çýkýlýyor.");
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Editörde test için
#endif
            }
            else
            {
                Debug.Log("Boss hâlâ hayatta, çýkýþ engellendi.");
            }
        }
    }
}
