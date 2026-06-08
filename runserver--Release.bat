@echo off
dotnet run --property:Configuration=Release --project Content.Server --config-file Resources/ConfigPresets/Void/VoidSector.toml
pause