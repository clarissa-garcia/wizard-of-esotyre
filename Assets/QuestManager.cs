using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quest
{
    COFFEE,
    REPAIR_BRIDGE,
    ENTER_FOREST,
    ENTER_CAVE
}

public delegate void OnQuestChangeHangler();

public class QuestManager : MonoBehaviour
{
    protected QuestManager() { }
    public static QuestManager Instance = null;
    public static event OnQuestChangeHangler OnQuestChange;

    public Quest quest {get; private set;}

    private void Awake()
	{
		if (Instance == null)
		{
            quest = Quest.COFFEE;
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

    public void SetQuest(Quest quest){
        this.quest = quest;
        OnQuestChange();
    }
}
