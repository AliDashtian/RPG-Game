using UnityEngine;

public class InventoryButtonsManager : MonoBehaviour
{
    public GameObject[] InventoryPages;

    public void InventoryButton(GameObject targetPage)
    {
        DisableAllPages();
        ActivateTargetPage(targetPage);
    }

    private void DisableAllPages()
    {
        foreach (GameObject page in InventoryPages)
        {
            page.SetActive(false);
        }
    }

    private void ActivateTargetPage(GameObject targetPage)
    {
        targetPage.SetActive(true);
    }
}
