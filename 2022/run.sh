#! /bin/bash

bazel build $1
./bazel-bin/$1