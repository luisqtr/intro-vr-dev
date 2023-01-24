# Intro to VR dev
 
Basic Unity project already configured to develop VR apps for either desktop app with Oculus Link (`.exe`) or standalone apps Oculus Quest (`.apk`).

The project is the designed for the workshop *"Building VR apps with Unity"* for the [Master's Programme in Design for Creative and Immersive Technology][SDKIO] at the [Department of Computer and Systems Sciences][DSV] at Stockholm University, Sweden.

This project is tested using:
- Unity v2021.3.16f1 (with Android modules)
- XR Plugin Management v4.3.1
- OpenXR Plugin v1.5.3
- XR Interaction Toolkit v2.0.4
- Meta Quest (via Link and standalone)

The project is cross-platform and utilizes OpenXR instead of proprietary XR APIs from headset manufacturers. Moreover, it contains the main XR interactions (locomotion, object manipulation, UI canvas) but does not show specific hand-held controllers. The specific 3D models for the left and right controllers can be added in the hierarchy under the respective `XR Origin/Camera Offset/#Hand Controller/`.

## Credits

- [Luis Quintero][luisqtr]

---

### Possible future additions

Extend with a scene that adapts the Unity educational project [Catapult Physics; Forces, and Energy][desktop-app] to a VR version.

<!-- References -->
[DSV]: https://dsv.su.se/
[SDKIO]: https://www.su.se/english/search-courses-and-programmes/sdkio-1.413330
[desktop-app]: https://learn.unity.com/project/catapult-physics-forces-and-energy
[luisqtr]: https://luisqtr.com/