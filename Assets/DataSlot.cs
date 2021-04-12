using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSlot : MonoBehaviour
{
    public SlotBox slotBox;
    public Image button;
    public void ChangeData()
    {
        //  slotBox.++;
        slotBox.referance.data++;
        slotBox.Save();
        switch (slotBox.referance.functionGem.executionType)
        {
            case GemExecutionType.Toggle:
                {
                    slotBox.referance.data %= 2;
                    break;
                }
            case GemExecutionType.Move:
                {
                    slotBox.referance.data %= 4;
                    break;
                }
            case GemExecutionType.Rotate:
                {
                    slotBox.referance.data %= 4;
                    break;
                }
        }
        SetData();
    }
    public void SetData()
    {
        slotBox.Save();
        if (slotBox.referance.functionGem == null)
        {
            return;
        }
        switch (slotBox.referance.functionGem.executionType)
        {
            case GemExecutionType.Toggle:
                {
                    switch (slotBox.referance.data)
                    {
                        case 0:
                            {
                                button.sprite = GPUIManager.instance.dataOff;
                                break;
                            }
                        case 1:
                            {
                                button.sprite = GPUIManager.instance.dataOn;

                                break;
                            }
                    }
                    break;
                }
            case GemExecutionType.Move:
                {
                    switch (slotBox.referance.data)
                    {
                        case 0:
                            {
                                button.sprite = GPUIManager.instance.dataUp;

                                break;
                            }
                        case 1:
                            {
                                button.sprite = GPUIManager.instance.dataRight;

                                break;
                            }
                        case 2:
                            {
                                button.sprite = GPUIManager.instance.dataDown;

                                break;
                            }
                        case 3:
                            {
                                button.sprite = GPUIManager.instance.dataLeft;

                                break;
                            }
                    }
                    break;
                }
            case GemExecutionType.Rotate:
                {
                    slotBox.referance.data %= 4;
                    break;
                }
        }
    }
}
