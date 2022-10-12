using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject combatMenu;
    public GameObject wonMenu;
    public GameObject lostMenu;


    public Image firstWeaponImage;
    public Image secondWeaponImage;
    public Image firstConsumableImage;
    public TextMeshProUGUI firstConsumableAmountText;
    public Image secondConsumableImage;
    public TextMeshProUGUI secondConsumableAmountText;

    public TextMeshProUGUI infoText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI earnedGoldText;

    public TextMeshProUGUI playerName;
    public Slider playerHP;
    public TextMeshProUGUI enemyName;
    public Slider enemyHP;


    // Private
    private CombatUnitSO _player;
    private CombatUnitSO _enemy;
    private InventorySO _playerInventory;

    public void SetupHUD(CombatUnitSO player, CombatUnitSO enemy, InventorySO playerInventory, int level, int gold)
    {
        // Save references for later
        this._player = player;
        this._enemy = enemy;
        this._playerInventory = playerInventory;

        // Link HUD
        this.playerName.text = this._player.unitName;
        this.playerHP.minValue = 0;
        this.playerHP.maxValue = this._player.maxHP;

        this.enemyName.text = this._enemy.unitName;
        this.enemyHP.minValue = 0;
        this.enemyHP.maxValue = this._enemy.maxHP;

        this.levelText.text = "Level \n" + level.ToString();
        this.goldText.text = gold.ToString();

        // Items

        // First weapon
        if (playerInventory.weapons.Count > 0)
        {
            var firstWeapon = playerInventory.weapons[0];
            this.firstWeaponImage.sprite = firstWeapon.icon;
            this.firstWeaponImage.color = Color.white;
        }
        else
        {
            this.firstWeaponImage.sprite = null;
            this.firstWeaponImage.color = Color.clear;
        }

        // Second weapon
        if (playerInventory.weapons.Count > 1)
        {
            var secondWeapon = playerInventory.weapons[1];
            this.secondWeaponImage.sprite = secondWeapon.icon;
            this.secondWeaponImage.color = Color.white;
        }
        else
        {
            this.secondWeaponImage.sprite = null;
            this.secondWeaponImage.color = Color.clear;
        }
    }


    public void SetInfoText(string infoText)
    {
        this.infoText.text = infoText;
    }

    public void ShowCombatMenu()
    {
        combatMenu.SetActive(true);
        wonMenu.SetActive(false);
        lostMenu.SetActive(false);
    }

    public void ShowWonMenu(int earnedGold)
    {
        this.earnedGoldText.text = "+" + earnedGold.ToString();

        wonMenu.SetActive(true);
        combatMenu.SetActive(false);
        lostMenu.SetActive(false);
    }

   

    public void ShowLostMenu()
    {
        lostMenu.SetActive(true);
        wonMenu.SetActive(false);
        combatMenu.SetActive(false);
    }

    public void ResetHUD()
    {
        this._player = null;
        this._enemy = null;

        // Link HUD
        this.playerName.text = "";
        this.playerHP.minValue = 0;
        this.playerHP.maxValue = 0;
        this.playerHP.value = 0;

        this.enemyName.text = "";
        this.enemyHP.minValue = 0;
        this.enemyHP.maxValue = 0;
        this.enemyHP.value = 0;

        this.levelText.text = "Level \n-";
        this.goldText.text = "";

        // Items
        this.firstWeaponImage.sprite = null;
        this.firstWeaponImage.color = Color.clear;

        this.secondWeaponImage.sprite = null;
        this.secondWeaponImage.color = Color.clear;

        this.firstConsumableImage.sprite = null;
        this.firstConsumableImage.color = Color.clear;

        this.secondConsumableImage.sprite = null;
        this.secondConsumableImage.color = Color.clear;
    }

    private void Update()
    {
        if (this._player != null)
            this.playerHP.value = this._player.currentHP;

        if (this._enemy != null)
            this.enemyHP.value = this._enemy.currentHP;

        if (this._playerInventory != null)
        {
            // first consumable
            if (this._playerInventory.consumables.Count > 0)
            {
                var firstConsumable = this._playerInventory.consumables[0];
                this.firstConsumableImage.sprite = firstConsumable.item.icon;
                this.firstConsumableImage.color = Color.white;
                this.firstConsumableAmountText.text = firstConsumable.amount.ToString();
            }
            else
            {
                this.firstConsumableImage.sprite = null;
                this.firstConsumableImage.color = Color.clear;
                this.firstConsumableAmountText.text = null;
            }

            // second consumable
            if (this._playerInventory.consumables.Count > 1)
            {
                var secondConsumable = this._playerInventory.consumables[1];
                this.secondConsumableImage.sprite = secondConsumable.item.icon;
                this.secondConsumableImage.color = Color.white;
                this.secondConsumableAmountText.text = secondConsumable.amount.ToString();
            }
            else
            {
                this.secondConsumableImage.sprite = null;
                this.secondConsumableImage.color = Color.clear;
                this.secondConsumableAmountText.text = null;
            }
        }
    }
}
