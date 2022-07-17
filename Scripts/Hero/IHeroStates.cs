using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeroState 
{
  ActionsHero actionsHero {get; set;}
  bool isMove {get;}
  int actionValue {get; }
}

public class MovingLeftState:IHeroState
{
    public ActionsHero actionsHero {get; set;}
    public int actionValue {
                                     get {
                                          actionsHero = ScriptableObject.CreateInstance<ActionsHero>();
                                          return actionsHero.actionsValue["MoveLeft"];
                                         } 
                           }
    public bool isMove {
                          get { return true; }
                       }
}

public class MovingRightState:IHeroState
{
    public ActionsHero actionsHero {get; set;}
    public int actionValue {
                                     get {
                                            actionsHero = ScriptableObject.CreateInstance<ActionsHero>();
                                            return actionsHero.actionsValue["MoveRight"];
                                         } 
                           }
     public bool isMove {
                          get { return true; }
                        }
}


public class MovingStopState:IHeroState
{
    public ActionsHero actionsHero {get; set;}
    public int actionValue {
                                     get {
                                            actionsHero = ScriptableObject.CreateInstance<ActionsHero>();
                                            return actionsHero.actionsValue["None"];
                                         } 
                           }
     public bool isMove {
                          get { return false; }
                        }
}



public class JumpingState:IHeroState
{
    public ActionsHero actionsHero {get; set;}
    public int actionValue {
                                     get {
                                            actionsHero = ScriptableObject.CreateInstance<ActionsHero>();
                                            return actionsHero.actionsValue["Jump"];
                                         } 
                           }
     public bool isMove {
                          get { return false; }
                        }
}