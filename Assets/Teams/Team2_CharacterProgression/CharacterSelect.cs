using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public enum ClassType { ranger, wizard, warrior };

    public List<SelectableCharacter> selectableCharacters;
    [System.Serializable]
    public class SelectableCharacter
    {
        public GameObject go;
        public ClassType classType;
    }
    Dictionary<ClassType, SelectableCharacter> selectableCharacterDictionary = new Dictionary<ClassType, SelectableCharacter>();
    int characterIndex = 0;

    private void Awake()
    {
        foreach (SelectableCharacter character in selectableCharacters)
            selectableCharacterDictionary.Add(character.classType, character);

        SetCharacter(selectableCharacters[0]);
    }

    public void AcceptButton()
    {

    }

    public void SetCharacter(int index)
    {
        SetCharacter(selectableCharacters[index]);
    }
    public void SetCharacter(SelectableCharacter selectableCharacter)
    {
        foreach (SelectableCharacter character in selectableCharacters)
            character.go.SetActive(character == selectableCharacter);
    }

    public void NextButton()
    {
        if (characterIndex < selectableCharacters.Count)
            characterIndex++;
        else
            characterIndex = 0;

        SetCharacter(characterIndex);
    }

    public void PreviousButton()
    {
        if (characterIndex > 0)
            characterIndex--;
        else
            characterIndex = selectableCharacters.Count - 1;

        SetCharacter(characterIndex);
    }
}