[33mcommit db996ada146c60327ad531a746e95e31bf6cd05c[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m)[m
Author: Victor <victor.storozhev1996@gmail.com>
Date:   Thu Apr 7 15:01:11 2022 +0900

    checked

[1mdiff --git a/Assets/Scripts/ActiveItem.cs b/Assets/Scripts/ActiveItem.cs[m
[1mindex 11ab7ba..bfc1fcc 100644[m
[1m--- a/Assets/Scripts/ActiveItem.cs[m
[1m+++ b/Assets/Scripts/ActiveItem.cs[m
[36m@@ -34,7 +34,7 @@[m [mpublic class ActiveItem : Item[m
     public virtual void SetLevel(int level)[m
     {[m
         Level = level;[m
[31m-        // обновляем число на шаре[m
[32m+[m[32m        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅ[m
         int number = (int)Mathf.Pow(2, level + 1);[m
         string numberString = number.ToString();[m
         _levelText.text = numberString;[m
[36m@@ -44,11 +44,12 @@[m [mpublic class ActiveItem : Item[m
     private void EnableTrigger()[m
     {[m
         _trigger.enabled = true;[m
[32m+[m[32m        // check git[m
     }[m
 [m
     public void SetupToTube()[m
     {[m
[31m-        // выключаем физику[m
[32m+[m[32m        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ[m
         _trigger.enabled = false;[m
         _collider.enabled = false;[m
         Rigidbody.isKinematic = true;[m
[36m@@ -57,14 +58,14 @@[m [mpublic class ActiveItem : Item[m
 [m
     public void Drop()[m
     {[m
[31m-        // делаем его физическим[m
[32m+[m[32m        // пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ[m
         _trigger.enabled = true;[m
         _collider.enabled = true;[m
         Rigidbody.isKinematic = false;[m
         Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;[m
[31m-        // Отперенчиваем от Spawn-а[m
[32m+[m[32m        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ Spawn-пїЅ[m
         transform.parent = null;[m
[31m-        // Задаем скорость вниз, чтоб летел быстрее[m
[32m+[m[32m        // пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ[m
         Rigidbody.velocity = Vector3.down * 1.2f;[m
     }[m
 [m
