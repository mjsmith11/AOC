# 2022 Notes
## Bazel Installation
The easiest way is [Bazelisk](https://github.com/bazelbuild/bazelisk)
## Building
- [bazel-compdb](https://marketplace.visualstudio.com/items?itemName=StackBuild.bazel-stack-vscode-cc) makes vscode a little happier about external dependencies that are managed via bazel.  I used command line, not this extension, but the extension looked useful.
- Add a target to BUILD similar to the rest of them.
- `bazel build <target_name>`
## Running
- Binaries are sent to `bazel-bin` which is gitignored
- pwd is the same as the directory where you invoke the binary. (For file i/o, etc)
- From `2022`, `./run.sh Day01` would build and run Day01 for one command to run with recent changes.