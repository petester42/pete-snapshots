# pm-snapshots

[![Build Status](https://travis-ci.org/petester42/pm-snapshots.svg)](https://travis-ci.org/petester42/pm-snapshots)

A test framework to compare snapshots in C#

## Usage

To set the reference image directory, you need to set the environment variable ``. This should point to the directory where you want reference images to be stored.

|Name|Value|
|:---|:----|
|`PM_REFERENCE_IMAGE_DIR`|`Tests/ReferenceImages`|