using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSoldier : MonoBehaviour {
    public enum TurnState { ATTACK, MOVE, WAIT, DEAD, ACTIVE }
    private TurnState currentState;
    private int currentHealth;
    private int attackPower;
    private int currentStamina;
    private string soldierType;
    private Vector3 soldierVector;
    private int atkRange;

    public virtual void init(string name){}

    public virtual void init() {}

    public virtual void takeDamage(int damageTaken){
        currentHealth = currentHealth - damageTaken;
    }
     
    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void setAttackPower(int attackPower)
    {
        this.attackPower = attackPower;
    }

    public int getAttackPower()
    {
        return attackPower;
    }

    public void setCurrentStamina(int currentStamina)
    {
        this.currentStamina = currentStamina;
    }

    public int getCurrentStamina()
    {
        return currentStamina;
    }

    public void setCurrentState(TurnState state)
    {
        this.currentState = state;
    }

    public TurnState getCurrentState()
    {
        return currentState;
    }

    public void setSoldierType(string soldierType)
    {
        this.soldierType = soldierType;
    }

    public string getSoldierType()
    {
        return soldierType;
    }

    public virtual void rollDie() { }

    public void setSoldierVector(Vector3 soldierVector)
    {
        this.soldierVector = soldierVector;
    }

    public Vector3 getSoldierVector()
    {
        return soldierVector;
    }

    public void setAtkRange(int atkRange)
    {
        this.atkRange = atkRange;
    }

    public int getAtkRange()
    {
        return atkRange;
    }
}
