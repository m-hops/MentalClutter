using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Word : Thought
{
    public string word;
    public WordClass wordClass;
    public int index, value;

    public override void OnPointerUp(PointerEventData eventData) 
    {
        if(disabled) return;

        dragging = false;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        var answerSlot = results.Find(x => x.gameObject.GetComponent<AnswerSlot>()).gameObject?.GetComponent<AnswerSlot>();
        if(answerSlot)
        {
            if(answerSlot.index == index && !answerSlot.disabled)
            {
                disabled = true;
                answerSlot.word = this;
                answerSlot.disabled = true;
                transform.SetParent(answerSlot.transform);
                transform.SetAsLastSibling();
                transform.position = answerSlot.transform.position;
            }
            else
            {
                ReturnToPosition();
            }
        }
        else
        {
            ReturnToPosition();
        }
    }
}
