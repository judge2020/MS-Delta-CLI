# MS-Delta-CLI
Command line usage for creating and applying delta updates with Microsoft Delta Compression. The best use case is distributing medium-sized files that have changed only a small amount with delta updates to save on bandwidth, file I/O and space. 

For details on how this compression works, see the original package's page [here](https://github.com/taspeotis/DeltaCompressionDotNet#readme).


### Usage

For a full list of options:

```
MS Delta CLI.exe --help
```

Example usage:

You have `loveletter.txt`, it is about 2000 words long and you send it.

Then you add about 500 more words to it and call the new file `loveletterextended.txt`.

You can use delta compression to create a small file, `extended.delta` which can be applied to the original `loveletter.txt` in order to have the original file contents update to the new `loveletterextended.txt` contents.

```
MS Delta CLI.exe -o loveletter.txt -n loveletterextended.txt -d extended.delta
```


### Compiling:

Required to have Visual Studio 17 with "Windows Classic Desktop" development capabilities.

Open the solution file, then go to `view -> other windows -> package manager console` and click "nuget restore"

Click the start button at the top of the screen. 