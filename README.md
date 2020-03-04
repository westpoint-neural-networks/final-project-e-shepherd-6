# final-project

**Installation**

- Download latest version of the Unity Engine - [https://unity.com/]
- Clone ML-Agents Toolkit Repo *MUST BE release-0.13.1* - [https://github.com/Unity-Technologies/ml-agents/blob/release-0.13.1/docs/Installation.md]
- Open the Unity Engine and select Window -> Package Manager
- At the top, select Advanced -> Show preview packages
- Ensure that Barracuda is selected and allow it to install
- Install Python version *3.7.6* and ensure pip3 is installed
- Navigate to the cloned repo folder and run
```
~$ cd ml-agents-envs
~$ pip3 install -e ./
~$ cd ..
~$ cd ml-agents
~$ pip3 install -e ./
```
- On the command line you should be able to run mlagents-learn --help

**Environment Setup**
