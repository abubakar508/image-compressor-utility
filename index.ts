import Sharp from 'sharp';
import { Readable } from 'stream';

interface CompressOptions {
  maxWidth?: number;
  maxHeight?: number;
  quality?: number;
  format?: any
}

export async function compressImage(input: Buffer | Readable, options: CompressOptions = {}): Promise<Buffer> {
  const { maxWidth = 1024, maxHeight = 1024, quality = 80, format = { id: 'jpeg' } } = options;

  const transformer = Sharp()
    .resize({ width: maxWidth, height: maxHeight, fit: 'inside', withoutEnlargement: true })
    .toFormat(format, { quality });

  if (Buffer.isBuffer(input)) {
    return transformer.toBuffer();
  } else {
    return input.pipe(transformer).toBuffer();
  }
}
