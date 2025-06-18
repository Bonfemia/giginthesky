using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("Paneles UI")]
    public GameObject mainMenuPanel;
    public GameObject missionsPanel;
    public GameObject optionsPanel;

    [Header("Prefabs UI")]
    public Button missionButtonPrefab; // Prefab de botón para misiones

    [Header("Contenedor para botones")]
    public Transform missionsContentParent; // Donde se crean los botones de misiones

    // Misiones hardcodeadas (puedes agregar más)
    private List<string> missionNames = new List<string>()
    {
        "Encontrar a los amigos",
        "Conseguir bebida",
        "Escapar del guardia",
        "Subir al escenario",
        "Buscar la salida secreta"
    };

    void Start()
    {
        ShowMainMenu();
        GenerateMissionButtons();
    }

    // Limpia y genera botones de misiones
    void GenerateMissionButtons()
    {
        // Limpia botones viejos si los hay
        foreach (Transform child in missionsContentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var mission in missionNames)
        {
            Button btn = Instantiate(missionButtonPrefab, missionsContentParent);
            btn.GetComponentInChildren<Text>().text = mission;
            btn.onClick.AddListener(() => OnMissionSelected(mission));
        }
    }

    // Funciones para mostrar paneles
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        missionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void ShowMissions()
    {
        mainMenuPanel.SetActive(false);
        missionsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        missionsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OnMissionSelected(string missionName)
    {
        Debug.Log($"Misión seleccionada: {missionName}");
        // Podés agregar más lógica acá para avanzar o mostrar detalles
    }
}
