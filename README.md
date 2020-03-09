# Image Manipulation
Implementations of image manipulation in C#. This snippet covers converting image type, resizing and compression.

## Compressing: Compressor.cs
| Function        |Description           | Input  | Output|
| ------------- |:-------------| -----:|-----:|
|GetEncoder| Retrieves the right ImageCodecInfo based on the ImageFormat passed. Returns null if the codec is not found. | ImageFormat format |ImageCodecInfo |
| Compress    | Compress an image with the specified compression rate and image format wanted.|byte[] image, ImageFormat format, long compressRate | byte[]|
| CompressToSize | Recursive function to compress an image to an approximate size.| byte[] image, ImageFormat format, long maxSize, long compressRate | byte[] |
