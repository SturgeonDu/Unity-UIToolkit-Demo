using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroDetailUI : MonoBehaviour
{
    private VisualElement m_Root;
    private Button m_ButtonReturn;
    
    // Start is called before the first frame update
    void Start()
    {
        var doc = GetComponent<UIDocument>();
        m_Root = doc.rootVisualElement;
        
        m_ButtonReturn = m_Root.Q<Button>("Button-Return");
        m_ButtonReturn.clicked += onBtn_Return;
        
    }

    public void Init(int heroID)
    {
        
    }

    private void onBtn_Return()
    {
        AddressableUtility.UnInstantiate(this.gameObject);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        m_ButtonReturn.clicked -= onBtn_Return;
    }
}
