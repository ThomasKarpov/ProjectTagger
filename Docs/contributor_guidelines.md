# Contributor Guidelines

## Purpose

These are general guidelines for code contributors on the team.
The goal in keeping these guidelines is to maintain uniformity
across our codebase.

## Guidelines

The guidelines for code contribution are as follows:

- You must keep the default Unity project layout
(Scenes, Scripts, etc.)
- All code must reside inside the `Assets/Scripts` directory.
- Each feature must be contained in a directory named after
the feature. For example, `Assets/Scripts/<feature_name>`.
- Each feature should have an example scene with a working
**demo** of the feature. The scene should be located under
`Assets/Scenes/Feature Demos/<feature_name>`.
- Any other assets used in the demo should be in their respective
directories in the Unity Assets directory following the same
conventioned outlined for the demo scene.
- Each feature must include relevant **documentation** regarding design
And usage in the top level Docs directory. It should follow the
convention `Docs/<feature_name>/<content>`.
