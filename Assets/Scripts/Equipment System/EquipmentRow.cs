using UnityEngine;

public class EquipmentRow : MonoBehaviour, IRowView
{
    public EquipmentObject ThisRow;
    public EquipmentSlot EquipmentSlotPrefab;

    private void Start()
    {
        CreateOrUpdateRowItems();
    }

    private void OnEnable()
    {
        ThisRow.EquipmentChanged += CreateOrUpdateRowItems;
    }

    private void OnDisable()
    {
        ThisRow.EquipmentChanged -= CreateOrUpdateRowItems;
    }


    public virtual void CreateOrUpdateRowItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //EquipmentObjectInfo objectInfo = new EquipmentObjectInfo(i, ThisRow);

            transform.GetChild(i).GetComponent<EquipmentSlot>().InitializeSlot(i, ThisRow);
        }
    }
}
