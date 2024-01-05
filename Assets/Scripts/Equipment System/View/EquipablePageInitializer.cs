using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipablePageInitializer : MonoBehaviour
{
    public EquipinigMiddleManObject EquipingMiddleMan;
    public InventoryPage EquipablePage;
    public List<ItemObject> PageTypeObject = new List<ItemObject>();

    private EquipmentView slot;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(FillRelativeEquipablePageAndShow);
        GetComponent<Button>().onClick.AddListener(AddEquipingMiddleManInfo);
        slot = GetComponent<EquipmentView>();
    }

    void FillRelativeEquipablePageAndShow()
    {
        EquipablePage.ResetPage();
        EquipablePage.PageTypeObject.Clear();

        for (int i = 0; i < PageTypeObject.Count; i++)
        {
            EquipablePage.PageTypeObject.Add(PageTypeObject[i]);
        }

        EquipablePage.gameObject.SetActive(true);
        //Instantiate(EquipablePage, transform.parent.parent.parent.parent);
    }

    void AddEquipingMiddleManInfo()
    {
        //EquipmentObjectInfo objectInfo = new EquipmentObjectInfo(slot.ID, slot.SlotPlace);
        EquipingMiddleMan.FillInfo(slot.ID, slot.SlotPlace, slot.Item);
    }
}
