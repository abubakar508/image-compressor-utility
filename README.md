# Image Compress Utility

Image Compress Utility is a Node.js library for compressing images on the client-side before uploading them to a server. It utilizes the sharp library for high-performance image processing.

## Installation

You can install the Image Compress Utility from the npm registry using npm or yarn.

Using npm:
```bash
npm install image-compress-utility

Using yarn:

bash

yarn add image-compress-utility

```

## Usage


# Here's a basic example of how to use the compressImage function:


```bash

const { compressImage } = require('image-compress-utility');

async function compressAndUploadImage(file) {
  try {
    const compressedImage = await compressImage(file, { maxWidth: 800, maxHeight: 600, quality: 70 });
    // Upload the compressedImage to your server
  } catch (error) {
    console.error('Error compressing image:', error);
  }
}

// Usage with a file buffer
const fileBuffer = ... // Read file buffer from file input
compressAndUploadImage(fileBuffer);

// Usage with a Readable stream
const fileStream = ... // Read file stream from file input
compressAndUploadImage(fileStream);


```

## In Next JS application

```bash

// Import necessary modules
"use client";
import React, { useState } from 'react';
import { compressImage } from 'image-compress-utility';

// Define your Next.js component
const ImageUpload = () => {
  // State to hold the compressed image data URL
  const [compressedImageSrc, setCompressedImageSrc] = useState(null);

  // Function to handle file upload
  const handleFileUpload = async (event) => {
    const file = event.target.files[0]; // Get the uploaded file

    try {
      // Compress the image using the compressImage function from image-compress-utility
      const compressedImageBuffer = await compressImage(file);
      const compressedImageDataURL = `data:${file.type};base64,${compressedImageBuffer.toString('base64')}`;
      
      // Set the compressed image data URL to state
      setCompressedImageSrc(compressedImageDataURL);
      
      // Now you can upload the compressed image data URL to your server or use it as needed
    } catch (error) {
      console.error('Error compressing image:', error);
    }
  };

  return (
    <div>
      {/* Input field to upload an image */}
      <input type="file" onChange={handleFileUpload} />
      
      {/* Display the compressed image */}
      {compressedImageSrc && <img src={compressedImageSrc} alt="Compressed Image" />}
    </div>
  );
};

export default ImageUpload;


```


The compressImage function accepts a file buffer or a Readable stream as input and returns a Promise that resolves to the compressed image buffer.
Options

You can customize the compression settings by passing options to the compressImage function:

```bash

    maxWidth: Maximum width of the compressed image (default: 1024)
    maxHeight: Maximum height of the compressed image (default: 1024)
    quality: Compression quality (default: 80)
    format: Output format options (default: { id: 'jpeg' })
    progressive: Enable progressive JPEGs (default: false)

```

Link to npm package: [Image Compress Utility](https://www.npmjs.com/package/image-compress-utility)
