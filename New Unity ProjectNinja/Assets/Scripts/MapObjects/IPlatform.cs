using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatform 
{
      void OnCollisionEnter2D(Collision2D collision);

      void DroppingPlatform();
      

}
