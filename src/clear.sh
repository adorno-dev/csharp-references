#/bin/bash

find | grep -e bin$ | xargs rm -rf
find | grep -e obj$ | xargs rm -rf
find | grep -e .vscode | xargs rm -rf