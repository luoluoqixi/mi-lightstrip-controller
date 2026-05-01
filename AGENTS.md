# AGENTS.md

## Project

This repository is a Windows desktop application for controlling a Xiaomi / Mijia ambient lightstrip through a serial port.

- Language: `C#`
- UI framework: `Windows Forms`
- Target framework: `.NET Framework 4.6`
- Project type: old-style `.csproj`, not SDK-style
- Solution entry: `mi-lightstrip-controller.sln`
- Application entry point: `src/Program.cs`

## Key files

- `src/Window/MainWindow.cs`: main UI flow, startup behavior, tray behavior, mode switching, power switching
- `src/Lightstrip/LightstripConnect.cs`: serial protocol orchestration and device state updates
- `src/Com/ComObj.cs`: serial command sending and retry loop
- `src/Com/ComUtility.cs`: COM port discovery via WMI
- `src/Setting/Setting.cs`: persistent settings and startup registration
- `src/Utility/IniUtility.cs`: INI read/write helpers

## Working rules

- Treat this as a Windows-only application. Do not propose cross-platform rewrites unless explicitly requested.
- Do not assume modern `dotnet` SDK workflows. Prefer Visual Studio / MSBuild compatible changes.
- Avoid adding dependencies unless they are clearly necessary.
- Prefer small, localized changes over broad refactors.
- Preserve current naming and persisted keys unless a rename is required for correctness.

## WinForms constraints

- This is a WinForms designer-based project.
- When editing forms, keep `.cs`, `.Designer.cs`, and `.resx` consistent.
- Avoid unnecessary structural changes to generated designer code.
- Be careful with async UI code and cross-thread control updates.

## Serial protocol notes

- The device is controlled through plain-text serial commands, not a binary protocol.
- Current serial settings in `LightstripConnect` are:
  - Baud rate: `230400`
  - Data bits: `8`
  - Stop bits: `One`
  - Parity: `None`
- Known commands include:
  - `set_power 1|0`
  - `get_power`
  - `get_length`
  - `set_pc_available 1|0`
  - `set_pc_linkage 1|0`
  - `set_rgb_pc ...`

## Mode behavior

The project currently supports:

- `Normal`: the UI's dynamic / ambient mode
- `PureColor`: PC-driven color mode using `set_rgb_pc`

Protocol timing matters. Do not simplify mode switching logic casually.

Observed and verified device behavior:

- After power-on, replaying the current mode after a short delay improves reliability.
- Switching from `PureColor` back to `Normal` is sensitive to command order and timing.
- The currently verified recovery sequence for returning to `Normal` is:
  1. `set_pc_linkage 0`
  2. `set_pc_available 0`
  3. if the strip is already on, reassert `set_power 1`
- Some mode-switch commands are more reliable when sent without waiting for a response.

If changing protocol flow, preserve command ordering guarantees and validate on real hardware.

## Persistence and permissions

- User settings are stored in `config.ini` next to the executable.
- Startup registration is written to `HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run`.
- Admin permissions may be required for startup-related behavior.
- COM port auto-detection currently depends on CH340 / CH341 style device naming.

## Validation guidance

- There is no automated test project in this repository.
- For device-control changes, real hardware verification is more important than speculative cleanup.
- When validating behavior, focus on:
  - COM port discovery
  - power off -> power on recovery
  - `Normal -> PureColor`
  - `PureColor -> Normal`
  - auto-open / auto-close behavior
  - tray minimize / close behavior

## Coding style

- Match the existing code style.
- Prefer straightforward imperative logic.
- Keep comments short and practical.
- Avoid introducing heavy abstractions for small UI or protocol changes.
