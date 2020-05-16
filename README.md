# A Study in Adversarial Behavior using Unity

**Overview**

Welcome to the repo for my CS485 final project. 
In this project, I will be attempting to answer the question:
what kind of strategies will two agents with the same neural network exhibit to
out-compete each other in a game?

For this project we will be using the Unity ML-Agents toolkit to create an environment
in Unity to allow our agents to train. [https://github.com/Unity-Technologies/ml-agents]

This project was inspired by OpenAI's study titled "Emergent Tool Use from Multi-Agent Interaction" found here. 
[https://openai.com/blog/emergent-tool-use/]

All code was written in C#, the native language for Unity, with extensive help from the excellent ML-Agents documentation
linked below.

If you navigate to the ml-agents folder > config > roller2_config.yaml you can view the hyperparameters of the network.
These values can be changed at anytime before training.

I have chosen to use a network with 15 input neurons (the overall size of my agents' observation space) 2, 256 node hidden layers
densly connected, and two output nodes corresponding to the agent's Z or X axis movement (the agent's action space).

BE WARNED: This took an incredible amount of fiddling to get working, and a lot of the issues came from conflicting versions of 
python, the ML-Agents toolkit, and tensorflow. Below I have done my best to boil down the steps for a clean installation in
order to reproduce the project.

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
- File -> Open Project -> Select Cloned Folder
- Drag the *UnitySDK* folder located in the cloned ml-agents folder into the assets window at the bottom of the Unity interface
- Go to Edit > Project Settings > Player
- Expand the Other Settings section
- Select Scripting Runtime Version to Experimental (.NET 4.6 Equivalent or .NET 4.x Equivalent)
- You should now be able to run the Virgil project
- Note: There is a folder titled Brains in the asset area, this contains various models at different levels of training that
can be applied to the Agents in the Unity scene to make them work. If you run the project without a model then the agents will
respond randomly.

**Environment Setup (for standalone project)**
- Launch Unity
- Drag the *UnitySDK* folder located in the cloned ml-agents folder into the assets window at the bottom of the Unity interface
- Go to Edit > Project Settings > Player
- Expand the Other Settings section
- Select Scripting Runtime Version to Experimental (.NET 4.6 Equivalent or .NET 4.x Equivalent)
- Go to File > Save Project
- Unity is now setup for the creation of a ML project. The basic guide is located here [https://github.com/Unity-Technologies/ml-agents/blob/release-0.13.1/docs/Basic-Guide.md]
- The documentation for the Unity ML-Agents toolkit is located here [https://github.com/Unity-Technologies/ml-agents/tree/release-0.13.1/docs]
