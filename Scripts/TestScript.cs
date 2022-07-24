using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public interface IResource
{
    int ID
  {
    get;
  }
  string Name
  {
    get;
  }
}

[System.Serializable]
public class TestObject : IResource
{
   [SerializeField]  private string name = "";
   [SerializeField] private int id = 0;
    public int ID
    {
      get
      {
        return ID;
      }
    }
    public string Name
    {
      get
      {
        return name;
      }
    }
}

public interface IContainer
{
  IResource[] Resources
  {
     get;
  }
}

public abstract class ResourcesContainer : MonoBehaviour, IContainer
{

    public virtual IResource[] Resources
    {
        get
        {
            return null;
        }
    }
}
public class TestScript: ResourcesContainer
{
    [SerializeField]
    private TestObject[] tests = null;
    public override IResource[] Resources
    {
        get
        {
            return tests;
        }
    }
}






