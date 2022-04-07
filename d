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
[31m-        // ��������� ����� �� ����[m
[32m+[m[32m        // ��������� ����� �� ����[m
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
[31m-        // ��������� ������[m
[32m+[m[32m        // ��������� ������[m
         _trigger.enabled = false;[m
         _collider.enabled = false;[m
         Rigidbody.isKinematic = true;[m
[36m@@ -57,14 +58,14 @@[m [mpublic class ActiveItem : Item[m
 [m
     public void Drop()[m
     {[m
[31m-        // ������ ��� ����������[m
[32m+[m[32m        // ������ ��� ����������[m
         _trigger.enabled = true;[m
         _collider.enabled = true;[m
         Rigidbody.isKinematic = false;[m
         Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;[m
[31m-        // ������������� �� Spawn-�[m
[32m+[m[32m        // ������������� �� Spawn-�[m
         transform.parent = null;[m
[31m-        // ������ �������� ����, ���� ����� �������[m
[32m+[m[32m        // ������ �������� ����, ���� ����� �������[m
         Rigidbody.velocity = Vector3.down * 1.2f;[m
     }[m
 [m
