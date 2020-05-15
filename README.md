# A Study in Adversarial Behavior using Unity

**Overview**

**Installation**

- Download latest version of the Unity Engine - [https://unity.com/]
- Clone the final project repo, should have the Virgil folder and the ml-agents-0.13.1 folder
- Open the Unity Engine and select Window -> Package Manager
- At the top, select Advanced -> Show preview packages
- Ensure that Barracuda is selected and allow it to install
- Install Python *MUST BE version 3.7.6* and ensure pip3 is installed
- Navigate to the cloned ml-agents repo folder and run
```
~$ cd ml-agents-envs
~$ pip3 install -e ./
~$ cd ..
~$ cd ml-agents
~$ pip3 install -e ./
```
- On the command line you should be able to run
```
~$ mlagents-learn --help
```

**Opening Virgil Project**
- Launch Unity

**Environment Setup (for standalone project)**
- Launch Unity
- Drag the *UnitySDK* folder located in the cloned ml-agents folder into the assets window at the bottom of the Unity interface
- Go to Edit > Project Settings > Player
- Expand the Other Settings section
- Select Scripting Runtime Version to Experimental (.NET 4.6 Equivalent or .NET 4.x Equivalent)
- Go to File > Save Project
- Unity is now setup for the creation of a ML project. The basic guide is located here [https://github.com/Unity-Technologies/ml-agents/blob/release-0.13.1/docs/Basic-Guide.md]
- The documentation for the Unity ML-Agents toolkit is located here [https://github.com/Unity-Technologies/ml-agents/tree/release-0.13.1/docs]
