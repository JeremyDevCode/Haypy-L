using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum CombatStates
{
    NONE,
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class CombatManager : MonoBehaviour
{

    public InputField inputText;
    public Text textAnswer;
    public GameObject Aceptar;
    public GameObject Total;
    public GameObject imagen;




    private void Awake(){
        Total.SetActive(false);
    }
    private void Update(){
        if(textAnswer.text.Length < 1){
            Aceptar.SetActive(false);
     
        } 
        if(textAnswer.text.Length >= 1){
            Aceptar.SetActive(true);
         
        }
    }

    public void aceptar(){



        if(this._currentLevel == 12 && inputText.text == "3" || this._currentLevel == 13 && inputText.text == "3" || 
           this._currentLevel == 14 && inputText.text == "2" || this._currentLevel == 15 && inputText.text == "1" ||
           this._currentLevel == 16 && inputText.text == "9" || this._currentLevel == 17 && inputText.text == "2" || 
           this._currentLevel == 18 && inputText.text == "2" || this._currentLevel == 19 && inputText.text == "4" || 
           this._currentLevel == 20 && inputText.text == "1" || this._currentLevel == 21 && inputText.text == "x^5" ||
           this._currentLevel == 22 && inputText.text == "a^-5" || this._currentLevel == 23 && inputText.text == "a^3" ||
           this._currentLevel == 24 && inputText.text == "a^-10" || this._currentLevel == 25 && inputText.text == "x^6" || 
           this._currentLevel == 26 && inputText.text == "x^-10" || this._currentLevel == 27 && inputText.text == "x^6 * y^9" || 
           this._currentLevel == 28 && inputText.text == "x^-16 * y^24" || this._currentLevel == 29 && inputText.text == "x^12 / y^6" ||
           this._currentLevel == 30 && inputText.text == "y^6 * x x^36" || this._currentLevel == 31 && inputText.text == "6x + 14" ||
           this._currentLevel == 32 && inputText.text == "-4x - 19" || this._currentLevel == 33 && inputText.text == "-2x + 8" || 
           this._currentLevel == 34 && inputText.text == "2x + 20" || this._currentLevel == 35 && inputText.text == "(3/2)x + 16" || 
           this._currentLevel == 36 && inputText.text == "2.64x + 2.24" || this._currentLevel == 37 && inputText.text == "9x + 17y - 14" ||
           this._currentLevel == 38 && inputText.text == "x^2 + 7xy - 4x - 12" || this._currentLevel == 39 && inputText.text == "9x + 3" ||
           this._currentLevel == 40 && inputText.text == "-12x - 9"   )
        {
            inputText.text=null;
           Ganar();
        } else {
           Perder();
        }

    }

    [Header("Combat Configuration")]
    public int baseGoldPrize = 10;
    public float prizeIncrementPerLevel = 0.20f; // 20%
    public float timeBetweenActions = 1.5f; // 1.5 seconds
    public int _hearts = 3;
    public GameObject continuar;
    public GameObject buttonAceptar;



    [Header("Combat Messages Configuration")]
    public string combatStartedInfoText = "An enemy appeared...";
    public string playerTurnInfoText = "Player's turn...";
    public string playerWonInfoText = "Enemy defeated!";
    public string enemyTurnInfoText = "Enemy's turn...";
    public string enemyAttackedInfoText = "Enemy attacked!";
    [Header("Combat Messages Configuration")]

    [TextArea(2, 5)]
    public string Question1 = "Bienvenido a la pregunta 1";
    [TextArea(2, 5)]
    public string Question2 = "Bienvenido a la pregunta 2";
    [TextArea(2, 5)]
    public string Question3 = "Bienvenido a la pregunta 3";
    [TextArea(2, 5)]
    public string Question4 = "Bienvenido a la pregunta 4";
    [TextArea(2, 5)]
    public string Question5 = "Bienvenido a la pregunta 5";
    [TextArea(2, 5)]
    public string Question6 = "Bienvenido a la pregunta 6";
    [TextArea(2, 5)]
    public string Question7 = "Bienvenido a la pregunta 7";
    [TextArea(2, 5)]
    public string Question8 = "Bienvenido a la pregunta 8";
    [TextArea(2, 5)]
    public string Question9 = "Bienvenido a la pregunta 9";
    [TextArea(2, 5)]
    public string Question10 = "Bienvenido a la pregunta 10";
    [TextArea(2, 5)]
    public string Question11 = "Bienvenido a la pregunta 11";
    [TextArea(2, 5)]
    public string Question12 = "Bienvenido a la pregunta 12";
    [TextArea(2, 5)]
    public string Question13 = "Bienvenido a la pregunta 13";
    [TextArea(2, 5)]
    public string Question14 = "Bienvenido a la pregunta 14";
    [TextArea(2, 5)]
    public string Question15 = "Bienvenido a la pregunta 15";
    [TextArea(2, 5)]
    public string Question16 = "Bienvenido a la pregunta 16";
    [TextArea(2, 5)]
    public string Question17 = "Bienvenido a la pregunta 17";
    [TextArea(2, 5)]
    public string Question18 = "Bienvenido a la pregunta 18";
    [TextArea(2, 5)]
    public string Question19 = "Bienvenido a la pregunta 19";
    [TextArea(2, 5)]
    public string Question20 = "Bienvenido a la pregunta 20";
    [TextArea(2, 5)]
    public string Question21 = "Bienvenido a la pregunta 21";
    [TextArea(2, 5)]
    public string Question22 = "Bienvenido a la pregunta 22";
    [TextArea(2, 5)]
    public string Question23 = "Bienvenido a la pregunta 23";
    [TextArea(2, 5)]
    public string Question24 = "Bienvenido a la pregunta 24";
    [TextArea(2, 5)]
    public string Question25 = "Bienvenido a la pregunta 25";
    [TextArea(2, 5)]
    public string Question26 = "Bienvenido a la pregunta 26";
    [TextArea(2, 5)]
    public string Question27 = "Bienvenido a la pregunta 27";
    [TextArea(2, 5)]
    public string Question28 = "Bienvenido a la pregunta 28";
    [TextArea(2, 5)]
    public string Question29 = "Bienvenido a la pregunta 29";
    [TextArea(2, 5)]
    public string Question30 = "Bienvenido a la pregunta 30";
    [TextArea(2, 5)]
    public string Question31 = "Bienvenido a la pregunta 31";
    [TextArea(2, 5)]
    public string Question32 = "Bienvenido a la pregunta 32";
    [TextArea(2, 5)]
    public string Question33 = "Bienvenido a la pregunta 33";
    [TextArea(2, 5)]
    public string Question34 = "Bienvenido a la pregunta 34";
    [TextArea(2, 5)]
    public string Question35 = "Bienvenido a la pregunta 35";
    [TextArea(2, 5)]
    public string Question36 = "Bienvenido a la pregunta 36";
    [TextArea(2, 5)]
    public string Question37 = "Bienvenido a la pregunta 37";
    [TextArea(2, 5)]
    public string Question38 = "Bienvenido a la pregunta 38";
    [TextArea(2, 5)]
    public string Question39 = "Bienvenido a la pregunta 39";
    [TextArea(2, 5)]
    public string Question40 = "Bienvenido a la pregunta 40";
  


    [Header("Dependencies")]
    public CombatUI combatUI;

    


    // Private

    private CombatStates _combatState = CombatStates.NONE;
    public int _currentLevel = 1;
    private int _gold = 0;
   

    private CombatRequest _request;
    private CombatUnitSO _currentEnemy;
    private GameObject _currentEnemyGO;

   
     public void Perder()
    {
        this._hearts -= 1;
        this.combatUI.SetupHUD(this._request.player, this._currentEnemy, this._request.player.inventory, this._currentLevel, this._hearts);
        if (_hearts == 2)
            this._request.player.currentHP = 66f;
        if (_hearts == 1)
            this._request.player.currentHP = 33f;
        if (_hearts == 0)
        {
            ResetCombat();
            CombatLost();
            Debug.Log(_currentLevel);
        }
    }


    public void Ganar()
    {
        StartCoroutine(CombatWon());

    }
    

    public void CorrectAnswera()
    {
        if (this._currentLevel == 1 || this._currentLevel == 2 || this._currentLevel == 6 || this._currentLevel == 10 || this._currentLevel == 11){
           Ganar(); } else {
               Perder();
           }
    }

public void CorrectAnswerb()
    {
        if (this._currentLevel == 3 || this._currentLevel == 4 || this._currentLevel == 5 || this._currentLevel == 7 || this._currentLevel == 8
        || this._currentLevel == 9){
           Ganar(); } else {
               Perder();
           }
    }

    public void newText()
    {
        if(this._currentLevel>11 && _currentLevel<42){
            Total.SetActive(true);
            buttonAceptar.SetActive(false);
        }else{
        if(this._currentLevel>40){
            imagen.SetActive(true);
        }
        }

    }

    public SaveSystem saveSystem;
    public void SetupCombat(CombatRequest request)
    {
        // Save references for later
        this._hearts = this.saveSystem.playerInventory.hearts;
        this._currentLevel = this.saveSystem.playerInventory.currentLevel;
        Debug.Log(this._currentLevel);
        this._request = request;

        // Set player's HP to max
        this._request.player.ResetHP();

        // Instantiate player
        GameObject playerGO = Instantiate(this._request.player.unitPrefab, request.playerPosition.position, Quaternion.identity);
        playerGO.transform.parent = request.playerPosition;

        // Start combat
        StartCoroutine(StartCombat());
    }


    public void NextCombat()
    {
        this._currentLevel += 1;
        StartCoroutine(StartCombat());
    }
   


    public void ResetCombat()
    {
        this._hearts = 3;
        this._gold = 10;
          StartCoroutine(StartCombat());
        }
    

    public void OnPlayerUsedItem(int inventoryItemId)
    {
        if (this._combatState != CombatStates.PLAYERTURN)
            return;

 if (inventoryItemId == 2 || inventoryItemId == 3) 
        {
            var consumableIndex = inventoryItemId % 2;

            if (this._request.player.inventory.consumables.Count > consumableIndex)
            {
                var usedConsumable = this._request.player.inventory.consumables[consumableIndex];
                this._request.player.Heal(usedConsumable.item.healPower);
                this._hearts += usedConsumable.item.hearts;
                this._request.player.inventory.RemoveConsumable(usedConsumable.item);
                this.combatUI.SetupHUD(this._request.player, this._currentEnemy, this._request.player.inventory, this._currentLevel, this._hearts);

            }

          //  StartCoroutine(EnemyTurn());
        }
    }


    // Combat status

    private IEnumerator StartCombat()
    {
        this._combatState = CombatStates.START;
          newText();


        int randomNumber = Random.Range(0, this._request.enemies.Length);
        this._currentEnemy = this._request.enemies[randomNumber];

        // Setup enemy's life
        
        this._currentEnemy.currentHP = this._currentEnemy.maxHP;

        // Instantiate enemy
        this._currentEnemyGO = Instantiate(this._currentEnemy.unitPrefab, this._request.enemyPosition.position, Quaternion.identity);
        this._currentEnemyGO.transform.parent = this._request.enemyPosition;

        // Configure HUD
        this.combatUI.ResetHUD();
        this.combatUI.ShowCombatMenu();
        this.combatUI.SetupHUD(this._request.player, this._currentEnemy, this._request.player.inventory, this._currentLevel, this._hearts);

        this.combatUI.SetInfoText(combatStartedInfoText);

        yield return new WaitForSeconds(this.timeBetweenActions);

        PlayerTurn();

      
    }
    private void PlayerTurn()
    {
        this._combatState = CombatStates.PLAYERTURN;
        if (this._currentLevel == 1)
            this.combatUI.SetInfoText(Question1);
        if (this._currentLevel == 2)
            this.combatUI.SetInfoText(Question2);
        if (this._currentLevel == 3)
            this.combatUI.SetInfoText(Question3);
        if (this._currentLevel == 4)
            this.combatUI.SetInfoText(Question4);
        if (this._currentLevel == 5)
            this.combatUI.SetInfoText(Question5);
        if (this._currentLevel == 6)
            this.combatUI.SetInfoText(Question6);
        if (this._currentLevel == 7)
            this.combatUI.SetInfoText(Question7);
        if (this._currentLevel == 8)
            this.combatUI.SetInfoText(Question8);
        if (this._currentLevel == 9)
            this.combatUI.SetInfoText(Question9);
        if (this._currentLevel == 10)
            this.combatUI.SetInfoText(Question10);
        if (this._currentLevel == 11)
            this.combatUI.SetInfoText(Question11);
        if (this._currentLevel == 12)
            this.combatUI.SetInfoText(Question12);
        if (this._currentLevel == 13)
            this.combatUI.SetInfoText(Question13);
        if (this._currentLevel == 14)
            this.combatUI.SetInfoText(Question14);
        if (this._currentLevel == 15)
            this.combatUI.SetInfoText(Question15);
        if (this._currentLevel == 16)
            this.combatUI.SetInfoText(Question16);
        if (this._currentLevel == 17)
            this.combatUI.SetInfoText(Question17);
        if (this._currentLevel == 18)
            this.combatUI.SetInfoText(Question18);
        if (this._currentLevel == 19)
            this.combatUI.SetInfoText(Question19);
        if (this._currentLevel == 20)
            this.combatUI.SetInfoText(Question20);
         if (this._currentLevel == 21)
            this.combatUI.SetInfoText(Question21);
        if (this._currentLevel == 22)
            this.combatUI.SetInfoText(Question22);
        if (this._currentLevel == 23)
            this.combatUI.SetInfoText(Question23);
        if (this._currentLevel == 24)
            this.combatUI.SetInfoText(Question24);
        if (this._currentLevel == 25)
            this.combatUI.SetInfoText(Question25);
        if (this._currentLevel == 26)
            this.combatUI.SetInfoText(Question26);
        if (this._currentLevel == 27)
            this.combatUI.SetInfoText(Question27);
        if (this._currentLevel == 28)
            this.combatUI.SetInfoText(Question28);
        if (this._currentLevel == 29)
            this.combatUI.SetInfoText(Question29);
        if (this._currentLevel == 30)
            this.combatUI.SetInfoText(Question30);
        if (this._currentLevel == 31)
            this.combatUI.SetInfoText(Question31);
        if (this._currentLevel == 32)
            this.combatUI.SetInfoText(Question32);
        if (this._currentLevel == 33)
            this.combatUI.SetInfoText(Question33);
        if (this._currentLevel == 34)
            this.combatUI.SetInfoText(Question34);
        if (this._currentLevel == 35)
            this.combatUI.SetInfoText(Question35);
        if (this._currentLevel == 36)
            this.combatUI.SetInfoText(Question36);
        if (this._currentLevel == 37)
            this.combatUI.SetInfoText(Question37);
        if (this._currentLevel == 38)
            this.combatUI.SetInfoText(Question38);
        if (this._currentLevel == 39)
            this.combatUI.SetInfoText(Question39);
        if (this._currentLevel == 40)
            this.combatUI.SetInfoText(Question40);
    }

  

    private IEnumerator CombatWon()
    {
        this._combatState = CombatStates.WON;

        // Set UI text
        this.combatUI.SetInfoText(playerWonInfoText);

        // Get some money for your win
        var earnedGold = (int)(this.baseGoldPrize * (1 + this.prizeIncrementPerLevel * this._currentLevel));
        this._gold += earnedGold;

        // Wait a bit
        yield return new WaitForSeconds(this.timeBetweenActions);

        // And show the win menu
        this.combatUI.ShowWonMenu(this._gold);
        this.ResetEnemysHPToBase();
        Destroy(this._currentEnemyGO);
        this._currentEnemyGO = null;

        if(_currentLevel==10 || _currentLevel==20 || _currentLevel==30 || _currentLevel>=40 ){
            continuar.SetActive(false);
        }else{
            continuar.SetActive(true);
        }
       
           }
public void FinishCombat()
    {
        this._request.player.inventory.AddGold(this._gold);
        this._request.player.inventory.AddHearts(this._hearts);
        this._request.player.inventory.AddLevel(this._currentLevel);
        this._currentLevel += 1;
    }



    private void CombatLost()
    {
        this._combatState = CombatStates.LOST;
        _hearts = 3;
        this.combatUI.ShowLostMenu();
        this.ResetEnemysHPToBase();
    }

 
    private void ResetEnemysHPToBase()
    {
        this._currentEnemy.maxHP = this._currentEnemy.baseHP;
    }
}
