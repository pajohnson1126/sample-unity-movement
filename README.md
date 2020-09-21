

# Sample Unity Physics


A sample Unity (2020.1) project that shows

- Essential physics concepts in Unity
- How to use base classes and [C# inheritance](https://learn.unity.com/tutorial/inheritance)
- Basic use of the URP (Universal Render Pipeline)




## Physics Basic Scene

- CubeTranslate - Uses `transform.Translate()` to move; Good for simple object movement but, since you are controlling this directly, all physics interactions (collissions, etc.) will result in unexpected results
- CubeAddforce - A simple `AddForce()` example.
- CubeMovePosition - `Rigidbody.MovePosition()` manipulates transform.position, but calculates collision (mostly) along the way.


See these tutorials for more
- (Move in Unity3D - Ultimate Unity Tutorial)[https://www.youtube.com/watch?v=fyV77lN1Yl0&ab_channel=JasonWeimann] (49:23)
- (Unity Movement [RigidBody vs Translate])[https://www.youtube.com/watch?v=ixM2W2tPn6c&ab_channel=PressStart] (10:30)
- (How to add Force correctly | Unity Physics 101 (1/3))[https://www.youtube.com/watch?v=BNiAt0HnC5M] (10:30)




### URP

To use URP (or [convert from legacy rendering](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/InstallURPIntoAProject.html)):

- Install URP Package
- Create URP asset and add to graphics settings
- Camera - Check rendering settings
- Scene - Use Lighting Settings
- Ensure all your materials use [URP shaders](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/upgrading-your-shaders.html)

