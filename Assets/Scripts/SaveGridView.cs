using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGridView : MonoBehaviour
{
    [SerializeField]
    private GameObject gridItem;
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup;

    private void Start()
    {
        SaveController.Instance.OnJsonDataLoaded += CreateGridButtons;
    }

    private void OnDestroy()
    {
        SaveController.Instance.OnJsonDataLoaded -= CreateGridButtons;
    }

    private void CreateGridButtons()
    {
        var saveDataList = SaveController.Instance.SaveDataCollection.saveDataList;

        for (int i = 0; i < saveDataList.Count; i++)
        {
            GameObject saveGridElement = Instantiate(gridItem, content, false);
            saveGridElement.GetComponent<SaveGridButton>().ButtonId = saveDataList[i].id;
        }
        gridLayoutGroup.enabled = true;
    }
}
