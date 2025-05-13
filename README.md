## UsmDemuxer - a simple demuxer

Code copied from [VGMToolBox](https://github.com/jeeb/vgmtoolbox/)  
License unknown?

## Build
Drag into Visual Studio, or build with mono `xbuild UsmDemuxer.sln` or grab artifacts from [Actions](https://github.com/myssal/UsmDemuxer/actions)

## Usage:
```
Description:
  CRI USM Demuxer

Usage:
  UsmDemuxer <input> [options]

Arguments:
  <input>  Path to the .usm file

Options:
  --extract_audio        Extract audio stream.
  --extract_video        Extract video stream.
  --add_header           Add ADX/AAC header to audio stream.
  --split_audio_streams  Split audio into multiple streams if present.
  --version              Show version information
  -?, -h, --help         Show help and usage information
```


