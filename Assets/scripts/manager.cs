using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;
    public GameObject object8;
    public GameObject object9;

    public GameObject[][] sublevelObjects;
    private int currentSublevelIndex = 0;

    public Button switchButton; // ������ �� ������ � Unity Editor

    void Start()
    {
        // ������������� �������� �������� ��� ������� ���������
        sublevelObjects = new GameObject[][]
        {
            new GameObject[] { object1, object2, object3, object4 }, // ������ ����������
            new GameObject[] { object5, object6 },                   // ������ ����������
            new GameObject[] { object7, object8, object9 }           // ������ ����������
        };

        // ���������� ������� ��� �������� ���������
        SwitchSublevelObjects(currentSublevelIndex);

        // ����������� ����� IncreaseSublevelIndex � ������� ������� �� ������
        switchButton.onClick.AddListener(IncreaseSublevelIndex);
    }

    public void SwitchSublevelObjects(int sublevelIndex)
    {
        // �������� ��� �������
        foreach (GameObject[] objs in sublevelObjects)
        {
            foreach (GameObject obj in objs)
            {
                obj.SetActive(false);
            }
        }

        // ���������� ������� ��� ���������� ���������
        foreach (GameObject obj in sublevelObjects[sublevelIndex])
        {
            obj.SetActive(true);
        }

        // ������������� ������� ������ ���������
        currentSublevelIndex = sublevelIndex;
    }

    public void IncreaseSublevelIndex()
    {
        // ����������� ������ �� 1
        currentSublevelIndex++;

        // ����������� ������� �� ��������� ����������
        if (currentSublevelIndex >= sublevelObjects.Length)
        {
            currentSublevelIndex = 0; // ���� ��������� ����� ������ ����������, ����������� �� ������
        }

        SwitchSublevelObjects(currentSublevelIndex);
    }
}